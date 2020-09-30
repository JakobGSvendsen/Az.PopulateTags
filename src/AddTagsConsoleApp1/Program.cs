using Microsoft.Azure.EventGrid.Models;
using Newtonsoft.Json;
using System;

namespace AddTagsConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = "{\"authorization\": {\"scope\": \"/subscriptions/7fa4f2ea-77cd-4629-8fb0-42988a97b934/resourceGroups/testwe3\",\"action\": \"Microsoft.Resources/subscriptions/resourceGroups/write\",\"evidence\": {\"role\": \"Subscription Admin\"}},\"claims\": {\"aud\": \"https://management.core.windows.net/\",\"iss\": \"https://sts.windows.net/ba61f14a-6f38-49ac-bb4c-26281ae25fc5/\",\"iat\": \"1601320026\",\"nbf\": \"1601320026\",\"exp\": \"1601323926\",\"http://schemas.microsoft.com/claims/authnclassreference\": \"1\",\"aio\": \"ATQAy/8RAAAATqXgMSO5pxWOCk32vMEvdIE2hX8r5uyuyXZJjGp9gvSDnliAb5ilBlb2FqgmR1e3\",\"http://schemas.microsoft.com/claims/authnmethodsreferences\": \"pwd\",\"appid\": \"c44b4083-3bb0-49c1-b47d-974e53cbdf3c\",\"appidacr\": \"2\",\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname\": \"Svendsen\",\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname\": \"Jakob\",\"groups\": \"5a2472a5-c7c0-4321-a0cf-7d0d03da91ce,3f2d15ca-5a4f-4f40-b151-36fcb3548389,1f459f6a-83d2-44ce-8093-3ce8358f632a,6bb48acc-d7f9-460a-b8db-6e8d38f88ba1,9063d0ba-c437-448f-a55c-d9a1fb61a377\",\"ipaddr\": \"185.16.140.5\",\"name\": \"Jakob Gottlieb Svendsen (Runbook)\",\"http://schemas.microsoft.com/identity/claims/objectidentifier\": \"2c1bffd6-4129-4683-9bfa-7edee2d245e8\",\"puid\": \"10033FFF8C201306\",\"rh\": \"0.AAAASvFhujhvrEm7TCYoGuJfxYNAS8SwO8FJtH2XTlPL3zwvANQ.\",\"http://schemas.microsoft.com/identity/claims/scope\": \"user_impersonation\",\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier\": \"qwiJuGQspWMG5zyzwjUpX9B7pATGZ8nmNp006YGXQEA\",\"http://schemas.microsoft.com/identity/claims/tenantid\": \"ba61f14a-6f38-49ac-bb4c-26281ae25fc5\",\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name\": \"jakob@runbook.guru\",\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn\": \"jakob@runbook.guru\",\"uti\": \"5HXmGsfAQk-WS9NbfylxAA\",\"ver\": \"1.0\",\"wids\": \"e8611ab8-c189-46e8-94e1-60213ab1f814,62e90394-69f5-4237-9190-012177145e10,7be44c8a-adaf-4e2a-84d6-ab2649e08a13,194ae4cb-b126-40b2-bd5b-6091b380977d,b79fbf4d-3ef9-4689-8143-76b194e85509\",\"xms_tcdt\": \"1413728049\"},\"correlationId\": \"2dff02d5-0c07-469d-9e40-b8dcce90ccb7\",\"httpRequest\": {\"clientRequestId\": \"27231bd9-2061-42d3-9a8f-d69304684090\",\"clientIpAddress\": \"185.16.140.5\",\"method\": \"PUT\",\"url\": \"https://management.azure.com/subscriptions/7fa4f2ea-77cd-4629-8fb0-42988a97b934/resourceGroups/testwe3?api-version=2014-04-01-preview\"},\"resourceProvider\": \"Microsoft.Resources\",\"resourceUri\": \"/subscriptions/7fa4f2ea-77cd-4629-8fb0-42988a97b934/resourceGroups/testwe3\",\"operationName\": \"Microsoft.Resources/subscriptions/resourceGroups/write\",\"status\": \"Succeeded\",\"subscriptionId\": \"7fa4f2ea-77cd-4629-8fb0-42988a97b934\",\"tenantId\": \"ba61f14a-6f38-49ac-bb4c-26281ae25fc5\"}";

            //var data = System.Text.Json.JsonSerializer.Deserialize<CustomResourceWriteSuccessData>(json, new System.Text.Json.JsonSerializerOptions {PropertyNameCaseInsensitive = true});

            var data = JsonConvert.DeserializeObject<CustomResourceWriteSuccessData>(json);
            //dynamic data = Data;
            //var claims = data.claims.appid;
            //System.Security.Claims.Claim[] claims = data;
            Console.WriteLine(data.ToString() + "dddd");
        }
    }
}
