using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Ayehu.Sdk.ActivityCreation
{
    public class PagerDutyUpdateAlert : IActivity
    {
        #region Private readonly properties

        private readonly string API_REQUEST_URL = "https://api.pagerduty.com/incidents/{0}/alerts/{1}";
        private readonly string CONTENT_TYPE = "application/json";
        private readonly string ACCEPT = "application/vnd.pagerduty+json;version=2";
        private readonly string METHOD = "PUT";

        #endregion

        #region Incoming properties 

        public string AuthorizationToken;
        public string From;
        public string IncidentId;
        public string AlertId;
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
                HttpWebResponse httpResponse = null;
                try
                {
                    httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                }
                catch (WebException ex)
                {
                    if (httpResponse == null)
                        throw new Exception("Status can't be changed from resolved.");
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
                        {
                            var responseString = streamReader.ReadToEnd();
                            return this.GenerateActivityResult(ExposeJson(JObject.Parse(responseString)));
                        }
                    }
                    else
                    {
                        throw ex;
                    }
                }
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    return this.GenerateActivityResult("Success");
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(API_REQUEST_URL, IncidentId, AlertId));
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

            incidentJson.Append("{\"alert\": " +
                "{ " +
                "\"status\": \"");
            incidentJson.Append(Status);
            incidentJson.Append("\"}}");

            return incidentJson.ToString();
        }

        private string ExposeJson(JObject jObject, string append = "")
        {
            foreach (var jProperty in jObject.Properties())
            {
                var jToken = jProperty.Value;

                if (jToken.Type == JTokenType.Object)
                {
                    var res = ExposeJson(jToken as JObject, append + jProperty.Name + "_");
                    if (!string.IsNullOrEmpty(res))
                    {
                        return res;
                    }
                }
                else if (jToken.Type == JTokenType.Array)
                {
                    if (append + jProperty.Name == "alert_errors")
                    {
                        return jProperty.Value.ToString();
                    }
                }
            }
            return null;
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
