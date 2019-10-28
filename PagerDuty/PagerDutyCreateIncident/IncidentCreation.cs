using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Mail;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;

namespace Ayehu.Sdk.ActivityCreation
{
    public class IncidentCreation : IActivity
    {
        #region Private readonly properties

        private readonly string API_REQUEST_URL = "https://api.pagerduty.com/incidents";
        private readonly string CONTENT_TYPE = "application/json";
        private readonly string ACCEPT = "application/vnd.pagerduty+json;version=2";
        private readonly string METHOD = "POST";
		private readonly string TYPE = "incident";
        private readonly string SERVICE_TYPE = "service_reference";
        
        #endregion

        #region Incoming properties 

        public string AuthorizationToken;
        public string From;

        public string Title;
        public string ServiceID;
        public string Urgency;
        public string Details;

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
                if (httpResponse.StatusCode == HttpStatusCode.Created)
                {
                
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var responseString = streamReader.ReadLine();
                        var search_string = "\"incident_number\":";
                        var cutIndex = responseString.IndexOf(search_string);
                        var comma_index = responseString.IndexOf(',');
                        var cut_index = cutIndex + search_string.Length;
                        var result = responseString.Substring(cut_index, comma_index - cut_index);
            
                   		return this.GenerateActivityResult(result);
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(API_REQUEST_URL);
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
            incidentJson.Append(TYPE);
            incidentJson.Append("\",\"title\": \"");
            incidentJson.Append(Title);
            incidentJson.Append("\",\"service\": {\"id\": \"");
            incidentJson.Append(ServiceID);
            incidentJson.Append("\",\"type\": \"");
            incidentJson.Append(SERVICE_TYPE);
            incidentJson.Append("\"},\"urgency\": \"");
            incidentJson.Append(Urgency);
            incidentJson.Append("\",\"body\": {\"type\": \"incident_body\",\"details\": \"");
            incidentJson.Append(Details);
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
