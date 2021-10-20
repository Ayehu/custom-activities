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
		public string apiURL;
		public string password;
		public string sourceLanguage;
		public string targetLanguage;
		public string text;
		public string formality;
		public int detectLanguage;

		public ICustomActivityResult Execute()
		{
			apiURL += "?auth_key=" + password + "&target_lang=" + targetLanguage + "&formality=" + formality;

			if(detectLanguage == 0)
			{
				apiURL += "&source_lang=" + sourceLanguage;
			}

			apiURL += "&text=" + HttpUtility.UrlEncode(text);

			string contentType = "application/x-www-form-urlencoded";
			string accept = "application/json";
			string method = "GET";

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var apiHttpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL);
				apiHttpWebRequest.ContentType = contentType;
				apiHttpWebRequest.Accept = accept;
				apiHttpWebRequest.Method = method;

				var httpResponse = (HttpWebResponse)apiHttpWebRequest.GetResponse();

				using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					var responseBody = streamReader.ReadToEnd();

					JObject jsonResults = JObject.Parse(responseBody);

					return this.GenerateActivityResult(jsonResults["translations"][0]["text"].ToString());
				}
			}
			catch(WebException e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}