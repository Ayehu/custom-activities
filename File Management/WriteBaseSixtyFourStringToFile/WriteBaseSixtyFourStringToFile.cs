using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.IO;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class  CustomActivity: IActivity
	{
		public string savePath;
		public string base64String;
        
		public ICustomActivityResult Execute()
		{
			try
			{
				File.WriteAllBytes(savePath, Convert.FromBase64String(base64String));

				return this.GenerateActivityResult("Success");
			}
			catch(Exception we)
			{
				throw new Exception("Error: " + we.Message);
			}
		}
	}
}