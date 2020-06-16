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
		public string username;
		public string password;

		public ICustomActivityResult Execute()
		{
			String encodedCredentials = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
			string apiURL = "https://us.cloudwisdom.virtana.com/reports";
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

					JArray reports = (JArray)jsonResults["reports"];

					int reportCount = reports.Count;

					if(reportCount == 0)
					{
						return this.GenerateActivityResult("Empty");
					}
					else
					{
						DataTable dt = new DataTable("resultSet");

						for(int i = 0; i < reportCount; i ++)
						{
							dt.Rows.Add(dt.NewRow());

							JObject reportDetails = JObject.Parse(jsonResults["reports"][i].ToString());

							foreach(JProperty property in reportDetails.Properties())
							{
								if(!dt.Columns.Contains(property.Name))
								{
									dt.Columns.Add(property.Name);
								}

								dt.Rows[i][property.Name] = property.Value;
							}
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