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
    public class FreshDeskCreateCompany : IActivity
    {
        public string fdDomain, apiKey;
        public string companyName, industry, domains, health_score, description, account_tier;

        public ICustomActivityResult Execute()
        {
            string apiPath = "/api/v2/companies"; // API path

            var body = new JObject();
            body["name"] = companyName;

            var domainsList = new JArray();
            foreach (var g in domains.Split(','))
                if (!string.IsNullOrEmpty(g))
                    domainsList.Add(g);
            body["domains"] = domainsList;

            body["industry"] = industry;
            body["health_score"] = health_score;
            body["description"] = description;
            body["account_tier"] = account_tier;

            var bodyStr = JsonConvert.SerializeObject(body);

            var ret = MakeHttpRequest(apiPath, bodyStr);

            return this.GenerateActivityResult("Success");
        }

        private string MakeHttpRequest(string apiPath, string body)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://" + fdDomain + ".freshdesk.com" + apiPath);
            request.ContentType = "application/json";
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentLength = byteArray.Length;
            string authInfo = apiKey + ":X";
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            Console.WriteLine("Submitting Request");
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseStr = reader.ReadToEnd();

            return responseStr;
        }
    }
}
