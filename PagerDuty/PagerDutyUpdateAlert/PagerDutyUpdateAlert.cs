using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Ayehu.Sdk.ActivityCreation
{
    public class PagerDutyUpdateAlert : IActivity
    {
        #region Private readonly properties

        private readonly string API_REQUEST_URL = "https://api.pagerduty.com/incidents/{0}/alerts/{1}";
        private readonly string CONTENT_TYPE = "application/json";
        private readonly string ACCEPT = "application/vnd.pagerduty+json;version=2";
        private readonly string METHOD = "PUT";
        private readonly string INCIDENT_TYPE = "incident_reference";
        private readonly string ALERT_TYPE = "alert";

        #endregion

        #region Incoming properties 

        public string AuthorizationToken;
        public string From;
        public string IncidentId;
        public string AlertId;
        public string Triggered;
        public string Resolved;
        public string AssosiatedIncidentId;

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
                    using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        var responseString = streamReader.ReadToEnd();
                        var error_msg = ExposeJson(JObject.Parse(responseString), "error_errors");
                        if (string.IsNullOrWhiteSpace(error_msg))
                        {
                            error_msg = ExposeJson(JObject.Parse(responseString), "error_message");
                        }
                        throw new Exception(error_msg);
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
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
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
            var body = new
            {
                alert = new
                {
                    type = ALERT_TYPE,
                    status = Resolved == "yes" ? "resolved" : null,
                    incident = !string.IsNullOrWhiteSpace(AssosiatedIncidentId) ? new
                    {
                        id = AssosiatedIncidentId,
                        type = INCIDENT_TYPE
                    } : (object)null,
                }
            };

            return JsonConvert.SerializeObject(body);
        }

        private string ExposeJson(JObject jObject, string searchString, string append = "")
        {
            foreach (var jProperty in jObject.Properties())
            {
                var jToken = jProperty.Value;

                if (jToken.Type == JTokenType.Object)
                {
                    var res = ExposeJson(jToken as JObject, searchString, append + jProperty.Name + "_");
                    if (!string.IsNullOrEmpty(res))
                    {
                        return res;
                    }
                }
                else
                {
                    if (append + jProperty.Name == searchString)
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
