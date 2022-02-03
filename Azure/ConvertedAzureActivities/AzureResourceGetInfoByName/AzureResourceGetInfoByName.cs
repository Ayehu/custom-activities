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
    public class AzureResourceGetInfoByName : IActivity
    {
        public string subscriptionId;
        public string resourceName;
        public string authToken_password;
        public string api_version;
        public string Jsonkeypath = "";

        private bool omitJsonEmptyorNull = false;
        private string contentType = "application/json";
        private string endPoint = "https://management.azure.com";
        private string httpMethod = "GET";
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
                    _uriBuilderPath = string.Format("/subscriptions/{0}/resources", subscriptionId);
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

        public ICustomActivityResult Execute()
        {
            var resourceId = GetResourceId();

            if (resourceId != null)
            {
                _queryStringArray = null;
                api_version = "2020-11-01";
                string url = string.Format("/{0}", resourceId);
                var response = ApiCAll(url);

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

            throw new Exception("Resource not found");
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

        private string GetResourceId()
        {
            var response = ApiCAll(uriBuilderPath);

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
    }
}
