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

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureADRoleAssignmentCreate : IActivity
    {
        public string roleId = "";

        public string objectName = "";

        public string accessToken = "";

        public string Jsonkeypath = "";

        private bool omitJsonEmptyorNull = false;

        private string contentType = "application/json";

        private string endPoint = "https://graph.microsoft.com";

        private string httpMethod = "GET";

        private string _uriBuilderPath;

        private string query = "";

        private string objectId = null;

        private string _postData;

        private System.Collections.Generic.Dictionary<string, string> _headers;

        private System.Collections.Generic.Dictionary<string, string> _queryStringArray;

        private string uriBuilderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_uriBuilderPath))
                {
                    _uriBuilderPath = string.Format("/v1.0/users");
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
            query = string.Format("$filter=userPrincipalName+eq+\'{0}\'", objectName);
            var userResponse = ApiCall();
            if (string.IsNullOrEmpty(userResponse.Content.ReadAsStringAsync().Result) == false)
            {
                using (StreamReader sr = new StreamReader(userResponse.Content.ReadAsStreamAsync().Result))
                {
                    var json = (JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());
                    var user = json.Value<JToken>("value").First;
                    if (user != null)
                    {
                        objectId = user.Value<string>("id");
                    }
                }
            }
            if(objectId == null)
            {
                uriBuilderPath = "/v1.0/groups";
                query = string.Format("$filter=displayName+eq+\'{0}\'", objectName);
                var groupResponse = ApiCall();

                if (string.IsNullOrEmpty(groupResponse.Content.ReadAsStringAsync().Result) == false)
                {
                    using (StreamReader sr = new StreamReader(groupResponse.Content.ReadAsStreamAsync().Result))
                    {
                        var json = (JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());
                        var group = json.Value<JToken>("value").First;
                        if (group != null)
                        {
                            objectId = group.Value<string>("id");
                        }
                    }
                }
            }

            if(objectId == null)
            {
                throw new Exception(string.Format("Active Directory object '{0}' not found.", objectName));
            }
            else
            {
                httpMethod = "POST";
                uriBuilderPath = string.Format("v1.0/directoryRoles/roleTemplateId={0}/members/$ref", roleId);

                postData = GetBodyData();
                query = "";
                var response = ApiCall();

                if (string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result) == false && string.IsNullOrEmpty(Jsonkeypath) == false && Jsonkeypath != "$")
                    return this.GenerateActivityResult(response.Content.ReadAsStringAsync().Result, Jsonkeypath);
                else
                    return this.GenerateActivityResult("Success");
            }

        }

        private HttpResponseMessage ApiCall()
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

        private string GetBodyData()
        {
            return "{\r\n  \"@odata.id\": \"https://graph.microsoft.com/v1.0/directoryObjects/" + objectId + "\"\r\n}";
        }

        private bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
