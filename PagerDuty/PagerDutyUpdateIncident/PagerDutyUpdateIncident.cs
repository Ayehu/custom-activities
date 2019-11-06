using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Mail;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;

namespace Ayehu.Sdk.ActivityCreation
{
    public class IncidentUpdate : IActivity
    {
        #region Private readonly properties

        private readonly string API_REQUEST_URL = "https://api.pagerduty.com/incidents/{0}";
        private readonly string CONTENT_TYPE = "application/json";
        private readonly string ACCEPT = "application/vnd.pagerduty+json;version=2";
        private readonly string METHOD = "PUT";

        #endregion

        #region Incoming properties 

        public string AuthorizationToken;
        public string From;

        public string IncidentID;
        public string Type;
        public string Status;

        #endregion

        #region Public methods

        public ICustomActivityResult Execute()
        {

            if (!IsValid(From))
            {
                throw new Exception("Email not valid.");
            }

            var httpWebRequest = HttpRequest();

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(IncidentJsonBuilder());
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var responseString = streamReader.ReadLine();
                        return this.GenerateActivityResult("Success");
                    }
                }
                else
                {
                    throw new Exception("Error");
                }
            }
        }

        #endregion

        #region Private methods 

        private WebRequest HttpRequest()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(API_REQUEST_URL, IncidentID));
            httpWebRequest.ContentType = CONTENT_TYPE;
            httpWebRequest.Accept = ACCEPT;
            httpWebRequest.Headers.Add("Authorization", string.Format("Token token={0}", AuthorizationToken));
            httpWebRequest.Headers.Add("From", From);
            httpWebRequest.Method = METHOD;

            return httpWebRequest;
        }

        private string IncidentJsonBuilder()
        {
            StringBuilder incidentJson = new StringBuilder();

            incidentJson.Append("{\"incident\": { \"type\": \"");
            incidentJson.Append(Type);
            incidentJson.Append("\",\"status\": \"");
            incidentJson.Append(Status);
            incidentJson.Append("\"}}}");

            return incidentJson.ToString();
        }

        private bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        #endregion
    }
}
