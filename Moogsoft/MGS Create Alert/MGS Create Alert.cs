using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.Moogsoft
{
    public class MGCreateAlert : IActivityAsync
    {

        public string endPoint = "https://{hostname}";

        private string contentType = "application/json";

        public string authtoken = "";

        public string Jsonkeypath = "";

        public string signature = "";

        public string sourceid = "";

        public string externalid = "";

        public string source = "";

        public string manager = "";

        public string class1 = "";

        public string agent = "";

        public string agentlocation = "";

        public string type = "";

        public string severity = "";

        public string description = "";

        public string agenttime = "";

        public string forPD = "";

        public string raiseTicket = "";

        public string Region = "";

        public string Environment = "";

        public string OSBuild = "";

        public string OSPlatform = "";

        private int uriBuilderHostPort = 443;

        private bool omitJsonEmptyorNull = true;

        private string httpMethod = "POST";

        private string uriBuilderPath
        {
            get
            {
                return "/rest/";
            }
        }

        private string _postData;
        private string postData
        {
            get
            {
                if (string.IsNullOrEmpty(_postData))
                {
                    _postData = string.Format("{{\"auth_token\":\"{18}\",\"events\":[ {{ \"signature\":\"{0}\",\"source_id\":\"{1}\",\"external_id\":\"{2}\",\"source\":\"{3}\",\"manager\":\"{4}\",\"class\":\"{5}\",\"agent\":\"{6}\",\"agent_location\":\"{7}\",\"type\":\"{8}\",\"severity\":\"{9}\",\"description\":\"{10}\",\"agent_time\":\"{11}\",\"forPD\":\"{12}\",\"raiseTicket\":\"{13}\",\"Region\":\"{14}\",\"Environment\":\"{15}\",\"OSBuild\":\"{16}\",\"OSPlatform\":\"{17}\"}}]}}", signature, sourceid, externalid, source, manager, class1, agent, agentlocation, type, severity, description, agenttime, forPD, raiseTicket, Region, Environment, OSBuild, OSPlatform, authtoken);
                }
                return _postData;
            }
            set
            {
                this._postData = value;
            }
        }

               

        private System.Collections.Generic.Dictionary<string, 
            string> headers
        {
            get
            {
                return new Dictionary<string, string>();
            }
        }

        private System.Collections.Generic.Dictionary<string, string> queryStringArray
        {
            get
            {
                return new Dictionary<string, string>();
            }
        }

        public async System.Threading.Tasks.Task<ICustomActivityResult> Execute()
        {
          

            HttpClient client = new HttpClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            UriBuilder UriBuilder = new UriBuilder(endPoint);
            UriBuilder.Path = uriBuilderPath;
            UriBuilder.Query = AyehuHelper.queryStringBuilder(queryStringArray);
            HttpRequestMessage myHttpRequestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), UriBuilder.ToString());

            if (contentType == "application/x-www-form-urlencoded")
                myHttpRequestMessage.Content = AyehuHelper.formUrlEncodedContent(postData);
            else
              if (string.IsNullOrEmpty(postData) == false)
                if (omitJsonEmptyorNull)
                    myHttpRequestMessage.Content = new StringContent(AyehuHelper.omitJsonEmptyorNull(postData), Encoding.UTF8, "application/json");
                else
                    myHttpRequestMessage.Content = new StringContent(postData, Encoding.UTF8, contentType);


            foreach (KeyValuePair<string, string> headeritem in headers)
                client.DefaultRequestHeaders.Add(headeritem.Key, headeritem.Value);

            HttpResponseMessage response = client.SendAsync(myHttpRequestMessage).Result;

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

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
