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
    public class OfficeEmailSend : IActivity
    {
        /// <summary>
        /// Email subject
        /// </summary>
        public string subject;

        /// <summary>
        /// The text of the message to be sent 
        /// </summary>
        public string messageBody;

        /// <summary>
        /// The sender's email
        /// </summary>
        public string fromEmail;

        /// <summary>
        /// The recipient of the email.
        /// </summary>
        public string toEmail;

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
                    _uriBuilderPath = "/v1.0/users/" + fromEmail + "/sendMail";
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
            postData = GetBody();
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

        private string GetBody()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{");
            
            sb.AppendLine(@" ""message"": {");
            sb.AppendLine(@" ""subject"": """ + subject + @""",");
            sb.AppendLine(@" ""body"": {");
            sb.AppendLine(@" ""contentType"": ""text"",");
            sb.AppendLine(@" ""content"": """ + messageBody + @"""");
            sb.AppendLine("},");

            sb.AppendLine(@" ""toRecipients"": [");
            sb.AppendLine("{");
            sb.AppendLine(@" ""emailAddress"": {");
            sb.AppendLine(@" ""address"": """ + toEmail + @"""");
            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine("]");

            sb.AppendLine("}");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
