// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Newtonsoft.Json;
using AddAutoTags;

namespace AddTags
{
    public static class AddAutoTags
    {
        [FunctionName("AddAutoTags")]
        public static void Run([EventGridTrigger] EventGridEvent eventGridEvent, ILogger log)
        {
            log.LogInformation(eventGridEvent.Data.ToString());
            
            var dataJObject = (Newtonsoft.Json.Linq.JObject)eventGridEvent.Data;
            
            var data = dataJObject.ToObject<CustomResourceWriteSuccessData>();
            var resourceUri = data.ResourceUri;
            log.LogInformation(resourceUri);

            //Update tags
            var resourceClient = new ResourcesManagementClient(data.SubscriptionId, new DefaultAzureCredential());
            var tags = new TagsPatchResource
            {
                Operation = TagsPatchResourceOperation.Merge,
                Properties = new Tags()
            };

            log.LogInformation("Add/Update Tag: ModifiedDate");
            tags.Properties.TagsValue.Add("ModifiedDate", DateTimeOffset.Now.ToString());
            
            log.LogInformation("Add/Update Tag: ModifiedBy");
            tags.Properties.TagsValue.Add("ModifiedBy", data.Claims["name"]);
            tags.Properties.TagsValue.Add("ModifiedById", data.Claims["http://schemas.microsoft.com/identity/claims/objectidentifier"]);
            
            //Add created by if they are not there
            log.LogInformation("Getting Current Tags");
            var currentTags = resourceClient.Tags.GetAtScope(resourceUri);
            if (!currentTags.Value.Properties.TagsValue.ContainsKey("CreatedBy"))
            {
                log.LogInformation("Add Tag: CreatedBy");
                tags.Properties.TagsValue.Add("CreatedBy", data.Claims["name"]);
                tags.Properties.TagsValue.Add("CreatedById", data.Claims["http://schemas.microsoft.com/identity/claims/objectidentifier"]);
            }
            if (!currentTags.Value.Properties.TagsValue.ContainsKey("CreatedDate"))
            {
                log.LogInformation("Add Tag: CreatedDate");
                tags.Properties.TagsValue.Add("CreatedDate", DateTimeOffset.Now.ToString());
            }

            log.LogInformation("Saving Tags");
            resourceClient.Tags.UpdateAtScope(resourceUri, tags);
        }
    }
}
