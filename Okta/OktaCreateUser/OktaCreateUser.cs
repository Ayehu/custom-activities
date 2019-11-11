using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Mail;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ayehu.Sdk.ActivityCreation
{
    public class OktaCreateUser : IActivity
    {
        #region Private readonly properties

        private readonly string API_REQUEST_URL = "{0}/api/v1/users?activate={1}";
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
        public string MobilePhone;
        public string Activate;
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
                HttpWebResponse httpResponse = null;
                try
                {
                    httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                }
                catch (WebException ex)
                {
                    using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        var responseString = streamReader.ReadLine();
                        var errors = ExposeJson(JObject.Parse(responseString), "errorCauses");
                        if (errors != "[]")
                        {
                            List<string> errorsResponse = new List<string>();
                            foreach (var error in JArray.Parse(errors))
                            {
                                errorsResponse.Add(ExposeJson(error.ToObject<JObject>(), "errorSummary"));
                            }
                            throw new Exception(JsonConvert.SerializeObject(errorsResponse));
                        }
                        else
                        {
                            throw new Exception(ExposeJson(JObject.Parse(responseString), "errorSummary"));
                        }
                    }
                }
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var responseString = streamReader.ReadLine();
                        var id = ExposeJson(JObject.Parse(responseString), "id");
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(API_REQUEST_URL, Domain, Activate == "yes" ? true.ToString() : false.ToString()));
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
            if (!string.IsNullOrWhiteSpace(MobilePhone))
            {
                incidentJson.Append("\",\"mobilePhone\": \"");
                incidentJson.Append(MobilePhone);
            }
            incidentJson.Append("\"},\"credentials\": {\"password\": {\"value\": \"");
            incidentJson.Append(Password);
            incidentJson.Append("\"}}}");

            return incidentJson.ToString();
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
                else if (jToken.Type == JTokenType.Array || jToken.Type == JTokenType.String)
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