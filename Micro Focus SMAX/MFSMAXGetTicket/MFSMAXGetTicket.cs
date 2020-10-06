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
	public class CustomActivity: IActivity
	{
		public string instanceURL;
		public string tenantID;
		public string username;
		public string password;
		public string recordType;
		public string fields;
		public string recordNumber;

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

				var tokenHttpWebRequest = (HttpWebRequest) WebRequest.Create(tokenURL);
				tokenHttpWebRequest.ContentType = tokenContentType;
				tokenHttpWebRequest.Accept = tokenAccept;
				tokenHttpWebRequest.Method = tokenMethod;

				using(var tokenStreamWriter = new StreamWriter(tokenHttpWebRequest.GetRequestStream()))
				{
					tokenStreamWriter.Write(tokenJsonBody);
					tokenStreamWriter.Flush();
					tokenStreamWriter.Close();

					var tokenHttpResponse = (HttpWebResponse) tokenHttpWebRequest.GetResponse();

					using(var tokenStreamReader = new StreamReader(tokenHttpResponse.GetResponseStream()))
					{
						tokenResponseString = tokenStreamReader.ReadToEnd();
					}
				}
			}
			catch (WebException e)
			{
				throw new Exception(e.Message);
			}

			string apiURL = instanceURL + "/rest/" + tenantID + "/ems/" + recordType + "/" + recordNumber + "/?layout=" + fields;
			string contentType = "application/json";
			string accept = "application/json";
			string method = "GET";

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

				var httpWebRequest = (HttpWebRequest) WebRequest.Create(apiURL);
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Accept = accept;
				httpWebRequest.Headers.Add("Cookie", "LWSSO_COOKIE_KEY=" + tokenResponseString);
				httpWebRequest.Method = method;

				var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();

				using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					var response = streamReader.ReadToEnd();

					JObject jsonResults = JObject.Parse(response);
					JArray records = (JArray) jsonResults["entities"];

					int recordCount = records.Count;

					DataTable dt = new DataTable("resultSet");
					DataTable dt2 = new DataTable("resultSet");

					for (int i = 0; i < recordCount; i++)
					{
						var recordData = jsonResults["entities"][i]["properties"].ToString();
						var res = ExposeJson(JObject.Parse(recordData))
							.ToDictionary(q => q.Key, q => q.Value);
						dt.Merge(GetDataTable(res));

						var recordData2 = jsonResults["entities"][i]["related_properties"].ToString();
						var res2 = ExposeJson(JObject.Parse(recordData2))
							.ToDictionary(q => q.Key, q => q.Value);
						dt2.Merge(GetDataTable(res2));
					}

					int rowCount = 0;

					foreach(DataRow row in dt2.Rows)
					{
						foreach(DataColumn col in dt2.Columns)
						{
							if (!dt.Columns.Contains(col.ToString()))
							{
								dt.Columns.Add(col.ToString());
							}

							dt.Rows[rowCount][col.ToString()] = row[col].ToString();
						}

						rowCount++;
					}

					return this.GenerateActivityResult(dt);
				}
			}
			catch (WebException e)
			{
				throw new Exception(e.Message);
			}
		}

		private IDictionary < string, string > ExposeJson(JObject jObject, string append = "")
		{
			var result = new Dictionary < string,
				string > ();

			foreach(var jProperty in jObject.Properties())
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

		private DataTable GetDataTable(IReadOnlyDictionary < string, string > columns)
		{
			DataTable dt = new DataTable("resultSet");
			dt.Rows.Add(dt.NewRow());

			foreach(var col in columns)
			{
				dt.Columns.Add(col.Key);
				dt.Rows[0][col.Key] = col.Value;
			}

			return dt;
		}
	}
}
