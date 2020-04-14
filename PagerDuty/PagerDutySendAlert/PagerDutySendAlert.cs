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

        private readonly string API_REQUEST_URL = "https://events.pagerduty.com/v2/enqueue";
        private readonly string CONTENT_TYPE = "application/json";
        private readonly string METHOD = "POST";

        #endregion

        #region Incoming properties 


        public string Routingkey;
        public string Summary;
        public string Source;
        public string Severity;
        public string Component;
        public string Class;


        #endregion

        #region Public methods

        public ICustomActivityResult Execute()
        {


            var httpWebRequest = HttpRequest();

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(IncidentJsonBuilder());
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK || httpResponse.StatusCode == HttpStatusCode.Created || httpResponse.StatusCode == HttpStatusCode.Accepted)
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(API_REQUEST_URL);
            httpWebRequest.ContentType = CONTENT_TYPE;



            httpWebRequest.Method = METHOD;

            return httpWebRequest;
        }

        private string IncidentJsonBuilder()
        {
            StringBuilder incidentJson = new StringBuilder();
            incidentJson.Append("{");
            incidentJson.Append("\"routing_key\": \"" + Routingkey + "\",");
            incidentJson.Append("\"event_action\": \"trigger\",");
            incidentJson.Append("\"images\": [],");
            incidentJson.Append("\"links\": [],");
            incidentJson.Append("\"payload\": {");
            incidentJson.Append("\"summary\": \"" + Summary + "\",");
            incidentJson.Append("\"source\": \"" + Source + "\",");
            incidentJson.Append("\"severity\": \"" + Severity + "\",");
            incidentJson.Append("\"component\": \"" + Component + "\",");
            incidentJson.Append("\"class\": \"" + Class + "\"");
            incidentJson.Append("}");
            incidentJson.Append("}");
                                    

            return incidentJson.ToString();
        }



        #endregion
    }
}