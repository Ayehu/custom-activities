using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Net;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class  CustomActivity: IActivity
	{
		public string fileURL;
		public string savePath;

		public ICustomActivityResult Execute()
		{
			var result = "Success";

			try
			{
				WebClient wc = new WebClient();
				wc.DownloadFile(fileURL, savePath);
			}
			catch(WebException we)
			{
				result = "Error: " + we.ToString();
			}

			return this.GenerateActivityResult(result);
		}
	}
}
