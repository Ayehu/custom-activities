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
    public class BambooGetEmployees : IActivity
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
            var content = wc.DownloadString(string.Format("{0}/v1/employees/directory", baseUrl));

            if (!string.IsNullOrEmpty(content))
            {
                DataTable dt = new DataTable("resultSet");
                var emplArr = ((JArray)JObject.Parse(content)["employees"]).ToList();

                AddColumns(dt);
                emplArr.ForEach(e =>
                {
                    dt.Rows.Add(
                        e["id"],
                        e["displayName"],
                        e["firstName"],
                        e["lastName"],
                        e["preferredName"],
                        e["gender"],
                        e["jobTitle"],
                        e["workPhone"],
                        e["workEmail"],
                        e["mobilePhone"],
                        e["department"],
                        e["location"],
                        e["workPhoneExtension"]);
                });

                return this.GenerateActivityResult(dt);
            }
            else
                throw new Exception("Cannot get employees information");
        }

        private void AddColumns(DataTable dt)
        {
            dt.Columns.Add("Id");
            dt.Columns.Add("DisplayName");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("PreferredName");
            dt.Columns.Add("Gender");
            dt.Columns.Add("JobTitle");
            dt.Columns.Add("WorkPhone");
            dt.Columns.Add("MobilePhone");
            dt.Columns.Add("WorkEmail");
            dt.Columns.Add("Department");
            dt.Columns.Add("Location");
            dt.Columns.Add("WorkPhoneExtension");
        }

        private void SetAuthHeader()
        {
            string authInfo = apiKey + ":x";
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            wc.Headers["Authorization"] = "Basic " + authInfo;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }
    }
}