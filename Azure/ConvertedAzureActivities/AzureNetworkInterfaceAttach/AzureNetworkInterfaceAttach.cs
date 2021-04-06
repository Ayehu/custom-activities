using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureNetworkInterfaceAttach : IActivity
    {
        /// <summary>
        /// The azure portal subscription Id
        /// </summary>
        public string subscriptionId;

        /// <summary>
        /// Virtual Machine name
        /// </summary>
        public string vmName;

        /// <summary>
        /// Network Interface name
        /// </summary>
        public string networkName;

        public string resourceGroupName;
        public string authToken_password;
        public string api_version = "2020-11-01";
        public string Jsonkeypath = "";


        private bool omitJsonEmptyorNull = false;
        private string contentType = "application/json";
        private string endPoint = "https://management.azure.com";
        private string httpMethod = "PUT";
        private string _uriBuilderPath;
        private string _postData;

        private Dictionary<string, string> _headers;
        private Dictionary<string, string> _queryStringArray;

        private string uriBuilderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_uriBuilderPath))
                {
                    _uriBuilderPath = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/networkInterfaces/{2}/", subscriptionId, resourceGroupName, networkName);
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

        private enum VMState
        {
            NA,
            Start,
            Dealllocate,
            Started,
            Dealllocated,
        }

        public ICustomActivityResult Execute()
        {
            if (SetVMState(VMState.Dealllocate))
            {
                int retries = 300;
                while (GetVMState() == VMState.Started && retries > 0)
                {
                    retries = retries - 1;
                    System.Threading.Thread.Sleep(1000);
                }

                try
                {
                    var response = AttachNetworkInterface();

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
                finally
                {
                    SetVMState(VMState.Start);
                }
            }
            else
            {
                throw new Exception("Error attaching Network Interface");
            }
        }

        private bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private HttpResponseMessage ApiCAll(string uri)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            UriBuilder UriBuilder = new UriBuilder(endPoint);
            UriBuilder.Path = uri;//uriBuilderPath;
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

        private HttpResponseMessage AttachNetworkInterface()
        {
            postData = GetVirtualMachineNetworkProfile();
            httpMethod = "PATCH";
            api_version = "2020-12-01";
            _queryStringArray = new Dictionary<string, string>() { { "api-version", api_version } };
            uriBuilderPath = string.Format("subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Compute/virtualMachines/{2}", subscriptionId, resourceGroupName, vmName);
            return ApiCAll(uriBuilderPath);
        }

        private string GetVirtualMachineNetworkProfile()
        {
            postData = "";
            httpMethod = "GET";
            api_version = "2020-12-01";
            string uri = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Compute/virtualMachines/{2}", subscriptionId, resourceGroupName, vmName);
            var response = ApiCAll(uri);

            string interfaceId = GetInterfaceIdByName();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                JArray networkProfile = (JArray)json["properties"]["networkProfile"]["networkInterfaces"];

                if (!string.IsNullOrEmpty(interfaceId))
                {
                    networkProfile.Add(new JObject { { "id", interfaceId }, { "properties", new JObject { { "primary", false } } } });
                }

                return @"{""properties"": {""networkProfile"":" + json["properties"]["networkProfile"].ToString() + "}}";
            }

            return string.Empty;
        }

        private string GetInterfaceIdByName()
        {
            postData = "";
            httpMethod = "GET";
            api_version = "2020-11-01";
            _queryStringArray = new Dictionary<string, string>() { { "api-version", api_version } };
            string uri = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/networkInterfaces/{2}", subscriptionId, resourceGroupName, networkName);
            var response = ApiCAll(uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JObject.Parse(response.Content.ReadAsStringAsync().Result)["id"].ToString();
            }

            return string.Empty;
        }

        private bool SetVMState(VMState state)
        {
            postData = "";
            httpMethod = "POST";
            api_version = "2020-12-01";
            _queryStringArray = new Dictionary<string, string>() { { "api-version", api_version } };

            string vmState = state == VMState.Start ? "start" : "deallocate";

            string uri = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Compute/virtualMachines/{2}/{3}", subscriptionId, resourceGroupName, vmName, vmState);
            var response = ApiCAll(uri);

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted)
            {
                return true;
            }

            return false;
        }

        private VMState GetVMState()
        {
            SetVMState(VMState.Dealllocate);

            postData = "";
            httpMethod = "GET";
            api_version = "2020-12-01";
            _queryStringArray = new Dictionary<string, string>() { { "api-version", api_version } };

            string uri = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Compute/virtualMachines/{2}/instanceView", subscriptionId, resourceGroupName, vmName);
            var response = ApiCAll(uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string state = JObject.Parse(response.Content.ReadAsStringAsync().Result)["statuses"][1]["code"].ToString();

                if (state == "PowerState/deallocated")
                {
                    return VMState.Dealllocated;
                }

                return VMState.Started;
            }

            return VMState.NA;
        }
    }
}
