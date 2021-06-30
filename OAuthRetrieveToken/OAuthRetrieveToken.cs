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
		public string tokenURL;
		public string grantType;
		public string clientID;
		public string password;

		public ICustomActivityResult Execute()
		{
			string tokenContentType = "application/x-www-form-urlencoded";
			string tokenAccept = "application/json";
			string tokenMethod = "POST";
			string tokenResponseString;

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var tokenHttpWebRequest = (HttpWebRequest)WebRequest.Create(tokenURL);
				tokenHttpWebRequest.ContentType = tokenContentType;
				tokenHttpWebRequest.Accept = tokenAccept;
				tokenHttpWebRequest.Method = tokenMethod;

				using(var tokenStreamWriter = new StreamWriter(tokenHttpWebRequest.GetRequestStream()))
				{
					tokenStreamWriter.Write("grant_type=" + grantType + "&client_id=" + clientID + "&client_secret=" + password);
					tokenStreamWriter.Flush();
					tokenStreamWriter.Close();

					var tokenHttpResponse = (HttpWebResponse)tokenHttpWebRequest.GetResponse();

					using(var tokenStreamReader = new StreamReader(tokenHttpResponse.GetResponseStream()))
					{
						tokenResponseString = tokenStreamReader.ReadToEnd();
					}

					JObject jsonResults = JObject.Parse(tokenResponseString);

					string accessToken = (string)jsonResults.SelectToken(".access_token");

					return this.GenerateActivityResult(accessToken);
				}
			}
			catch(WebException e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}