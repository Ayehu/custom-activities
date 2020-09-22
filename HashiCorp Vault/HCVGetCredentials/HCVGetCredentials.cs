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
		public string vaultServer;
		public string protocolType;
		public string apiToken;
		public string secretName;
		public string itemName;
		
		public ICustomActivityResult Execute()
		{
			string apiURL = protocolType + "://" + vaultServer + ":8200/v1/" + secretName + "/" + itemName;
			string contentType = "application/json";
			string accept = "application/json";
			string method = "GET";

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL);
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Accept = accept;
				httpWebRequest.Headers.Add("X-Vault-Token", apiToken);
				httpWebRequest.Method = method;

				var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

				using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					var responseString = streamReader.ReadToEnd();

					JObject jsonResults = JObject.Parse(responseString);

					JObject credentialInfo = JObject.Parse(jsonResults["data"].ToString());

					DataTable dt = new DataTable("resultSet");

					dt.Rows.Add(dt.NewRow());

					foreach(JProperty property in credentialInfo.Properties())
					{
						dt.Columns.Add(property.Name);

						dt.Rows[0][property.Name] = property.Value;
					}

					return this.GenerateActivityResult(dt);
				}
			}
			catch(WebException e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}