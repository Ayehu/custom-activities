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
    public class OktaListUser : IActivity
    {
        #region Private readonly properties

        private readonly string API_REQUEST_URL = "{0}/api/v1/users?filter=status+eq+\"{1}\"&limit={2}";
        private readonly string NO_FILTER_API_REQUEST_URL = "{0}/api/v1/users?limit={1}";
        private readonly string CONTENT_TYPE = "application/json";
        private readonly string ACCEPT = "application/json";
        private readonly string METHOD = "GET";
        public readonly int LIMIT = 200;

        #endregion

        #region Incoming properties 

        public string AuthorizationToken;
        public string Domain;

        public string Filter;

        #endregion

        #region Public methods

        public ICustomActivityResult Execute()
        {
            var httpWebRequest = HttpRequest();

            HttpWebResponse httpResponse = null;
            try
            {
                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (WebException ex)
            {
                using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    var responseString = streamReader.ReadToEnd();
                    var error_messageerrorSummary = ExposeJson(JObject.Parse(responseString), "error_message")["errorSummary"];
                    throw new Exception(error_messageerrorSummary);
                }
            }
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var response = streamReader.ReadToEnd();

                    List<string> userDataKeys = new List<string>();
                    var jArray = JArray.Parse(response);

                    if (jArray.Children().Count() == 0)
                    {
                        return this.GenerateActivityResult("No data returned");
                    }

                    var userList = new List<IReadOnlyDictionary<string, string>>();

                    foreach (var jToken in jArray)
                    {
                        var res = ExposeJson(jToken.ToObject<JObject>(), "_links");
                        if (userDataKeys.Count == 0)
                        {
                            userDataKeys.AddRange(res.Keys);
                        }

                        var data = res.ToDictionary(x => x.Key, x => x.Value);
                        userList.Add(data as IReadOnlyDictionary<string, string>);
                    }

                    var dt = GetDataTable(userList.AsEnumerable(), userDataKeys);

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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.IsNullOrWhiteSpace(Filter) ? string.Format(NO_FILTER_API_REQUEST_URL, Domain, LIMIT) : string.Format(API_REQUEST_URL, Domain, Filter, LIMIT));
            httpWebRequest.ContentType = CONTENT_TYPE;
            httpWebRequest.Accept = ACCEPT;
            httpWebRequest.Headers.Add("Authorization", string.Format("SSWS {0}", AuthorizationToken));
            httpWebRequest.Method = METHOD;

            return httpWebRequest;
        }

        private IDictionary<string, string> ExposeJson(JObject jObject, string search_till, string append = "")
        {
            var result = new Dictionary<string, string>();

            foreach (var jProperty in jObject.Properties())
            {
                if (append + jProperty.Name == search_till)
                {
                    continue;
                }

                var jToken = jProperty.Value;

                if (jToken.Type == JTokenType.Object)
                {
                    var nested_result = ExposeJson(jToken as JObject, search_till, append + jProperty.Name + "_");

                    if (nested_result == null)
                    {
                        return result;
                    }
                    result = result.Concat(nested_result).ToDictionary(q => q.Key, q => q.Value);
                }
                else if (jToken.Type != JTokenType.Array)
                {
                    result.Add(append + jProperty.Name, jProperty.Value.ToString());
                }
            }

            return result;
        }

        private DataTable GetDataTable(IEnumerable<IReadOnlyDictionary<string, string>> columns, IEnumerable<string> keys)
        {
            DataTable dt = new DataTable("resultSet");

            foreach (var column in keys)
            {
                dt.Columns.Add(column);
            }

            foreach (var item in columns)
            {
                var row = dt.NewRow();

                foreach (var col in item)
                {
                    row[col.Key] = col.Value;
                }

                dt.Rows.Add(row);
            }

            return dt;
        }

        #endregion
    }
}