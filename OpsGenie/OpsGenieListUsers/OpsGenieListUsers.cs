using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Linq;
using System.Net;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string apiKey;
		public string maxResults;
		public string pageNumber;
		public string orderBy;

		public ICustomActivityResult Execute()
		{
			int offset = (Int32.Parse(pageNumber) - 1) * Int32.Parse(maxResults);

			string apiURL = "https://api.opsgenie.com/v2/users?limit=" + maxResults + "&offset=" + offset.ToString() + "&order=" + orderBy;
			string contentType = "application/json";
			string accept = "application/json";
			string method = "GET";

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL);
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Accept = accept;
				httpWebRequest.Headers.Add("Authorization", "GenieKey " + apiKey);
				httpWebRequest.Method = method;

				var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

				using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					var response = streamReader.ReadToEnd();

					JObject jsonResults = JObject.Parse(response);

					JArray users = (JArray)jsonResults["data"];

					int userCount = users.Count;

					DataTable dt = new DataTable("resultSet");

					for(int i = 0; i < userCount; i ++)
					{
						var userData = jsonResults["data"][i].ToString();

	                    var res = ExposeJson(JObject.Parse(userData))
	                                .ToDictionary(q => q.Key, q => q.Value);

	                    dt.Merge(GetDataTable(res));
	                }

                    return this.GenerateActivityResult(dt);
				}
			}
			catch(WebException e)
			{
				throw new Exception(e.Message);
			}
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
	}
}