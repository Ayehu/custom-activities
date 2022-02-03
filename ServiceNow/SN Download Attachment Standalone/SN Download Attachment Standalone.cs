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
		public string savePath;
		public string fileName;

		public ICustomActivityResult Execute()
		{
			try
			{
				WebClient wc = new WebClient();

				wc.Headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
				wc.Headers["Accept"] = "*/*";

				string apiURL = instanceURL + "/api/now/attachment/" + attachmentID + "/file";

				wc.DownloadFile(apiURL, savePath + "/" + fileName);

				return this.GenerateActivityResult("Success");
			}
			catch(WebException we)
			{
				throw new Exception(we.Message);
			}
		}
	}
}