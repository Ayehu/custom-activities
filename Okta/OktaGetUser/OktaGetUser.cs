using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Data;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Ayehu.Sdk.ActivityCreation
{
    public class OktaGetUser : IActivity
    {
        #region Private readonly properties

        private readonly string API_REQUEST_URL = "{0}/api/v1/users/{1}";
        private readonly string CONTENT_TYPE = "application/json";
        private readonly string ACCEPT = "application/json";
        private readonly string METHOD = "GET";

        #endregion

        #region Incoming properties 

        public string AuthorizationToken;
        public string Domain;

        public string UserId;

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
                    List<string> userDataKeys = new List<string>() { "id", "profile_firstName", "profile_lastName", "profile_email" };
                    var res = ExposeJson(JObject.Parse(response));
                    var data = res.Where(r => userDataKeys.Any(u => u == r.Key))
                                  .ToDictionary(x => x.Key, x => x.Value); 
                    var dt = GetDataTable(data as Dictionary<string, string>);

                    return this.GenerateActivityResult(dt);
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(API_REQUEST_URL, Domain, UserId));
            httpWebRequest.ContentType = CONTENT_TYPE;
            httpWebRequest.Accept = ACCEPT;
            httpWebRequest.Headers.Add("Authorization", string.Format("SSWS {0}", AuthorizationToken));
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
                    var nested_result = ExposeJson(jToken as JObject, append + jProperty.Name + "_");
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