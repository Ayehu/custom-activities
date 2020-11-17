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
using System.Linq;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureVMGetCpuUsage : IActivity
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
        /// The authentication token
        /// </summary>
        public string token_password;

        /// <summary>
        /// Resource Group where the VM belongs to 
        /// </summary>
        public string resourceGroupName;

        //private string authToken;
        private string managenentBaseURL = "https://management.azure.com";

        public ICustomActivityResult Execute()
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("%Used");

            //string authURL = string.Format("https://login.microsoftonline.com/{0}/oauth2/token", //tenantId);
            //authToken = GenerateToken(authURL);
            double percentage = GetCPUUsage();

            dt.Rows.Add(percentage);
            return this.GenerateActivityResult(dt);
        }

       private double GetCPUUsage()
        {
            string managementURL = string.Format("{0}/subscriptions/{1}/resourceGroups/{2}/" +
                "providers/Microsoft.Compute/virtualMachines/{3}/providers/microsoft.insights/metrics?" +
                "api-version=2018-01-01&metricnames=Percentage%20CPU", managenentBaseURL, subscriptionId, resourceGroupName, vmName);
            var response = ApiCall(managementURL, "GET", "", null);

            if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Response))
            {
                var data = ((JArray)JObject.Parse(response.Response)["value"][0]["timeseries"][0]["data"]).Reverse();
                var average = data.Where(x => x["average"] != null).Select(x => x["average"]).FirstOrDefault();

                if (average != null)
                { 
                    return average.Value<double>();
                }
            }

            return 0d; //  In case there's enough metrics, return 0
        }

        private ApiResponse ApiCall(string url, string method, string contentType, byte[] body)
        {
            HttpStatusCode statusCode = HttpStatusCode.NoContent;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                request.Accept = "*/*";

                if (!string.IsNullOrEmpty(contentType))
                    request.ContentType = contentType;

                if (!string.IsNullOrEmpty(token_password))
                    request.Headers.Add("Authorization", "Bearer " + token_password);

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
