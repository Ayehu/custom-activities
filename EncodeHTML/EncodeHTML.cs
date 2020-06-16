using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Text;
using System.Web;
using System.IO;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class  CustomActivity: IActivity
	{
		public string plaintextString;

		public ICustomActivityResult Execute()
		{
			var result = HttpUtility.HtmlEncode(plaintextString);
			
			return this.GenerateActivityResult(result);
		}
	}
}