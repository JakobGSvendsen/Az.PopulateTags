using System;
using System.Collections.Generic;
using System.Text;

namespace AddAutoTags
{
   
        public class Evidence
        {
            public string Role { get; set; }
        }
        public class Authorization
        {
            public string Scope { get; set; }
            public string Action { get; set; }
            public Evidence Evidence { get; set; }
        }
        public class HttpRequest
        {
            public string ClientRequestId { get; set; }
            public string ClientIpAddress { get; set; }
            public string Method { get; set; }
            public string Url { get; set; }
        }
        public class CustomResourceWriteSuccessData
    {
            public Authorization Authorization { get; set; }
            public IDictionary<string, string> Claims { get; set; }
            public string CorrelationId { get; set; }
            public HttpRequest HttpRequest { get; set; }
            public string ResourceProvider { get; set; }
            public string ResourceUri { get; set; }
            public string OperationName { get; set; }
            public string Status { get; set; }
            public string SubscriptionId { get; set; }
            public string TenantId { get; set; }
        }

}
