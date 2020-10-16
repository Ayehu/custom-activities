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
	public class CustomActivity : IActivity
	{
		public string instanceURL;
		public string username;
		public string apiToken;
		public string issueType;
		public string ticketNumber;
		public string filePath;

		public ICustomActivityResult Execute()
		{
			try
			{
				issueType = issueType.ToLower();
				
				WebClient wc = new WebClient();
				
				wc.Headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + apiToken));
				wc.Headers["X-Atlassian-Token"] = "nocheck";

				string apiURL = instanceURL + "/" + issueType + "/" + ticketNumber + "/attachments";

				wc.UploadFile(apiURL, "POST", filePath);

				wc.Dispose();

				return this.GenerateActivityResult("Success");
			}
			catch(WebException we)
			{
				throw new Exception(we.Message);
			}
		}
	}
}