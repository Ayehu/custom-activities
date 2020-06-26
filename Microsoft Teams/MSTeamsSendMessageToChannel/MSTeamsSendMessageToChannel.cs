using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string webhookURL;
		public string messageText;

		public ICustomActivityResult Execute()
		{
			string apiURL = webhookURL;
			string contentType = "application/json";
			string accept = "application/json";
			string method = "POST";
			string jsonBody = "{\"text\":\"" + HttpUtility.JavaScriptStringEncode(messageText) + "\"}";

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL);
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Accept = accept;
				httpWebRequest.Method = method;

				using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					streamWriter.Write(jsonBody);
					streamWriter.Flush();
					streamWriter.Close();

					var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

					if(httpResponse.StatusCode.ToString() == "OK")
					{
						return this.GenerateActivityResult("Success");
					}
					else
					{
						return this.GenerateActivityResult("Error (" + httpResponse.StatusCode.ToString() + ")");
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