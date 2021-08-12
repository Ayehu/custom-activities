using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Data;
using System.Web;
using System.Net;
using System.IO;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class  CustomActivity: IActivity
	{
		public string instanceURL;
		public string tenantID;
		public string username;
		public string password;
		public string recordType;
		public string properties;
		
		public ICustomActivityResult Execute()
		{
			if(properties == "[]")
			{
				throw new Exception("One or more ticket properties must be specified!");
			}

			string ticketJson = String.Empty;
			
			if(properties.Contains("[") && properties.Contains("]"))
			{
				properties = "{ \"root\": " + properties + " }";
			}
			else
			{
				properties = "{ \"root\": [ " + properties + " ] }";
			}

			JObject jsonTable = JObject.Parse(properties);
			string jsonTableArrayString = jsonTable["root"].ToString();
			JArray jsonTableArray = JsonConvert.DeserializeObject<JArray>(jsonTableArrayString);

			foreach(var item in jsonTableArray)
			{
				ticketJson += "\"" + item["key"].ToString() + "\": \"" + HttpUtility.JavaScriptStringEncode(item["value"].ToString()) + "\",";
			}

			ticketJson = ticketJson.Substring(0, (ticketJson.Length - 1));
			ticketJson = "{ \"entities\": [ { \"entity_type\": \"" + recordType + "\", \"properties\": { " + ticketJson + "} } ], \"operation\": \"CREATE\" }";

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
					streamWriter.Write(ticketJson);
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
							return this.GenerateActivityResult(jsonResults["entity_result_list"][0]["entity"]["properties"]["Id"].ToString());
						}
						else
						{
							throw new Exception(result + " (ERROR " + jsonResults["entity_result_list"][0]["errorDetails"]["httpStatus"].ToString() + "):\n" + jsonResults["entity_result_list"][0]["errorDetails"]["message"].ToString() + "\n" + jsonResults["entity_result_list"][0]["errorDetails"]["message_key"].ToString());
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