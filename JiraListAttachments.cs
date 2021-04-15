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
		public string username;
		public string apiToken;
		public string ticketNumber;

		public ICustomActivityResult Execute()
		{
			string apiURL = instanceURL + "/issue/" + ticketNumber + "?fields=attachment";
			string contentType = "application/json";
			string accept = "application/json";
			string method = "GET";

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL);
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Accept = accept;
				httpWebRequest.Headers.Add("Authorization", "Basic " + System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + apiToken)));
				httpWebRequest.Method = method;

				var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

				using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					var response = streamReader.ReadToEnd();

					JObject jsonResults = JObject.Parse(response);
					JArray attachments = (JArray)jsonResults["fields"]["attachment"];

					int attachmentCount = attachments.Count;

					DataTable dt = new DataTable("resultSet");

					for(int i = 0; i < attachmentCount; i ++)
					{
						var attachmentData = jsonResults["fields"]["attachment"][i].ToString();
						var res = ExposeJson(JObject.Parse(attachmentData))
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