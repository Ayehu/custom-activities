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
		public string instanceURL;
		public string tenantID;
		public string username;
		public string password;
		public string recordType;
		public string recordNumber;
		public string fieldName;
		public string fieldValue;

		public ICustomActivityResult Execute()
		{
			string tokenURL = instanceURL + "/auth/authentication-endpoint/authenticate/login?TENANTID=" + tenantID;
			string tokenContentType = "application/json";
			string tokenAccept = "application/json";
			string tokenMethod = "POST";
			string tokenJsonBody = "{\"login\":\"" + HttpUtility.JavaScriptStringEncode(username) + "\",\"password\":\"" + HttpUtility.JavaScriptStringEncode(password) + "\"}";
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
					tokenStreamWriter.Write(tokenJsonBody);
					tokenStreamWriter.Flush();
					tokenStreamWriter.Close();

					var tokenHttpResponse = (HttpWebResponse)tokenHttpWebRequest.GetResponse();

					using(var tokenStreamReader = new StreamReader(tokenHttpResponse.GetResponseStream()))
					{
						tokenResponseString = tokenStreamReader.ReadToEnd();
					}
				}
			}
			catch(WebException e)
			{
				throw new Exception(e.Message);
			}

			string apiURL = instanceURL + "/rest/" + tenantID + "/ems/bulk";
			string contentType = "application/json";
			string accept = "application/json";
			string method = "POST";
			string jsonBody = "{\"entities\":[{\"entity_type\":\"" + recordType + "\",\"properties\":{\"Id\":\"" + recordNumber + "\",\"" + fieldName + "\":\"" + HttpUtility.JavaScriptStringEncode(fieldValue) + "\"}}],\"operation\":\"UPDATE\"}";

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL);
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Accept = accept;
				httpWebRequest.Headers.Add("Cookie", "LWSSO_COOKIE_KEY=" + tokenResponseString);
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
						
						string result = jsonResults["meta"]["completion_status"].ToString();

						if(result == "OK")
						{
							return this.GenerateActivityResult("Success");
						}
						else
						{
							throw new Exception(result);
						}
					}
				}
			}
			catch(WebException e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}