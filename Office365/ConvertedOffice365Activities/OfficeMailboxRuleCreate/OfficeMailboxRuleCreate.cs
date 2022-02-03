using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Ayehu.Sdk.ActivityCreation
{
    public class OfficeMailboxRuleCreate : IActivity
    {
        /// <summary>
        /// User's email to create the rule
        /// </summary>
        public string userEmail;

        /// <summary>
        /// Rule name
        /// </summary>
        public string ruleDisplayName;

        /// <summary>
        /// Apply the rule if sender contains this string
        /// </summary>
        public string senderContains;

        /// <summary>
        /// Apply the rule if body contains this string
        /// </summary>
        public string bodyContains;

        /// <summary>
        /// Indicates that email have to be forwarded or deleted
        /// </summary>   
        public string action;

        /// <summary>
        /// Forward email to the specified email address
        /// </summary>
        public string forwardEmail;

        /// <summary>
        /// Indicates that email have to be deleted
        /// </summary>
        public bool deleteAction;

        public string authToken_password;
        public string Jsonkeypath = "";

        private bool omitJsonEmptyorNull = false;
        private string contentType = "application/json";
        private string endPoint = "https://graph.microsoft.com";
        private string httpMethod = "POST";
        private string _uriBuilderPath;
        private string _postData;

        private Dictionary<string, string> _headers;

        private string uriBuilderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_uriBuilderPath))
                {
                    _uriBuilderPath = "/v1.0/users/" + userEmail + "/mailFolders/inbox/messageRules";
                }
                return _uriBuilderPath;
            }
            set
            {
                _uriBuilderPath = value;
            }
        }

        private string postData
        {
            get
            {
                if (string.IsNullOrEmpty(_postData))
                {
                    _postData = "";
                }
                return _postData;
            }
            set
            {
                _postData = value;
            }
        }

        private Dictionary<string, string> headers
        {
            get
            {
                if (_headers == null)
                {
                    _headers = new Dictionary<string, string>() { { "authorization", "Bearer " + authToken_password } };
                }
                return _headers;
            }
            set
            {
                _headers = value;
            }
        }

        public void Exec()
        {
            userEmail = "vadim@cromatix.com";
            ruleDisplayName = "3rdRule";
            bodyContains = "abc";
            //forwardAction = true;
            //forwardEmail = "abc@cromatix.com";

            deleteAction = true;

            authToken_password = "eyJ0eXAiOiJKV1QiLCJub25jZSI6Ink1RmdZY3VTOUdFMnRtRzFNVXp0WFdwbVh4LWhncnVzb1RrUTAxeEZTNm8iLCJhbGciOiJSUzI1NiIsIng1dCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyIsImtpZCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyJ9.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTAwMDAtYzAwMC0wMDAwMDAwMDAwMDAiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC8zYTQwMzI3NC1lM2QyLTQ1MWEtYWE1ZS1hNDIxOWVhY2MxZjYvIiwiaWF0IjoxNjE5Nzk3OTcwLCJuYmYiOjE2MTk3OTc5NzAsImV4cCI6MTYxOTgwMTg3MCwiYWNjdCI6MCwiYWNyIjoiMSIsImFjcnMiOlsidXJuOnVzZXI6cmVnaXN0ZXJzZWN1cml0eWluZm8iLCJ1cm46bWljcm9zb2Z0OnJlcTEiLCJ1cm46bWljcm9zb2Z0OnJlcTIiLCJ1cm46bWljcm9zb2Z0OnJlcTMiLCJjMSIsImMyIiwiYzMiLCJjNCIsImM1IiwiYzYiLCJjNyIsImM4IiwiYzkiLCJjMTAiLCJjMTEiLCJjMTIiLCJjMTMiLCJjMTQiLCJjMTUiLCJjMTYiLCJjMTciLCJjMTgiLCJjMTkiLCJjMjAiLCJjMjEiLCJjMjIiLCJjMjMiLCJjMjQiLCJjMjUiXSwiYWlvIjoiRTJaZ1lHRFBUdEJwdS9NaTdKK0xlTTd5Z3BQT3h5UW15QjY0NXJlc3hpczdkNjVjd3hNQSIsImFtciI6WyJwd2QiXSwiYXBwX2Rpc3BsYXluYW1lIjoiR3JhcGggZXhwbG9yZXIgKG9mZmljaWFsIHNpdGUpIiwiYXBwaWQiOiJkZThiYzhiNS1kOWY5LTQ4YjEtYThhZC1iNzQ4ZGE3MjUwNjQiLCJhcHBpZGFjciI6IjAiLCJmYW1pbHlfbmFtZSI6IlZpc25ldnNjaGkiLCJnaXZlbl9uYW1lIjoiVmFkaW0iLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiIxMDguMTYxLjE3My4xMjEiLCJuYW1lIjoiVmFkaW0gVmlzbmV2c2NoaSIsIm9pZCI6ImNhYmI5ZDFiLTBjNzQtNDIxZi1hODhkLTUxOTU1YTg0NDE3YiIsInBsYXRmIjoiMyIsInB1aWQiOiIxMDAzMjAwMDVCNzY2MjZFIiwicmgiOiIwLkFUY0FkREpBT3RMakdrV3FYcVFobnF6QjlyWElpOTc1MmJGSXFLMjNTTnB5VUdRM0FEOC4iLCJzY3AiOiJBY2Nlc3NSZXZpZXcuUmVhZC5BbGwgQWNjZXNzUmV2aWV3LlJlYWRXcml0ZS5BbGwgQWdyZWVtZW50LlJlYWQuQWxsIEFncmVlbWVudC5SZWFkV3JpdGUuQWxsIEFncmVlbWVudEFjY2VwdGFuY2UuUmVhZCBBZ3JlZW1lbnRBY2NlcHRhbmNlLlJlYWQuQWxsIEFuYWx5dGljcy5SZWFkIEFwcENhdGFsb2cuUmVhZFdyaXRlLkFsbCBBcHByb3ZhbFJlcXVlc3QuUmVhZC5BZG1pbkNvbnNlbnRSZXF1ZXN0IEFwcHJvdmFsUmVxdWVzdC5SZWFkLlByaXZpbGlnZWRBY2Nlc3MgQXBwcm92YWxSZXF1ZXN0LlJlYWRXcml0ZS5BZG1pbkNvbnNlbnRSZXF1ZXN0IEFwcHJvdmFsUmVxdWVzdC5SZWFkV3JpdGUuRW50aXRsZW1lbnRNYW5hZ2VtZW50IEFwcHJvdmFsUmVxdWVzdC5SZWFkV3JpdGUuUHJpdmlsaWdlZEFjY2VzcyBBdWRpdExvZy5SZWFkLkFsbCBCb29raW5ncy5NYW5hZ2UuQWxsIEJvb2tpbmdzLlJlYWQuQWxsIEJvb2tpbmdzLlJlYWRXcml0ZS5BbGwgQm9va2luZ3NBcHBvaW50bWVudC5SZWFkV3JpdGUuQWxsIENhbGVuZGFycy5SZWFkIENhbGVuZGFycy5SZWFkLlNoYXJlZCBDYWxlbmRhcnMuUmVhZFdyaXRlIENhbGVuZGFycy5SZWFkV3JpdGUuU2hhcmVkIENoYXQuUmVhZCBDaGF0LlJlYWRXcml0ZSBDb250YWN0cy5SZWFkIENvbnRhY3RzLlJlYWQuU2hhcmVkIENvbnRhY3RzLlJlYWRXcml0ZSBDb250YWN0cy5SZWFkV3JpdGUuU2hhcmVkIERldmljZS5Db21tYW5kIERldmljZS5SZWFkIERldmljZU1hbmFnZW1lbnRBcHBzLlJlYWQuQWxsIERldmljZU1hbmFnZW1lbnRBcHBzLlJlYWRXcml0ZS5BbGwgRGV2aWNlTWFuYWdlbWVudENvbmZpZ3VyYXRpb24uUmVhZC5BbGwgRGV2aWNlTWFuYWdlbWVudENvbmZpZ3VyYXRpb24uUmVhZFdyaXRlLkFsbCBEZXZpY2VNYW5hZ2VtZW50TWFuYWdlZERldmljZXMuUHJpdmlsZWdlZE9wZXJhdGlvbnMuQWxsIERldmljZU1hbmFnZW1lbnRNYW5hZ2VkRGV2aWNlcy5SZWFkLkFsbCBEZXZpY2VNYW5hZ2VtZW50TWFuYWdlZERldmljZXMuUmVhZFdyaXRlLkFsbCBEZXZpY2VNYW5hZ2VtZW50UkJBQy5SZWFkLkFsbCBEZXZpY2VNYW5hZ2VtZW50UkJBQy5SZWFkV3JpdGUuQWxsIERldmljZU1hbmFnZW1lbnRTZXJ2aWNlQ29uZmlnLlJlYWQuQWxsIERldmljZU1hbmFnZW1lbnRTZXJ2aWNlQ29uZmlnLlJlYWRXcml0ZS5BbGwgRGlyZWN0b3J5LkFjY2Vzc0FzVXNlci5BbGwgRGlyZWN0b3J5LlJlYWQuQWxsIERpcmVjdG9yeS5SZWFkV3JpdGUuQWxsIEV4dGVybmFsSXRlbS5SZWFkLkFsbCBGaWxlcy5SZWFkIEZpbGVzLlJlYWQuQWxsIEZpbGVzLlJlYWQuU2VsZWN0ZWQgRmlsZXMuUmVhZFdyaXRlIEZpbGVzLlJlYWRXcml0ZS5BbGwgR3JvdXAuUmVhZC5BbGwgR3JvdXAuUmVhZFdyaXRlLkFsbCBJZGVudGl0eVByb3ZpZGVyLlJlYWQuQWxsIElkZW50aXR5UHJvdmlkZXIuUmVhZFdyaXRlLkFsbCBJZGVudGl0eVJpc2tFdmVudC5SZWFkLkFsbCBNYWlsLlJlYWQgTWFpbC5SZWFkLlNoYXJlZCBNYWlsLlJlYWRCYXNpYyBNYWlsLlJlYWRXcml0ZSBNYWlsLlJlYWRXcml0ZS5TaGFyZWQgTWFpbC5TZW5kIE1haWwuU2VuZC5TaGFyZWQgTWFpbGJveFNldHRpbmdzLlJlYWRXcml0ZSBOb3Rlcy5SZWFkV3JpdGUuQWxsIG9wZW5pZCBPcmdhbml6YXRpb24uUmVhZC5BbGwgT3JnYW5pemF0aW9uLlJlYWRXcml0ZS5BbGwgT3JnQ29udGFjdC5SZWFkLkFsbCBQZW9wbGUuUmVhZCBQZW9wbGUuUmVhZC5BbGwgUG9saWN5LlJlYWRXcml0ZS5UcnVzdEZyYW1ld29yayBQcml2aWxlZ2VkQWNjZXNzLlJlYWRXcml0ZS5BenVyZUFEIFByaXZpbGVnZWRBY2Nlc3MuUmVhZFdyaXRlLkF6dXJlUmVzb3VyY2VzIHByb2ZpbGUgUmVwb3J0cy5SZWFkLkFsbCBTaXRlcy5GdWxsQ29udHJvbC5BbGwgU2l0ZXMuTWFuYWdlLkFsbCBTaXRlcy5SZWFkLkFsbCBTaXRlcy5SZWFkV3JpdGUuQWxsIFRhc2tzLlJlYWRXcml0ZSBVc2VyLlJlYWQgVXNlci5SZWFkLkFsbCBVc2VyLlJlYWRCYXNpYy5BbGwgVXNlci5SZWFkV3JpdGUgVXNlci5SZWFkV3JpdGUuQWxsIFVzZXJBY3Rpdml0eS5SZWFkV3JpdGUuQ3JlYXRlZEJ5QXBwIFVzZXJOb3RpZmljYXRpb24uUmVhZFdyaXRlLkNyZWF0ZWRCeUFwcCBlbWFpbCIsInNpZ25pbl9zdGF0ZSI6WyJrbXNpIl0sInN1YiI6Ikp2YS1kUmZOUDc4ZGt3U002ZmxSUy1FVHZfbXVYdGVrcGh2OUVYUWhuY28iLCJ0ZW5hbnRfcmVnaW9uX3Njb3BlIjoiTkEiLCJ0aWQiOiIzYTQwMzI3NC1lM2QyLTQ1MWEtYWE1ZS1hNDIxOWVhY2MxZjYiLCJ1bmlxdWVfbmFtZSI6InZhZGltQGNyb21hdGl4LmNvbSIsInVwbiI6InZhZGltQGNyb21hdGl4LmNvbSIsInV0aSI6IlY4a2Z1SS1sTWsyVThWUnc2WDhNQWciLCJ2ZXIiOiIxLjAiLCJ3aWRzIjpbImM0ZTM5YmQ5LTExMDAtNDZkMy04YzY1LWZiMTYwZGEwMDcxZiIsIjg4ZDhlM2UzLThmNTUtNGExZS05NTNhLTliOTg5OGI4ODc2YiIsImYyOGExZjUwLWY2ZTctNDU3MS04MThiLTZhMTJmMmFmNmI2YyIsImZlOTMwYmU3LTVlNjItNDdkYi05MWFmLTk4YzNhNDlhMzhiMSIsIjliODk1ZDkyLTJjZDMtNDRjNy05ZDAyLWE2YWMyZDVlYTVjMyIsImNmMWMzOGU1LTM2MjEtNDAwNC1hN2NiLTg3OTYyNGRjZWQ3YyIsIjYyZTkwMzk0LTY5ZjUtNDIzNy05MTkwLTAxMjE3NzE0NWUxMCIsIjk2NjcwN2QwLTMyNjktNDcyNy05YmUyLThjM2ExMGYxOWI5ZCIsIjI5MjMyY2RmLTkzMjMtNDJmZC1hZGUyLTFkMDk3YWYzZTRkZSIsImI3OWZiZjRkLTNlZjktNDY4OS04MTQzLTc2YjE5NGU4NTUwOSJdLCJ4bXNfc3QiOnsic3ViIjoiWUU0MXQzam11NF9ZeWZSdldGZkpoZ0kwUmhyMzdtX2RZOTJUZ0FoSTFOTSJ9LCJ4bXNfdGNkdCI6MTU2NjE5MDI1OH0.hkajd1f7QaT7oJR4c1oPIYwLZS1jN5CwC2em0bEpD9OLHcabYKcHbBgj57p0XTp556pWJGTaHvfUWFJdWDt7WicvHmfkzqxoMQfch5gB-L1kqUoFewLJQAiUol1-kQN-xRg1XEi140GBKV-LzmkvgiCdsDjIlgxwFBiGCsXakfuD877xYoTmlSFwrOS0vLxNOa3xCZ0QsqA6RMKt9KSJJzdgAbtGXXsx18-L_9wiuv13rLhCkmG_wTu0DHBPCCEOhteiBoHjs1c4pWDwyV4VufbkjjmDx9NXW_YN9eqTwt5MctCWLEhNu3ICqSlUOuoQ_q7GGcnN87d-5lSBRxgqyQ";

            this.Execute();
        }

        public ICustomActivityResult Execute()
        {
            postData = GetBody();
            var response = ApiCAll();
            switch (response.StatusCode)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.OK:
                    {
                        if (string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result) == false)
                            return this.GenerateActivityResult(response.Content.ReadAsStringAsync().Result, Jsonkeypath);
                        else
                            return this.GenerateActivityResult("Success");
                    }
                default:
                    {
                        if (string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result) == false)
                            throw new Exception(response.Content.ReadAsStringAsync().Result);
                        else if (string.IsNullOrEmpty(response.ReasonPhrase) == false)
                            throw new Exception(response.ReasonPhrase);
                        else
                            throw new Exception(response.StatusCode.ToString());
                    }
            }
        }

        private HttpResponseMessage ApiCAll()
        {
            HttpClient client = new HttpClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            UriBuilder UriBuilder = new UriBuilder(endPoint);
            UriBuilder.Path = uriBuilderPath;
            HttpRequestMessage HttpRequestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), UriBuilder.ToString());

            if (contentType == "application/x-www-form-urlencoded")
                HttpRequestMessage.Content = AyehuHelper.formUrlEncodedContent(postData);
            else
            {
                if (string.IsNullOrEmpty(postData) == false)
                {
                    if (omitJsonEmptyorNull)
                        HttpRequestMessage.Content = new StringContent(AyehuHelper.omitJsonEmptyorNull(postData), Encoding.UTF8, "application/json");
                    else
                        HttpRequestMessage.Content = new StringContent(postData, Encoding.UTF8, contentType);
                }
            }

            foreach (KeyValuePair<string, string> headeritem in headers)
                client.DefaultRequestHeaders.Add(headeritem.Key, headeritem.Value);

            HttpResponseMessage response = client.SendAsync(HttpRequestMessage).Result;
            return response;
        }

        private bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private string GetBody()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{");

            sb.AppendLine(@" ""displayName"": """ + ruleDisplayName + @""",");
            sb.AppendLine(@" ""sequence"": 1,");
            sb.AppendLine(@" ""isEnabled"": true,");

            sb.AppendLine(@" ""conditions"": { ");
            if (!string.IsNullOrEmpty(senderContains))
            {
                sb.AppendLine(@" ""senderContains"": [""" + senderContains + @"""] ");
            }
            if (!string.IsNullOrEmpty(bodyContains))
            {
                sb.AppendLine(@" ""bodyContains"": [""" + bodyContains + @"""] ");
            }
            sb.AppendLine("},");

            if (action == "Forward")
            {
                if (string.IsNullOrEmpty(forwardEmail))
                    throw new Exception("forwardEmail field must be populated when forwardAction is set to True");

                sb.AppendLine(@" ""actions"": { ");
                sb.AppendLine(@" ""forwardTo"": [ ");
                sb.AppendLine("{");
                sb.AppendLine(@" ""emailAddress"": {");
                sb.AppendLine(@" ""address"":  """ + forwardEmail + @"""");
                sb.AppendLine("}");
                sb.AppendLine("}");
                sb.AppendLine("]");
                sb.AppendLine("}");
            }
            else if (deleteAction)
            {
                sb.AppendLine(@" ""actions"": { ");
                sb.AppendLine(@" ""delete"": true");
                sb.AppendLine("}");
            }

            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
