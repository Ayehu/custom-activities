using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Text.RegularExpressions;
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
			var result = UnHtml(htmlString);
			
			return this.GenerateActivityResult(result);
		}

		private static readonly Regex _tags_ = new Regex(@"<[^>]+?>", RegexOptions.Multiline | RegexOptions.Compiled);

		private static readonly Regex _notOkCharacter_ = new Regex(@"[^\w;&#@.:/\\?=|%!() -]", RegexOptions.Compiled);

		public static String UnHtml(String html)
		{
			html = HttpUtility.UrlDecode(html);
			html = HttpUtility.HtmlDecode(html);

			html = RemoveTag(html, "<!--", "-->");
			html = RemoveTag(html, "<script", "</script>");
			html = RemoveTag(html, "<style", "</style>");

			html = _tags_.Replace(html, " ");
			html = Regex.Replace(html, @"^\s+|\s+$|\s+(?=\s)", "");

			return html;
		}

		private static String RemoveTag(String html, String startTag, String endTag)
		{
			Boolean bAgain;

			do
			{
				bAgain = false;

				Int32 startTagPos = html.IndexOf(startTag, 0, StringComparison.CurrentCultureIgnoreCase);

				if (startTagPos < 0)
					continue;

				Int32 endTagPos = html.IndexOf(endTag, startTagPos + 1, StringComparison.CurrentCultureIgnoreCase);

				if (endTagPos <= startTagPos)
					continue;

				html = html.Remove(startTagPos, endTagPos - startTagPos + endTag.Length);

				bAgain = true;

			} while (bAgain);

			return html;
		}
	}
}