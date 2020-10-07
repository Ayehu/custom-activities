using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
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
	public class CustomActivity: IActivity
	{
		public string instanceURL;
		public string tenantID;
		public string username;
		public string password;
		public string attachmentID;
		public string savePath;

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

				var tokenHttpWebRequest = (HttpWebRequest) WebRequest.Create(tokenURL);
				tokenHttpWebRequest.ContentType = tokenContentType;
				tokenHttpWebRequest.Accept = tokenAccept;
				tokenHttpWebRequest.Method = tokenMethod;

				using(var tokenStreamWriter = new StreamWriter(tokenHttpWebRequest.GetRequestStream()))
				{
					tokenStreamWriter.Write(tokenJsonBody);
					tokenStreamWriter.Flush();
					tokenStreamWriter.Close();

					var tokenHttpResponse = (HttpWebResponse) tokenHttpWebRequest.GetResponse();

					using(var tokenStreamReader = new StreamReader(tokenHttpResponse.GetResponseStream()))
					{
						tokenResponseString = tokenStreamReader.ReadToEnd();
					}
				}
			}
			catch (WebException e)
			{
				throw new Exception(e.Message);
			}

			string downloadURL = instanceURL + "/rest/" + tenantID + "/ces/attachment/" + attachmentID;

			try
			{
				WebClient wc = new WebClient();

				wc.Headers["Cookie"] = "LWSSO_COOKIE_KEY=" + tokenResponseString;

				wc.DownloadFile(downloadURL, savePath);

				return this.GenerateActivityResult("Success");
			}
			catch (WebException we)
			{
				throw new Exception(we.Message);
			}
		}
	}
}
