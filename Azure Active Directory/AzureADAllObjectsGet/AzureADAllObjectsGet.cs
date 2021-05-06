using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Data;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureADAllObjectsGet : IActivity
    {

        public string groupId;

        public string accessToken = "";

        public string accessTokenVM = "";

        public string subscriptionId = "";

        public string Jsonkeypath = "";

        public string typeId;

        private bool omitJsonEmptyorNull = false;

        private string contentType = "application/json";

        private string endPoint = "https://graph.microsoft.com";

        private string httpMethod = "GET";

        private string _uriBuilderPath;

        private string _postData;

        private System.Collections.Generic.Dictionary<string, string> _headers;

        private System.Collections.Generic.Dictionary<string, string> _queryStringArray;

        private string uriBuilderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_uriBuilderPath))
                {
                    _uriBuilderPath = "";
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
            HttpResponseMessage virtualMachinesResponse;
            HttpResponseMessage groupsResponse;
            HttpResponseMessage usersResponse;

            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Id");
            dt.Columns.Add("Type");
            dt.Columns.Add("Member Name");
            dt.Columns.Add("Member Details");
            switch (typeId)
            {
                case "user":
                    {
                        _headers = new Dictionary<string, string>() { { "authorization", "Bearer " + accessToken } };
                        uriBuilderPath = "/v1.0/users";
                        usersResponse = ApiCall();
                        using (StreamReader sr = new StreamReader(usersResponse.Content.ReadAsStreamAsync().Result))
                        {
                            var json = (JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());
                            var users = json.Value<JToken>("value");
                            foreach(var user in users)
                            {
                                string id = user.Value<string>("id");
                                string type = "User";
                                string displayName = user.Value<string>("displayName");
                                string memberDetails = user.Value<string>("userPrincipalName");
                                dt.Rows.Add(id, type, displayName, memberDetails);
                            }
                        }
                            break;
                    }
                case "group":
                    {
                        _headers = new Dictionary<string, string>() { { "authorization", "Bearer " + accessToken } };
                        uriBuilderPath = "/v1.0/groups";
                        groupsResponse = ApiCall();
                        using (StreamReader sr = new StreamReader(groupsResponse.Content.ReadAsStreamAsync().Result))
                        {
                            var json = (JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());
                            var groups = json.Value<JToken>("value");
                            foreach (var group in groups)
                            {
                                string id = group.Value<string>("id");
                                string type = "Group";
                                string displayName = group.Value<string>("displayName");
                                string memberDetails = Convert.ToBoolean(group.Value<string>("securityEnabled")) ? "SecurityGroup" : "Office365";
                                dt.Rows.Add(id, type, displayName, memberDetails);
                            }
                        }
                        break;
                    }
                case "vm":
                    {
                        uriBuilderPath = string.Format("subscriptions/{0}/providers/Microsoft.Compute/virtualMachines", subscriptionId);
                        queryStringArray = new Dictionary<string, string>()
                        {
                            {"api-version", "2020-12-01" }
                        };
                        endPoint = "https://management.azure.com/";
                       _headers = new Dictionary<string, string>() { { "authorization", "Bearer " + accessTokenVM } };
                        virtualMachinesResponse = ApiCall();
                        using (StreamReader sr = new StreamReader(virtualMachinesResponse.Content.ReadAsStreamAsync().Result))
                        {
                            var json = (JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());
                            var virtualMachines = json.Value<JToken>("value");
                            foreach (var virtualMachine in virtualMachines)
                            {
                                string id = virtualMachine.Value<string>("id");
                                string type = "Virtual Machine";
                                string displayName = virtualMachine.Value<string>("name");
                                string memberDetails = virtualMachine.Value<string>("type");
                                dt.Rows.Add(id, type, displayName, memberDetails);
                            }
                        }
                        break;
                    }
                default:
                    {
                        _headers = new Dictionary<string, string>() { { "authorization", "Bearer " + accessToken } };
                        uriBuilderPath = "/v1.0/users";
                        usersResponse = ApiCall();
                        using (StreamReader sr = new StreamReader(usersResponse.Content.ReadAsStreamAsync().Result))
                        {
                            var json = (JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());
                            var users = json.Value<JToken>("value");
                            foreach (var user in users)
                            {
                                string id = user.Value<string>("id");
                                string type = "User";
                                string displayName = user.Value<string>("displayName");
                                string memberDetails = user.Value<string>("userPrincipalName");
                                dt.Rows.Add(id, type, displayName, memberDetails);
                            }
                        }

                        uriBuilderPath = "/v1.0/groups";
                        groupsResponse = ApiCall();
                        using (StreamReader sr = new StreamReader(groupsResponse.Content.ReadAsStreamAsync().Result))
                        {
                            var json = (JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());
                            var groups = json.Value<JToken>("value");
                            foreach (var group in groups)
                            {
                                string id = group.Value<string>("id");
                                string type = "Group";
                                string displayName = group.Value<string>("displayName");
                                string memberDetails = Convert.ToBoolean(group.Value<string>("securityEnabled")) ? "SecurityGroup" : "Office365";
                                dt.Rows.Add(id, type, displayName, memberDetails);
                            }
                        }
                        endPoint = "https://management.azure.com/";
                        queryStringArray = new Dictionary<string, string>()
                        {
                            {"api-version", "2020-12-01" }
                        };
                        _headers = new Dictionary<string, string>() { { "authorization", "Bearer " + accessTokenVM } };
                        uriBuilderPath = string.Format("subscriptions/{0}/providers/Microsoft.Compute/virtualMachines", subscriptionId);
                        virtualMachinesResponse = ApiCall();
                        using (StreamReader sr = new StreamReader(virtualMachinesResponse.Content.ReadAsStreamAsync().Result))
                        {
                            var json = (JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());
                            var virtualMachines = json.Value<JToken>("value");
                            foreach (var virtualMachine in virtualMachines)
                            {
                                string id = virtualMachine.Value<string>("id");
                                string type = "Virtual Machine";
                                string displayName = virtualMachine.Value<string>("name");
                                string memberDetails = virtualMachine.Value<string>("type");
                                dt.Rows.Add(id, type, displayName, memberDetails);
                            }
                        }
                        break;
                    }
            }

            return this.GenerateActivityResult(dt);
        }

        private HttpResponseMessage ApiCall()
        {
            HttpClient client = new HttpClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            UriBuilder UriBuilder = new UriBuilder(endPoint);
            UriBuilder.Path = uriBuilderPath;
            UriBuilder.Query = AyehuHelper.queryStringBuilder(queryStringArray);
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
                            return response;
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


        private bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
