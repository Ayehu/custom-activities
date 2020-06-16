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
    public class AppDynamicsCreateEvent : IActivity
    {
        /// <summary>
        /// Tenant cloud full url. https://tenant-name.saas.appdynamics.com
        /// </summary>
        public string BaseURL;

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

        /// <summary>
        /// A brief summary of the created to describe the created Event
        /// </summary>
        public string Summary;

        /// <summary>
        /// Comments on the Event
        /// </summary>
        public string Comment;

        /// <summary>
        /// Severity of the event (INFO, WARN, ERROR)
        /// </summary>
        public string Severity;

        public ICustomActivityResult Execute()
        {
            var restClient = new AppDynamicsRESTClient(UserName, Password);
            var parameters = restClient.GetParams(new Dictionary<string, string> {
                { "summary", Summary },
                { "comment", Comment },
                { "severity", Severity },
                { "eventtype", "CUSTOM" },
                { "output", "JSON" } });
            string url = BaseURL + "/controller/rest/applications/" + ApplicationName + "/events?" + parameters;
            var response = restClient.ApiCall(url, "POST");

            if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Response))
            {
                return this.GenerateActivityResult(GetActivityResult("Success"));
            }

            throw new Exception("Error creating event. " + response.Response);
        }

        private DataTable GetActivityResult(string response)
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");
            dt.Rows.Add(response);

            return dt;
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
