using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Mail;
using Newtonsoft.Json.Linq;

namespace Ayehu.Sdk.ActivityCreation
{
    public class OktaCreateUser : IActivity
    {
        #region Private readonly properties

        private readonly string API_REQUEST_URL = "{0}/api/v1/users?activate=true";
        private readonly string CONTENT_TYPE = "application/json";
        private readonly string ACCEPT = "application/json";
        private readonly string METHOD = "POST";

        #endregion

        #region Incoming properties 
        
        public string AuthorizationToken;
        public string Domain;

        public string FirstName;
        public string LastName;
        public string Email;

        public string Password;

        #endregion

        #region Public methods

        public ICustomActivityResult Execute()
        {
            if (!IsValid(Email))
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
                        var id = ExposeJson(responseString, "id");
                        return this.GenerateActivityResult(id);
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(API_REQUEST_URL, Domain));
            httpWebRequest.ContentType = CONTENT_TYPE;
            httpWebRequest.Accept = ACCEPT;
            httpWebRequest.Headers.Add("Authorization", string.Format("SSWS {0}", AuthorizationToken));
            httpWebRequest.Method = METHOD;

            return httpWebRequest;
        }

        private string IncidentJsonBuilder()
        {
            StringBuilder incidentJson = new StringBuilder();

            incidentJson.Append("{\"profile\": { \"firstName\": \"");
            incidentJson.Append(FirstName);
            incidentJson.Append("\",\"lastName\": \"");
            incidentJson.Append(LastName);
            incidentJson.Append("\",\"email\": \"");
            incidentJson.Append(Email);
            incidentJson.Append("\",\"login\": \"");
            incidentJson.Append(Email);
            incidentJson.Append("\"},\"credentials\": {\"password\": {\"value\": \"");
            incidentJson.Append(Password);
            incidentJson.Append("\"}}}");

            return incidentJson.ToString();
        }

        private string ExposeJson(string json, string key)
        {
            var _jID = JObject.Parse(json)[key];
            return _jID.Value<string>(); 
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