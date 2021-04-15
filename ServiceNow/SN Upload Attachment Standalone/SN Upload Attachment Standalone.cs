using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using System.Linq;
using System.IO;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string instanceURL;
		public string username;
		public string password;
		public string tableType;
		public string ticketNumber;
		public string filePath;

		public ICustomActivityResult Execute()
		{
			string ticketSysID = String.Empty;

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
				
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(instanceURL + "/api/now/table/" + tableType + "?sysparm_query=number=" + ticketNumber);
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Accept = "application/json";
				httpWebRequest.Headers.Add("Authorization", "Basic " + System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password)));
				httpWebRequest.Method = "GET";

				var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

				using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					var response = streamReader.ReadToEnd();

					JObject jsonResults = JObject.Parse(response);
					JArray ticketResults = (JArray)jsonResults["result"];

					int ticketCount = ticketResults.Count;

					if(ticketCount == 0)
					{
						throw new Exception("Error: Ticket number not found.");
					}
					else
					{
						ticketSysID = jsonResults["result"][0]["sys_id"].ToString();
					}
				}
			}
			catch(WebException e)
			{
				throw new Exception(e.Message);
			}

			var httpClientHandler = new HttpClientHandler()
			{
				Credentials = new NetworkCredential(username, password),
			};

			using (var httpClient = new HttpClient(httpClientHandler))
			{
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var fileStream = new ByteArrayContent(File.ReadAllBytes(filePath));
				fileStream.Headers.Remove("Content-Type");
				fileStream.Headers.Add("Content-Type", "application/octet-stream");
				fileStream.Headers.Add("Content-Transfer-Encoding", "binary");
				fileStream.Headers.Add("Content-Disposition", "form-data;name=\"uploadFile\"; filename=\"" + Path.GetFileName(filePath) + "\"");

				var multipartContent = new MultipartFormDataContent();
				multipartContent.Add(new StringContent(tableType), "\"table_name\"");
				multipartContent.Add(new StringContent(ticketSysID), "\"table_sys_id\"");
				multipartContent.Add(fileStream, "uploadFile");

				var response = httpClient.PostAsync(new Uri(instanceURL + "/api/now/attachment/upload"), multipartContent).Result;
				string result = response.Content.ReadAsStringAsync().Result;
				int resultCode = (int)response.StatusCode;

				if(response.StatusCode.ToString() != "Created")
				{
					throw new Exception("Error " + resultCode + ": " + response.StatusCode.ToString());
				}
				else
				{
					return this.GenerateActivityResult("Success");
				}
			}
		}
	}
}