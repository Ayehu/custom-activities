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
	public class CustomActivity: IActivity
	{
		public string instanceURL;
		public string tenantID;
		public string username;
		public string password;
		public string recordType;
		public string recordNumber;

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

			string apiURL = instanceURL + "/rest/" + tenantID + "/ems/" + recordType + "/" + recordNumber + "/?layout=RequestAttachments";
			string contentType = "application/json";
			string accept = "application/json";
			string method = "GET";

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

				var httpWebRequest = (HttpWebRequest) WebRequest.Create(apiURL);
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Accept = accept;
				httpWebRequest.Headers.Add("Cookie", "LWSSO_COOKIE_KEY=" + tokenResponseString);
				httpWebRequest.Method = method;

				var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();

				using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					var response = streamReader.ReadToEnd();

					JObject jsonResults = JObject.Parse(response);

					string jsonEncoded = jsonResults["entities"][0]["properties"]["RequestAttachments"].ToString();

					JObject jsonAttachments = JObject.Parse(jsonEncoded);

					JArray attachments = (JArray) jsonAttachments["complexTypeProperties"];

					int attachmentCount = attachments.Count;

					if (attachmentCount == 0)
					{
						return this.GenerateActivityResult("No attachments found.");
					}
					else
					{
						DataTable dt = new DataTable("resultSet");

						for (int i = 0; i < attachmentCount; i++)
						{
							dt.Rows.Add(dt.NewRow());

							JObject attachmentDetails = JObject.Parse(jsonAttachments["complexTypeProperties"][i]["properties"].ToString());

							foreach(JProperty property in attachmentDetails.Properties())
							{
								if (!dt.Columns.Contains(property.Name))
								{
									dt.Columns.Add(property.Name);
								}

								dt.Rows[i][property.Name] = property.Value;
							}
						}

						return this.GenerateActivityResult(dt);
					}
				}
			}
			catch (WebException e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}
