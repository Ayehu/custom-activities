using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Text;
using System.IO;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class  CustomActivity: IActivity
	{
		public string fullPath;
		public string osMode;
		public string parseMode;

		public ICustomActivityResult Execute()
		{
			string finalResult = "";

			if(parseMode == "Filename")
			{
				finalResult = Path.GetFileName(fullPath);
			}
			else if(parseMode == "Folder")
			{
				finalResult = Path.GetDirectoryName(fullPath);
			}
			
			if(osMode == "Linux/UNIX" && parseMode == "Folder")
			{
				finalResult = finalResult.Replace("\\", "/");
			}

			return this.GenerateActivityResult(finalResult);
		}
	}
}