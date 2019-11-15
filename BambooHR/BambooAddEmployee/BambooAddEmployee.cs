using System;
using System.Data;
using System.Text;
using System.Net;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;

namespace Ayehu.Sdk.ActivityCreation
{
    public class BambooAddEmployee : IActivity
    {
        /// <summary>
        /// The registered company name in bamboohr
        /// </summary>
        public string companyName;

        /// <summary>
        /// The api key provided by bamboohr
        /// </summary>
        public string apiKey;

        public string firstName;
        public string lastName;
        public string jobTitle;
        public string workPhone;
        public string workEmail;
        public string mobilePhone;
        public string department;

        private string baseUrl = "https://api.bamboohr.com/api/gateway.php/";
        private WebClient wc = new WebClient();

        public ICustomActivityResult Execute()
        {
            SetAuthHeader();
            baseUrl += companyName;
            wc.UploadString(string.Format("{0}/v1/employees/", baseUrl), GetEmployeeData);
            var location = wc.ResponseHeaders["Location"];
            string userId = location.Substring(location.LastIndexOf("/") + 1);
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");
            dt.Rows.Add(userId);
            return this.GenerateActivityResult(dt);
        }

        private string GetEmployeeData
        {
            get
            {
                string data =
                    "{\"firstName\":\"" + firstName + 
                    "\",\"lastName\":\"" + lastName + 
                    "\",\"jobTitle\": \"" + jobTitle + 
                    "\",\"workPhone\": \"" + workPhone +
                    "\",\"workEmail\": \"" + workEmail +
                    "\",\"mobilePhone\": \"" + mobilePhone +
                    "\",\"department\": \"" + department +
                    "\",\"hireDate\": \"" + DateTime.Now.ToString("yyyy-MM-dd") +
                    "\"}";
                return data;
            }
        }

        private void SetAuthHeader()
        {
            string authInfo = apiKey + ":x";
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            wc.Headers["Authorization"] = "Basic " + authInfo;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }
    }
}
