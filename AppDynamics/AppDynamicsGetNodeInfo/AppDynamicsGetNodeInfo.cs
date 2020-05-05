using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AppDynamicsGetNodeInfo : IActivity
    {
        /// <summary>
        /// Tenant cloud full url. https://tenant-name.saas.appdynamics.com
        /// </summary>
        public string BaseURL;

        /// <summary>
        /// The name of the machine instance where the agent is running
        /// </summary>
        public string NodeName;

        /// <summary>
        /// API username. Format: tenant_name@application_name
        /// </summary>
        public string UserName;

        /// <summary>
        /// API password (client secret)
        /// </summary>
        public string Password;

        /// <summary>
        /// The tenant's application name 
        /// </summary>
        public string ApplicationName;

        public ICustomActivityResult Execute()
        {
            var restClient = new AppDynamicsRESTClient(UserName, Password);
            var parameters = restClient.GetParams(new Dictionary<string, string> {
                { "output", "JSON" } });
            string url = BaseURL + "/controller/rest/applications/" + ApplicationName + "/nodes/" + NodeName + "?" + parameters;
            var response = restClient.ApiCall(url, "GET");

            if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Response))
            {
                DataTable dt = new DataTable("resultSet");
                dt.Columns.Add("Id");
                dt.Columns.Add("Tier Name");
                dt.Columns.Add("Agent Type");
                dt.Columns.Add("Machine Name");
                dt.Columns.Add("OS Type");

                var jRes = JArray.Parse(response.Response);
                foreach (var j in jRes)
                {
                    dt.Rows.Add(j.Value<string>("id"),
                        j.Value<string>("tierName"),
                        j.Value<string>("agentType"),
                        j.Value<string>("machineName"),
                        j.Value<string>("machineOSType"));
                }

                return this.GenerateActivityResult(dt);
            }

            throw new Exception("Error retrieving Node Info. " + response.Response);
        }

        class AppDynamicsRESTClient
        {
            private string _userName;
            private string _password;
            private string authToken;

            public AppDynamicsRESTClient(string userName, string password)
            {
                _userName = userName;
                _password = password;
            }

            public ApiResponse ApiCall(string url, string method)
            {
                authToken = GenerateToken(url);
                return ApiCall(url, method, "application/x-www-form-urlencoded", null);
            }

            public ApiResponse ApiCall(string url, string method, string contentType, byte[] body)
            {
                HttpStatusCode statusCode = HttpStatusCode.NoContent;

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = method;
                    request.Accept = "*/*";
                    request.ContentType = contentType;

                    if (!string.IsNullOrEmpty(authToken))
                        request.Headers.Add("Authorization", "Bearer " + authToken);

                    if (body != null && body.Length > 0)
                    {
                        request.ContentLength = body.Length;
                        Stream input = request.GetRequestStream();
                        input.Write(body, 0, body.Length);
                    }

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    statusCode = response.StatusCode;

                    return new ApiResponse { StatusCode = statusCode, Response = reader.ReadToEnd() };
                }
                catch (Exception e)
                {
                    return new ApiResponse { StatusCode = statusCode, Response = e.Message };
                }
            }

            private string GenerateToken(string url)
            {
                string token = string.Empty;
                var uri = new Uri(url);
                var parameters = this.GetParams(new Dictionary<string, string> {
                    { "grant_type", "client_credentials" },
                    { "client_id", _userName },
                    { "client_secret", _password } });

                var body = ParamsToBytes(parameters);
                string tokenurl = uri.Scheme + "://" + uri.Host + "/controller/api/oauth/access_token";
                var response = ApiCall(tokenurl, "POST", "application/vnd.appd.cntrl+protobuf;v=1", body);

                if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Response))
                {
                    token = JObject.Parse(response.Response).GetValue("access_token").ToString();
                }

                return token;
            }

            private byte[] ParamsToBytes(string parameters)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                return encoding.GetBytes(parameters);
            }

            public string GetParams(Dictionary<string, string> parameters)
            {
                if (parameters != null)
                {
                    var ret = new List<string>();

                    foreach (KeyValuePair<string, string> pair in parameters)
                    {
                        string p = string.Format("{0}={1}",
                                                 HttpUtility.UrlEncode(pair.Key),
                                                 HttpUtility.UrlEncode(pair.Value));
                        ret.Add(p);
                    }

                    return string.Join("&", ret.ToArray());
                }

                return "";
            }
        }

        class ApiResponse
        {
            public string Response { get; set; }

            public HttpStatusCode StatusCode { get; set; }
        }
    }
}
