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
		// public string instanceURL;
		// public string username;
		// public string apiToken;
		// public string ticketNumber;
		// public string filePath;

		public ICustomActivityResult Execute()
		{
			string tokenURL = "https://us1-smax.saas.microfocus.com/rest/856693713/ems/bulk";
			string tokenContentType = "application/json";
			string tokenAccept = "application/json";
			string tokenMethod = "POST";
			string tokenJsonBody = "{\"entities\":[{\"entity_type\":\"Request\",\"properties\":{\"DisplayLabel\":\"AyehuUpdate5\",\"Id\":\"12618\"}}],\"operation\":\"UPDATE\"}";
			string tokenResponseString;

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var tokenHttpWebRequest = (HttpWebRequest)WebRequest.Create(tokenURL);
				tokenHttpWebRequest.ContentType = tokenContentType;
				tokenHttpWebRequest.Accept = tokenAccept;
				tokenHttpWebRequest.Headers.Add("Cookie", "LWSSO_COOKIE_KEY=u5F2eDG5-NBkYfiSNWRPkhDM284wCLCPHziwdDtc_zLK4OiRD_sS0--ZCoOf6AEJIWsbRY5y1vaTbjdhiEjc64lCTF0CJf9ZOjt-pJwrfHodnjyA1INWAon8hmQFLFTcPFqZCpPHFQf02KWp9t6GKX6GJjIFwxO593OKxRcOejXscbvltVvc1cRIDCnfHo15nIEqtqJJz8nWz_749YHTaSLwpwPs_uIlvGt1fA-4nbphpIzdMjhV4bqIOjkZwxMFsOrK1YzEzMLQBWLrOslQ12ZN1Y2-CG_TE8tHGI5PhjcNlMM2LoHnHLgLmCIb4NdMogi1kSvmq7Ch1HYe1lP7a_eFscq0nKIIcFCNxcSGQjDoliuzAfwcANWeFWrkApP4hcfWyN706esgmw-MqqiHFW0i1v9Ru6TmXxGpk0RYtJdIgZmz6ak0xqUn9oWbRcUBQZvKR_UDvaGXmtd8-YpJAX5b4LUbtAixHNP3cALt9KBtz0OSeEdaMXjjSz9g3fZnR8-M4RbYHNTllMkkXGwgsENJ2jNmFcGBghu4lmx5qEd5TKkK1a2vgyYyFKT_DRGkzY-8nRqbNOFnyUJTDAO4POgobH1yuCVN8wRP3nfXs-qF7oyyFPcnAOejJHhnbX2kDudCPulW3IA0VvKqeGlyJ95k9Z2qZGhe63Jb7UNh-yXTFUsa2e_Eb0DDBmCpmqkjE42q1629hSgEHs5ggYEuCph4rT1M-jOfbl7wItTHRKw7BJZnaGenqwCs2YMvdRMSQ0OofW1Zt06nmRype_TmBh8l3DroCfgSNtu3-Sehw-__NXmECuYEwXT21cD6JZEWhqTYHH8TK4T4f6RFePXXdAMYpAxd_F3B4cgZuh2hthkX8uyqQgd-wh1lIfv3nOJo38GwPB4cjIAcFIChLZgc88I-0dYc5a4dUSINLzrf4juUiTZJGFOEfLS_h0rFyVPhybdu6k3MJHTSmzohKmiHuiFGpo_kGJu5HqDZRvTLFkYXTQ9vHVdp9Pz0ZCcVlbRRixMY8-h9nlF5USqt-u4wrROJmTyjNQSfjFTmNxCBQhqmmKU5vn8__hC_SfRGZDoIAWnhqJAA2QtRsAfwFOmv7NE78mk-JmeYOHCV2XTjvtftMMH92Wy0c_-ootRGN2Vrrjg5qX3uSacWVhweZPqN6WQtRm1K96YORkqiEuXzPohJJVGUC44vgaWW4iId5A9eqQTz1bMcRGGBl3NMfvCXRUHoT3-qS3-H3Y87nHQqbJipnHsObyl4zPHP60bIrlPIlE1BWdTCRApF1Zme3zD9OuWCeWRowNqQalVrQOItyk85d5Sk3MbLs45Hqnx6C54ud-iA6ob8SET3sa3ooVEi5FXX4toVzVwnNpSWLoYK3sCoLCPQldQuFK2Re-xHoGuNNxF4rOnpWgPTx4kXbx3aHb68D-9mKzyDZqqIsfYd_Mo.");
				tokenHttpWebRequest.Method = tokenMethod;

				using(var tokenStreamWriter = new StreamWriter(tokenHttpWebRequest.GetRequestStream()))
				{
					tokenStreamWriter.Write(tokenJsonBody);
					tokenStreamWriter.Flush();
					tokenStreamWriter.Close();

					var tokenHttpResponse = (HttpWebResponse)tokenHttpWebRequest.GetResponse();

					using(var tokenStreamReader = new StreamReader(tokenHttpResponse.GetResponseStream()))
					{
						tokenResponseString = tokenStreamReader.ReadToEnd();

						return this.GenerateActivityResult(tokenResponseString.ToString());
					}
				}
			}
			catch(WebException e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}