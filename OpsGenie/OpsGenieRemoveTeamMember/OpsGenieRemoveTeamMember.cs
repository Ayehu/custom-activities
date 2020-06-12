using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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
			string apiURL = "https://api.opsgenie.com/v2/teams/" + teamName + "/members/" + userName + "?teamIdentifierType=name";
			string contentType = "application/json";
			string accept = "application/json";
			string method = "DELETE";

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

					if(jsonResults["result"].ToString() == "Removed")
					{
						return this.GenerateActivityResult("Success");
					}
					else
					{
					return this.GenerateActivityResult("Failure: " + jsonResults["result"].ToString());
					}
				}
			}
			catch(WebException e)
			{
				return this.GenerateActivityResult("Error: " + e.Message);
			}
		}
	}
}
