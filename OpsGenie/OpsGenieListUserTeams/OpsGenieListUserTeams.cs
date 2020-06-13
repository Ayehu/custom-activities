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
		public string userName;
		public string teamName;

		public ICustomActivityResult Execute()
		{
			string apiURL = "https://api.opsgenie.com/v2/users/" + userName + "/teams";
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

					JArray teams = (JArray)jsonResults["data"];

					int teamCount = teams.Count;

					if(teamCount == 0)
					{
						return this.GenerateActivityResult("Empty");
					}
					else
					{
						DataTable dt = new DataTable("resultSet");

						dt.Rows.Add(dt.NewRow());
						
						dt.Columns.Add("id");
						dt.Columns.Add("name");

						for(int i = 0; i < teamCount; i ++)
						{
							dt.Rows[i]["id"] = (string)jsonResults["data"][i]["id"];
							dt.Rows[i]["name"] = (string)jsonResults["data"][i]["name"];
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