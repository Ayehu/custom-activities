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
    public class AppDynamicsGetEventData : IActivity
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
        /// Time in minutes to go in the past from now.
        /// </summary>
        public string DurationInMin;

        public ICustomActivityResult Execute()
        {
            var restClient = new AppDynamicsRESTClient(UserName, Password);
            var parameters = restClient.GetParams(new Dictionary<string, string> {
                { "time-range-type", "BEFORE_NOW" },
                { "duration-in-mins", DurationInMin },
                { "event-types", "ACTIVITY_TRACE,ADJUDICATION_CANCELLED,AGENT_ADD_BLACKLIST_REG_LIMIT_REACHED,AGENT_ASYNC_ADD_REG_LIMIT_REACHED,AGENT_DIAGNOSTICS,AGENT_ERROR_ADD_REG_LIMIT_REACHED,AGENT_EVENT," +
                                 "AGENT_METRIC_BLACKLIST_REG_LIMIT_REACHED,AGENT_METRIC_REG_LIMIT_REACHED,AGENT_STATUS,ALREADY_ADJUDICATED,APPDYNAMICS_DATA,APPDYNAMICS_INTERNAL_DIAGNOSTICS,AZURE_AUTO_SCALING," +
                                 "CONTROLLER_ASYNC_ADD_REG_LIMIT_REACHED,CONTROLLER_COLLECTIONS_ADD_REG_LIMIT_REACHED,CONTROLLER_ERROR_ADD_REG_LIMIT_REACHED,CONTROLLER_EVENT_UPLOAD_LIMIT_REACHED," +
                                 "CONTROLLER_MEMORY_ADD_REG_LIMIT_REACHED,CONTROLLER_METADATA_REGISTRATION_LIMIT_REACHED,CONTROLLER_METRIC_DATA_BUFFER_OVERFLOW,CONTROLLER_METRIC_REG_LIMIT_REACHED," +
                                 "CONTROLLER_PSD_UPLOAD_LIMIT_REACHED,CONTROLLER_RSD_UPLOAD_LIMIT_REACHED,CONTROLLER_SEP_ADD_REG_LIMIT_REACHED,CONTROLLER_STACKTRACE_ADD_REG_LIMIT_REACHED," +
                                 "CONTROLLER_TRACKED_OBJECT_ADD_REG_LIMIT_REACHED,CUSTOM,CUSTOM_ACTION_END,CUSTOM_ACTION_FAILED,CUSTOM_ACTION_STARTED,CUSTOM_EMAIL_ACTION_END,CUSTOM_EMAIL_ACTION_FAILED," +
                                 "CUSTOM_EMAIL_ACTION_STARTED,DEV_MODE_CONFIG_UPDATE,DIAGNOSTIC_SESSION,EMAIL_ACTION_FAILED,EMAIL_SENT,EUM_CLOUD_BROWSER_EVENT," +
                                 "EUM_CLOUD_SYNTHETIC_BROWSER_EVENT,EUM_INTERNAL_ERROR,HTTP_REQUEST_ACTION_END,HTTP_REQUEST_ACTION_FAILED,HTTP_REQUEST_ACTION_STARTED,INFO_INSTRUMENTATION_VISIBILITY," +
                                 "INTERNAL_UI_EVENT,MEMORY,MEMORY_LEAK_DIAGNOSTICS,MOBILE_CRASH_IOS_EVENT,MOBILE_CRASH_ANDROID_EVENT,NORMAL,OBJECT_CONTENT_SUMMARY,POLICY_CANCELED_CRITICAL,POLICY_CANCELED_WARNING," +
                                 "POLICY_CLOSE_CRITICAL,POLICY_CLOSE_WARNING,POLICY_CONTINUES_CRITICAL,POLICY_CONTINUES_WARNING,POLICY_DOWNGRADED,POLICY_OPEN_CRITICAL,POLICY_OPEN_WARNING,POLICY_UPGRADED," +
                                 "RESOURCE_POOL_LIMIT,RUN_LOCAL_SCRIPT_ACTION_END,RUN_LOCAL_SCRIPT_ACTION_FAILED,RUN_LOCAL_SCRIPT_ACTION_STARTED,SERVICE_ENDPOINT_DISCOVERED,SLOW,SMS_SENT,STALL," +
                                 "SYSTEM_LOG,THREAD_DUMP_ACTION_END,THREAD_DUMP_ACTION_FAILED,THREAD_DUMP_ACTION_STARTED,TIER_DISCOVERED,VERY_SLOW,WARROOM_NOTE" },
                { "severities", "INFO,WARN,ERROR" },
                { "output", "JSON" } });

            string url = BaseURL + "/controller/rest/applications/" + ApplicationName + "/events?" + parameters;
            var response = restClient.ApiCall(url, "GET");

            if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Response))
            {
                DataTable dt = new DataTable("resultSet");
                dt.Columns.Add("Id");
                dt.Columns.Add("Severity");
                dt.Columns.Add("Summary");
                dt.Columns.Add("Type");
                dt.Columns.Add("EventTime");

                var jRes = JArray.Parse(response.Response);
                foreach (var j in jRes)
                {
                    dt.Rows.Add(j.Value<string>("id"), 
                        j.Value<string>("severity"), 
                        j.Value<string>("summary"), 
                        j.Value<string>("type"),
                        new DateTime(1970, 1, 1).AddMilliseconds(j.Value<long>("eventTime")).ToString()); // convert from epoch time
                }

                return this.GenerateActivityResult(dt);
            }

            throw new Exception("Error retrieving Event Data. " + response.Response);
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
