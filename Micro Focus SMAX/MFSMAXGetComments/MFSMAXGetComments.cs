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
using System.Web;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string instanceURL;
		public string tenantID;
		public string username;
		public string password;
		public string recordType;
		public string ticketNumber;
		public string commentType;

		public ICustomActivityResult Execute()
		{
			string tokenURL = instanceURL + "/auth/authentication-endpoint/authenticate/login?TENANTID=" + tenantID;
			string tokenContentType = "application/json";
			string tokenAccept = "application/json";
			string tokenMethod = "POST";
			string tokenJsonBody = "{\"login\":\"" + HttpUtility.JavaScriptStringEncode(username) + "\",\"password\":\"" + HttpUtility.JavaScriptStringEncode(password) + "\"}";
			string tokenResponseString;

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var tokenHttpWebRequest = (HttpWebRequest)WebRequest.Create(tokenURL);
				tokenHttpWebRequest.ContentType = tokenContentType;
				tokenHttpWebRequest.Accept = tokenAccept;
				tokenHttpWebRequest.Method = tokenMethod;

				using(var tokenStreamWriter = new StreamWriter(tokenHttpWebRequest.GetRequestStream()))
				{
					tokenStreamWriter.Write(tokenJsonBody);
					tokenStreamWriter.Flush();
					tokenStreamWriter.Close();

					var tokenHttpResponse = (HttpWebResponse)tokenHttpWebRequest.GetResponse();

					using(var tokenStreamReader = new StreamReader(tokenHttpResponse.GetResponseStream()))
					{
						tokenResponseString = tokenStreamReader.ReadToEnd();
					}
				}
			}
			catch(WebException e)
			{
				throw new Exception(e.Message);
			}

			string apiURL = instanceURL + "/rest/" + tenantID + "/collaboration/comments/" + recordType + "/" + ticketNumber;

			if(commentType != "ALL")
			{
				apiURL += "?PrivacyType=" + commentType;
			}

			string contentType = "application/json";
			string accept = "application/json";
			string method = "GET";

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL);
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Accept = accept;
				httpWebRequest.Headers.Add("Cookie", "LWSSO_COOKIE_KEY=" + tokenResponseString);
				httpWebRequest.Method = method;

				var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

				using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					var response = streamReader.ReadToEnd();

					response = "{\"root\":" + response + "}";

					JObject jsonResults = JObject.Parse(response);
					JArray comments = (JArray)jsonResults["root"];

					int commentCount = comments.Count;

					DataTable dt = new DataTable("resultSet");

					for(int i = 0; i < commentCount; i ++)
					{
						var commentData = jsonResults["root"][i].ToString();
	                    var res = ExposeJson(JObject.Parse(commentData))
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