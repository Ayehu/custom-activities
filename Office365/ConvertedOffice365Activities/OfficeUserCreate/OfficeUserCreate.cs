using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Ayehu.Sdk.ActivityCreation
{
    public class OfficeUserCreate : IActivity
    {
        // <summary>
        /// The general format is alias@domain, where domain must be present in the tenant’s collection
        /// of verified domains. This property is required when a user is created.
        /// </summary>
        public string userPrincipalName;

        /// <summary>
        /// First Name
        /// </summary>
        public string firstName;

        /// <summary>
        /// Last Name
        /// </summary>
        public string lastName;

        /// <summary>
        /// Nik Name/Display Name
        /// </summary>
        public string displayName;

        /// <summary>
        /// User's password.
        /// By default, a strong password is required.
        /// </summary>
        /// <see cref="PasswordPolicies"/>
        public string password;

        /// <summary>
        /// Create an user account Enabled if the value is set to True
        /// </summary>
        public string isAccountEnabled;

        /// <summary>
        /// User must change password at next login if value is set to True
        /// </summary>
        public string forcePwdChange;

        public string authToken_password;
        public string Jsonkeypath = "";


        private bool omitJsonEmptyorNull = false;
        private string contentType = "application/json";
        private string endPoint = "https://graph.microsoft.com";
        private string httpMethod = "POST";
        private string _uriBuilderPath;
        private string _postData;

        private Dictionary<string, string> _headers;

        private string uriBuilderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_uriBuilderPath))
                {
                    _uriBuilderPath = "/v1.0/users";
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
            postData = @"{ 
                            ""accountEnabled"": " + isAccountEnabled.ToLower() + @",
                            ""givenName"": """ + firstName + @""",
                            ""surname"": """ + lastName + @""",
                            ""displayName"": """ + displayName + @""",
                            ""mailNickname"": """ + firstName + lastName + @""",
                            ""userPrincipalName"": """ + userPrincipalName + @""",
                            ""passwordProfile"": {
                                ""forceChangePasswordNextSignIn"": " + forcePwdChange.ToLower() + @",
                                ""password"": """ + password + @"""
                            }
                         }";                     
                         
            var response = ApiCAll();

            switch (response.StatusCode)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.OK:
                    {
                        if (string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result) == false)
                            return this.GenerateActivityResult(response.Content.ReadAsStringAsync().Result, Jsonkeypath);
                        else
                            return this.GenerateActivityResult("Success");
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
