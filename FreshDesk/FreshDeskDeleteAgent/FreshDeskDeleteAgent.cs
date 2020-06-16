using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ActivitiesAyehu
{
    public class FreshDeskDeleteAgent : IActivity
    {
        public string fdDomain, apiKey;
        public string id;

        public ICustomActivityResult Execute()
        {
            string apiPath = $"/api/v2/agents/{id}";

            var ret = MakeHttpRequest(apiPath, "DELETE");

            return this.GenerateActivityResult("Success");
        }

        private string MakeHttpRequest(string apiPath, string method, string body = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://" + fdDomain + ".freshdesk.com" + apiPath);
            request.ContentType = "application/json";
            request.Method = method;
            string authInfo = apiKey + ":X";
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;

            Stream dataStream;
            if (body != null)
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(body);
                request.ContentLength = byteArray.Length;
                dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
            }
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseStr = reader.ReadToEnd();

            return responseStr;
        }
    }
}
