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
		public string username;
		public string password;
		public string attachmentID;
		public string attachmentFilename;
		public string savePath;
		public string customFilename;
		public int customFilenameBoolean;

		public ICustomActivityResult Execute()
		{
			try
			{
				WebClient wc = new WebClient();

				wc.Headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
				wc.Headers["X-Atlassian-Token"] = "nocheck";

				string apiURL = instanceURL + "/secure/attachment/" + attachmentID + "/" + attachmentFilename;
				
				if(customFilenameBoolean == 1)
				{
					savePath += "/" + customFilename;
				}
				else
				{
					savePath += "/" + attachmentFilename;
				}

				wc.DownloadFile(apiURL, savePath);

				return this.GenerateActivityResult("Success");
			}
			catch(WebException we)
			{
				throw new Exception(we.Message);
			}
		}
	}
}