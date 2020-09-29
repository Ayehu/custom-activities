using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using System.IO;
using System.Net;
using System.Web;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string vaultServer;
		public string protocolType;
		public string apiToken;
		public string secretName;
		public string itemName;
		public string dataText;
        public string key1;
        public string key2;
        public string value1;
        public string value2;
		
		
		public ICustomActivityResult Execute()
		{
			string apiURL = protocolType + "://" + vaultServer + ":8200/v1/" + secretName + "/" + itemName;
			string contentType = "application/json";
			string accept = "application/json";
			string method = "POST";
			string jsonBody = "{\""+key1+"\":\""+value1+"\","+"\""+key2+"\":\""+value2+"\"}";
			
            
			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL);
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Accept = accept;
				httpWebRequest.Headers.Add("X-Vault-Token", apiToken);
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
                    
                         responseString=responseString.ToString().ToLower();
                    
					     if(responseString.Contains("error"))
					     {
						       return this.GenerateActivityResult("Error (" + httpResponse.StatusCode.ToString() + ")");
					     }
					     else
					     {
                               return this.GenerateActivityResult("Success");
						     
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
