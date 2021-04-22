using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureRoleAssignmentCreate : IActivity
    {
        public string resourceGroupName;
        public string roleName;
        public string principalId;
        public string subscriptionId;
        public string resourceName;
        public string authToken_password;
        public string api_version;
        public string Jsonkeypath = "";

        private bool omitJsonEmptyorNull = false;
        private string contentType = "application/json";
        private string endPoint = "https://management.azure.com";
        private string httpMethod = "PUT";
        private string _postData;

        private Dictionary<string, string> _headers;
        private Dictionary<string, string> _queryStringArray;


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

        private Dictionary<string, string> queryStringArray
        {
            get
            {
                if (_queryStringArray == null)
                {
                    _queryStringArray = new Dictionary<string, string>() { { "api-version", api_version } };
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
            string origApiVersion = api_version;
            string resourceType = GetResource();
            string roleDefinition = GetRoledefinition();
            queryStringArray = null;
            api_version = origApiVersion;
            
            httpMethod = "PUT";
            string uri = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/{2}/providers/Microsoft.Authorization/roleAssignments/{3}", subscriptionId, resourceGroupName, resourceType, principalId);
            postData = "{\"properties\":{\"roleDefinitionId\": \"" + roleDefinition + "\",\"principalId\": \"" + principalId + "\"}}";
            var response = ApiCAll(uri);

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

        private HttpResponseMessage ApiCAll(string url)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            UriBuilder UriBuilder = new UriBuilder(endPoint);
            UriBuilder.Path = url;
            UriBuilder.Query = AyehuHelper.queryStringBuilder(queryStringArray);
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

        private string GetRoledefinition()
        {
            string resourceType = GetResource();

            if (string.IsNullOrEmpty(resourceType))
                throw new Exception(string.Format("Resource name '{0}' not found", resourceName));

            queryStringArray = null;
            api_version = "2018-07-01";
            httpMethod = "GET";
            string uri = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/{2}/providers/Microsoft.Authorization/roleDefinitions", subscriptionId, resourceGroupName, resourceType);
            var response = ApiCAll(uri);

            switch (response.StatusCode)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.OK:
                    {
                        JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                        JArray values = (JArray)json["value"];

                        foreach (var res in values)
                        {
                            if (res["properties"]["roleName"] != null && res["properties"]["roleName"].ToString().ToLower() == roleName.ToLower())
                            {
                                return res["id"].ToString();
                            }
                        }

                        return null;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        private string GetResource()
        {
            httpMethod = "GET";
            api_version = "2021-04-01";
            string uri = string.Format("/subscriptions/{0}/resources", subscriptionId);
            var response = ApiCAll(uri);

            switch (response.StatusCode)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.OK:
                    {
                        JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                        JArray values = (JArray)json["value"];

                        foreach (var res in values)
                        {
                            if (res["name"] != null && res["name"].ToString().ToLower() == resourceName.ToLower())
                            {
                                return res["type"].ToString() + "/" + resourceName;
                            }
                        }

                        return null;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
