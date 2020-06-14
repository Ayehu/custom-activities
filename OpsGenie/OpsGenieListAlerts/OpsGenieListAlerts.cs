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
		public string apiKey;
		public string maxResults;
		public string pageNumber;
		public string orderBy;
		public string sortBy;

		public ICustomActivityResult Execute()
		{
			int offset = (Int32.Parse(pageNumber) - 1) * Int32.Parse(maxResults);

			string apiURL = "https://api.opsgenie.com/v2/alerts?limit=" + maxResults + "&offset=" + offset.ToString() + "&order=" + orderBy + "&sort=" + sortBy;
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
					var responseString = streamReader.ReadToEnd();

					JObject jsonResults = JObject.Parse(responseString);

					JArray alerts = (JArray)jsonResults["data"];

					int alertCount = alerts.Count;

					if(alertCount == 0)
					{
						return this.GenerateActivityResult("Empty");
					}
					else
					{
						DataTable dt = new DataTable("resultSet");

						for(int i = 0; i < alertCount; i ++)
						{
							dt.Rows.Add(dt.NewRow());

							JObject alertDetails = JObject.Parse(jsonResults["data"][i].ToString());

							foreach(JProperty property in alertDetails.Properties())
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