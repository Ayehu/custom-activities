using System;
using System.Data;
using System.Text;
using System.Net;
using System.Linq;
using Newtonsoft.Json.Linq;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;

namespace Ayehu.Sdk.ActivityCreation
{
    public class BambooGetTimeOffRequests : IActivity
    {
        /// <summary>
        /// The registered company name in bamboohr
        /// </summary>
        public string companyName;

        /// <summary>
        /// The api key provided by bamboohr
        /// </summary>
        public string apiKey;

        private string baseUrl = "https://api.bamboohr.com/api/gateway.php/";
        private WebClient wc = new WebClient();

        public ICustomActivityResult Execute()
        {
            string dtStart = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
            string dtEnd = DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd");

            SetAuthHeader();
            baseUrl += companyName;
            wc.Headers.Add(HttpRequestHeader.Accept, "application/json"); // return result as JSON, otherwise is XML
            var content = wc.DownloadString(string.Format("{0}/v1/time_off/requests?start={1}&end={2}", baseUrl, dtStart, dtEnd));

            if (!string.IsNullOrEmpty(content) || content != "[]")
            {
                DataTable dt = new DataTable("resultSet");
                AddColumns(dt);

                var result = (JArray.Parse(content)).ToList();

                result.ForEach(r => 
                {
                    dt.Rows.Add(
                        r["employeeId"],
                        r["name"],
                        r["start"],
                        r["end"],
                        r["type"]["name"],
                        r["amount"]["amount"] + " " + r["amount"]["unit"]);
                });

                return this.GenerateActivityResult(dt);
            }
            else
            {
              throw  new Exception("No Time Off requests found");
            }
        }

        private void AddColumns(DataTable dt)
        {
            dt.Columns.Add("EmployeeId");
            dt.Columns.Add("EmployeeName");
            dt.Columns.Add("TimeOffStart");
            dt.Columns.Add("TimeOffEnd");
            dt.Columns.Add("TimeOffType");
            dt.Columns.Add("Amount");
        }

        private void SetAuthHeader()
        {
            string authInfo = apiKey + ":x";
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            wc.Headers["Authorization"] = "Basic " + authInfo;
        }
    }
}
