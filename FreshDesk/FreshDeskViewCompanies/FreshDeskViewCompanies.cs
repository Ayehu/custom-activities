using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Data;

namespace ActivitiesAyehu
{
    public class FreshDeskViewCompanies : IActivity
    {
        public string fdDomain, apiKey;
        public string query, per_page, page;
        public ICustomActivityResult Execute()
        {
            string apiPath = "/api/v2/companies?per_page=" + per_page + "&page=" + page; // API path"; // API path
            if (!string.IsNullOrEmpty(query))
                apiPath += "&query =\"" + query + "\"";
            var ret = MakeHttpRequest(apiPath, "GET");

            var result = JsonConvert.DeserializeObject<JArray>(ret);

            var dataTable = new DataTable("Ticket List", "Tickets");
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Industry");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("Health Score");
            dataTable.Columns.Add("Account Tier");
            dataTable.Columns.Add("Renewal Date");
            foreach (var cont in result)
                dataTable.Rows.Add(cont["id"], cont["name"], cont["industry"], cont["email"], cont["description"], cont["health_score"], cont["account_tier"], cont["renewal_date"]);

            return this.GenerateActivityResult(dataTable);
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
