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
		public string fullName;
		public string skypeUsername;
		public string userRole;
		public string timeZone;
		public string locale;
		public string addressCountry;
		public string addressState;
		public string addressCity;
		public string address;
		public string addressZipCode;

		public ICustomActivityResult Execute()
		{
			string apiURL = "https://api.opsgenie.com/v2/users";
			string contentType = "application/json";
			string accept = "application/json";
			string method = "POST";
			string jsonBody = "{\"username\":\""  + userName + "\",\"fullName\": \"" + fullName + "\",\"skypeUsername\": \"" + skypeUsername + "\",\"role\": {\"name\": \"" + userRole + "\"},\"timeZone\": \"" + timeZone + "\",\"locale\": \"" + locale + "\",\"userAddress\": {\"country\": \"" + addressCountry + "\",\"state\": \"" + addressState + "\",\"city\": \"" + addressCity + "\",\"line\": \"" + address + "\",\"zipCode\": \"" + addressZipCode + "\"}}";

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL);
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Accept = accept;
				httpWebRequest.Headers.Add("Authorization", "GenieKey " + apiKey);
				httpWebRequest.Method = method;

				using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					streamWriter.Write(jsonBody);
					streamWriter.Flush();
					streamWriter.Close();

					var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

					using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
					{
						var responseString = streamReader.ReadToEnd();

						JObject jsonResults = JObject.Parse(responseString);
						
						string result = jsonResults["result"].ToString();

						if(result == "Created")
						{
							return this.GenerateActivityResult("Success");
						}
						else
						{
							return this.GenerateActivityResult("Failure (" + result + ")");
						}
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