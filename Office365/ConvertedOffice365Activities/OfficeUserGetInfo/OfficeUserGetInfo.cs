using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Ayehu.Sdk.ActivityCreation
{
    public class OfficeUserGetInfo : IActivity
    {
        /// <summary>
        /// User's email to retrieve the information
        /// </summary>
        public string userEmail;
        public string authToken_password;
        public string Jsonkeypath = "";


        private bool omitJsonEmptyorNull = false;
        private string contentType = "application/json";
        private string endPoint = "https://graph.microsoft.com";
        private string httpMethod = "GET";
        private string _uriBuilderPath;
        private string _postData;

        private Dictionary<string, string> _headers;

        private string uriBuilderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_uriBuilderPath))
                {
                    _uriBuilderPath = "/v1.0/users/" + userEmail;
                }
                return _uriBuilderPath;
            }
            set
            {
                _uriBuilderPath = value;
            }
        }

        private string postData
        {
            get
            {
                if (string.IsNullOrEmpty(_postData))
                {
                    _postData = "";
                }
                return _postData;
            }
            set
            {
                _postData = value;
            }
        }

        private Dictionary<string, string> headers
        {
            get
            {
                if (_headers == null)
                {
                    _headers = new Dictionary<string, string>() { { "authorization", "Bearer " + authToken_password } };
                }
                return _headers;
            }
            set
            {
                _headers = value;
            }
        }

        public ICustomActivityResult Execute()
        {
            var response = ApiCAll();

            switch (response.StatusCode)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.OK:
                    {
                        JObject user = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                        DataTable dt = new DataTable("resultSet");
                        dt.Columns.Add("Id");
                        dt.Columns.Add("Mail");
                        dt.Columns.Add("UserPrincipalName");
                        dt.Columns.Add("First Name");
                        dt.Columns.Add("Last Name");
                        dt.Columns.Add("UserType");
                        dt.Columns.Add("MobilePhone");
                        dt.Columns.Add("OfficeLocation");
                        dt.Columns.Add("LicenseDetails");
                        dt.Columns.Add("Settings");
                        dt.Columns.Add("AccountEnabled");

                        dt.Rows.Add(
                            user["id"],
                            user["mail"],
                            user["userPrincipalName"],
                            user["givenName"],
                            user["surname"],
                            user["userType"],
                            user["mobilePhone"],
                            user["officeLocation"],
                            user["licenseDetails"],
                            user["settings"],
                            user["accountEnabled"]);

                        return this.GenerateActivityResult(dt);
                    }
                default:
                    {
                        if (string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result) == false)
                            throw new Exception(response.Content.ReadAsStringAsync().Result);
                        else if (string.IsNullOrEmpty(response.ReasonPhrase) == false)
                            throw new Exception(response.ReasonPhrase);
                        else
                            throw new Exception(response.StatusCode.ToString());
                    }
            }
        }

        private HttpResponseMessage ApiCAll()
        {
            HttpClient client = new HttpClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            UriBuilder UriBuilder = new UriBuilder(endPoint);
            UriBuilder.Path = uriBuilderPath;
            HttpRequestMessage HttpRequestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), UriBuilder.ToString());

            if (contentType == "application/x-www-form-urlencoded")
                HttpRequestMessage.Content = AyehuHelper.formUrlEncodedContent(postData);
            else
            {
                if (string.IsNullOrEmpty(postData) == false)
                {
                    if (omitJsonEmptyorNull)
                        HttpRequestMessage.Content = new StringContent(AyehuHelper.omitJsonEmptyorNull(postData), Encoding.UTF8, "application/json");
                    else
                        HttpRequestMessage.Content = new StringContent(postData, Encoding.UTF8, contentType);
                }
            }

            foreach (KeyValuePair<string, string> headeritem in headers)
                client.DefaultRequestHeaders.Add(headeritem.Key, headeritem.Value);

            HttpResponseMessage response = client.SendAsync(HttpRequestMessage).Result;
            return response;
        }

        private bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
