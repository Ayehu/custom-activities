using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;

namespace Ayehu.Sdk.ActivityCreation
{
    public class IncidentGet : IActivity
    {
        #region Private readonly properties

        private readonly string API_REQUEST_URL = "https://api.pagerduty.com/incidents";
        private readonly string CONTENT_TYPE = "application/json";
        private readonly string ACCEPT = "application/vnd.pagerduty+json;version=2";
        private readonly string METHOD = "GET";

        #endregion

        #region Incoming properties 

        public string AuthorizationToken;
        public string Id;

        #endregion

        #region Public methods

        public ICustomActivityResult Execute()
        {
            var httpWebRequest = HttpRequest();

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var response = streamReader.ReadToEnd();

                    var res = ExposeJson(JObject.Parse(response))
                                .SkipWhile(q => q.Key != "service_summary")
                                .ToDictionary(q => q.Key, q => q.Value);

                    var dt = GetDataTable(res);

                    return this.GenerateActivityResult(response);
                }
            }
            else
            {
                throw new Exception("Error");
            }
        }

        #endregion

        #region Private methods 

        private WebRequest HttpRequest()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}/{1}", API_REQUEST_URL, Id));
            httpWebRequest.ContentType = CONTENT_TYPE;
            httpWebRequest.Accept = ACCEPT;
            httpWebRequest.Headers.Add("Authorization", string.Format("Token token={0}", AuthorizationToken));
            httpWebRequest.Method = METHOD;

            return httpWebRequest;
        }

        private IDictionary<string, string> ExposeJson(JObject jObject, string append = "")
        {
            var result = new Dictionary<string, string>();

            foreach (var jProperty in jObject.Properties())
            {
                var jToken = jProperty.Value;

                if (jToken.Type == JTokenType.Object)
                {
                    var nested_result = ExposeJson(jToken as JObject, jProperty.Name + "_");
                    result = result.Concat(nested_result).ToDictionary(q => q.Key, q => q.Value);
                }
                else if (jToken.Type != JTokenType.Array)
                {
                    result.Add(append + jProperty.Name, jProperty.Value.ToString());
                }
            }

            return result;
        }

        private DataTable GetDataTable(IReadOnlyDictionary<string, string> columns)
        {
            DataTable dt = new DataTable("resultSet");
            dt.Rows.Add(dt.NewRow());

            foreach (var col in columns)
            {
                dt.Columns.Add(col.Key);
                dt.Rows[0][col.Key] = col.Value;
            }

            return dt;
        }

        #endregion
    }
}
