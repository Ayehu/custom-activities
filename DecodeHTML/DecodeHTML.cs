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
		public string htmlString;

		public ICustomActivityResult Execute()
		{
			var result = HttpUtility.HtmlDecode(htmlString);
			
			return this.GenerateActivityResult(result);
		}
	}
}