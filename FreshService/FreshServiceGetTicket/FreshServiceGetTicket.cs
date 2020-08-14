using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using System.IO;
using System.Net;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string instanceName;
		public string username;
		public string password;
		public string ticketID;

		public ICustomActivityResult Execute()
		{
			string apiURL = "https://" + instanceName + ".freshservice.com/api/v2/tickets/" + ticketID;
			string contentType = "application/json";
			string accept = "application/json";
			string method = "GET";
			String base64Credentials = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL);
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Accept = accept;
				httpWebRequest.Headers.Add("Authorization", "Basic " + base64Credentials);
				httpWebRequest.Method = method;

				var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

				using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					var responseString = streamReader.ReadToEnd();

					JObject jsonResults = JObject.Parse(responseString);

					JObject ticketData = JObject.Parse(jsonResults["ticket"].ToString());

					DataTable dt = new DataTable("resultSet");

					dt.Rows.Add(dt.NewRow());

					foreach(JProperty property in ticketData.Properties())
					{
						dt.Columns.Add(property.Name);

						dt.Rows[0][property.Name] = property.Value;
					}

					return this.GenerateActivityResult(dt);
				}
			}
			catch(WebException e)
			{
				return this.GenerateActivityResult("Error (" + e.Message + ")");
			}
		}
	}
}