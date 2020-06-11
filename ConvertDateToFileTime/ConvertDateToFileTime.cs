using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Text;
using System.Data;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class  CustomActivity: IActivity
	{
		public string dateToConvert;

		public ICustomActivityResult Execute()
		{
			var parsedDate = DateTime.Parse(dateToConvert);

			long dateFileTime = parsedDate.ToFileTime();

			var result = dateFileTime.ToString();

			return this.GenerateActivityResult(result);
		}
	}
}
