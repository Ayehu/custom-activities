using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureADGroupCreate : IActivity
    {

        public string groupName = "";

        public string groupDescription = "";

        public string mailNickname = "";

        public string accessToken = "";

        public string Jsonkeypath = "";

        private bool omitJsonEmptyorNull = false;
        
        private bool mailEnabled = false;

        private bool securityEnabled = true;

        private string contentType = "application/json";

        private string endPoint = "https://graph.microsoft.com";

        private string httpMethod = "GET";

        private string _uriBuilderPath;

        private string query = "";

        private string _postData;

        private System.Collections.Generic.Dictionary<string, string> _headers;

        private System.Collections.Generic.Dictionary<string, string> _queryStringArray;

        private string uriBuilderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_uriBuilderPath))
                {
                    _uriBuilderPath = string.Format("/v1.0/groups");
                }
                return _uriBuilderPath;
            }
            set
            {
                this._uriBuilderPath = value;
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
                this._postData = value;
            }
        }

        private System.Collections.Generic.Dictionary<string, string> headers
        {
            get
            {
                if (_headers == null)
                {
                    _headers = new Dictionary<string, string>() { { "authorization", "Bearer " + accessToken } };
                }
                return _headers;
            }
            set
            {
                this._headers = value;
            }
        }

        private System.Collections.Generic.Dictionary<string, string> queryStringArray
        {
            get
            {
                if (_queryStringArray == null)
                {
                    _queryStringArray = new Dictionary<string, string>();
                }
                return _queryStringArray;
            }
            set
            {
                this._queryStringArray = value;
            }
        }

        public ICustomActivityResult Execute()
        {
            query = string.Format("$filter=displayName+eq+\'{0}\'", groupName);
            var group =  ApiCall();
            if(group.Contains("\"value\":[]"))
            {
                query = "";
                httpMethod = "POST";
                postData = GetBodyData();
                var createdGroup = ApiCall();
                if(string.IsNullOrEmpty(createdGroup) == false && string.IsNullOrEmpty(Jsonkeypath) == false && Jsonkeypath != "$")
                {
                    return this.GenerateActivityResult(createdGroup, Jsonkeypath);
                }
                else
                {
                    return this.GenerateActivityResult("Success");
                }
            }
            else
            {
                throw new Exception(string.Format("Group with name '{0}' already exist.", groupName));
            }
        }

        private string ApiCall()
        {
            HttpClient client = new HttpClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            UriBuilder UriBuilder = new UriBuilder(endPoint);
            UriBuilder.Path = uriBuilderPath;
            UriBuilder.Query = query;
            HttpRequestMessage myHttpRequestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), UriBuilder.ToString());

            if (contentType == "application/x-www-form-urlencoded")
                myHttpRequestMessage.Content = AyehuHelper.formUrlEncodedContent(postData);
            else
              if (string.IsNullOrEmpty(postData) == false)
                if (omitJsonEmptyorNull)
                    myHttpRequestMessage.Content = new StringContent(AyehuHelper.omitJsonEmptyorNull(postData), Encoding.UTF8, "application/json");
                else
                    myHttpRequestMessage.Content = new StringContent(postData, Encoding.UTF8, contentType);


            foreach (KeyValuePair<string, string> headeritem in headers)
                client.DefaultRequestHeaders.Add(headeritem.Key, headeritem.Value);

            HttpResponseMessage response = client.SendAsync(myHttpRequestMessage).Result;

            switch (response.StatusCode)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.OK:
                    {
                        if (string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result) == false)
                            return response.Content.ReadAsStringAsync().Result;
                        else
                            return "";
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

        public string GetBodyData()
        {
return "{\r\n  \"description\": \"" + groupDescription + "\",\r\n  \"displayName\": \"" + groupName + "\",\r\n \"mailEnabled\":" + mailEnabled.ToString().ToLower() + ",\r\n \"mailNickname\": \"" + mailNickname + "\",\r\n  \"securityEnabled\":" + securityEnabled.ToString().ToLower() + "\r\n}";
        }

        private bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
