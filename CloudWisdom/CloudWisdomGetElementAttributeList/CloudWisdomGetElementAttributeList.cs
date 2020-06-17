using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Data;
using System.IO;
using System.Net;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string username;
		public string password;
		public string elementID;

		public ICustomActivityResult Execute()
		{
			string encodedCredentials = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
			string apiURL = "https://app.metricly.com/elements/" + elementID;
			string contentType = "application/json";
			string accept = "application/json";
			string method = "GET";

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL);
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Accept = accept;
				httpWebRequest.Headers.Add("Authorization", "Basic " + encodedCredentials);
				httpWebRequest.Method = method;

				var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

				using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					var responseString = streamReader.ReadToEnd();

					JObject jsonResults = JObject.Parse(responseString);
					
					JArray attributes = (JArray)jsonResults["element"]["attributes"];

					int attributeCount = attributes.Count;

					if(attributeCount == 0)
					{
						return this.GenerateActivityResult("Empty");
					}
					else
					{
						string attributeName = "";
						string attributeValue = "";

						DataTable dt = new DataTable("resultSet");

						dt.Rows.Add(dt.NewRow());
						
						for(int i = 0; i < attributeCount; i ++)
						{
							attributeName = jsonResults["element"]["attributes"][i]["name"].ToString();
							attributeValue = jsonResults["element"]["attributes"][i]["value"].ToString();

							if(!dt.Columns.Contains(attributeName))
							{
								dt.Columns.Add(attributeName);
							}

							dt.Rows[0][attributeName] = attributeValue;
						}

						return this.GenerateActivityResult(dt);
					}
				}
			}
			catch(WebException e)
			{
				return this.GenerateActivityResult("Error (" + e.Message + ")");
			}
		}
	}
}