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
    public class BambooGetWhoIsOut : IActivity
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
            SetAuthHeader();
            baseUrl += companyName;
            wc.Headers.Add(HttpRequestHeader.Accept, "application/json"); // return result as JSON, otherwise is XML

            var content = wc.DownloadString(string.Format("{0}/v1/time_off/whos_out/", baseUrl));

            if (!string.IsNullOrEmpty(content) || content != "[]")
            {
                DataTable dt = new DataTable("resultSet");
                AddColumns(dt);

                var result = (JArray.Parse(content)).ToList();
                result.ForEach(r =>
                {
                    dt.Rows.Add(
                        r["id"],
                        r["type"],
                        r["employeeId"],
                        r["name"],
                        r["start"],
                        r["end"]);
                });

                return this.GenerateActivityResult(dt);
            }

            throw new NotImplementedException();
        }

        private void AddColumns(DataTable dt)
        {
            dt.Columns.Add("Id");
            dt.Columns.Add("Type");
            dt.Columns.Add("Employee Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Start Date");
            dt.Columns.Add("End Date");
        }

        private void SetAuthHeader()
        {
            string authInfo = apiKey + ":x";
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            wc.Headers["Authorization"] = "Basic " + authInfo;
        }
    }
}
