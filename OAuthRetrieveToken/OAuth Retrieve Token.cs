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
		public string url;
		public string secretName;
		public string password;
		public string properties;
		public string headers;
		public string useSecret;

		public ICustomActivityResult Execute()
		{
			if(properties == "[]")
			{
				throw new Exception("One or more fields must be specified!");
			}

			string fieldBody = String.Empty;
			int fieldCount = 0;
			
			if(properties.Contains("[") && properties.Contains("]"))
			{
				properties = "{ \"root\": " + properties + " }";
			}
			else
			{
				properties = "{ \"root\": [ " + properties + " ] }";
			}

			JObject jsonTableProperties = JObject.Parse(properties);
			string jsonTableArrayStringProperties = jsonTableProperties["root"].ToString();
			JArray jsonTableArrayProperties = JsonConvert.DeserializeObject<JArray>(jsonTableArrayStringProperties);

			foreach(var itemProperties in jsonTableArrayProperties)
			{
				if(fieldCount > 0)
				{
					fieldBody += "&";
				}

				fieldBody += itemProperties["key"].ToString() + "=" + HttpUtility.UrlEncode(itemProperties["value"].ToString());
			}

			if(useSecret == "Yes")
			{
				fieldBody += "&" + secretName + "=" + password;
			}

			string tokenContentType = "application/x-www-form-urlencoded";
			string tokenAccept = "application/json";
			string tokenMethod = "POST";
			string tokenResponseString;

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var tokenHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
				tokenHttpWebRequest.ContentType = tokenContentType;
				tokenHttpWebRequest.Accept = tokenAccept;
				tokenHttpWebRequest.Method = tokenMethod;

				if(!String.IsNullOrEmpty(headers))
				{
					if(headers.Contains("[") && headers.Contains("]"))
					{
						headers = "{ \"root\": " + headers + " }";
					}
					else
					{
						headers = "{ \"root\": [ " + headers + " ] }";
					}

					JObject jsonTableHeaders = JObject.Parse(headers);
					string jsonTableArrayStringHeaders = jsonTableHeaders["root"].ToString();
					JArray jsonTableArrayHeaders = JsonConvert.DeserializeObject<JArray>(jsonTableArrayStringHeaders);

					foreach(var itemHeaders in jsonTableArrayHeaders)
					{
						tokenHttpWebRequest.Headers.Add(itemHeaders["key"].ToString(), itemHeaders["value"].ToString());
					}
				}

				using(var tokenStreamWriter = new StreamWriter(tokenHttpWebRequest.GetRequestStream()))
				{
					tokenStreamWriter.Write(fieldBody);
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