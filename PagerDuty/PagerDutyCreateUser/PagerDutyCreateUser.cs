using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Ayehu.Sdk.ActivityCreation
{
    public class PagerDutyCreateUser : IActivity
    {
        #region Private readonly properties

        private readonly string API_REQUEST_URL = "https://api.pagerduty.com/users";
        private readonly string CONTENT_TYPE = "application/json";
        private readonly string ACCEPT = "application/vnd.pagerduty+json;version=2";
        private readonly string METHOD = "POST";
        private readonly string TYPE = "user";
        private readonly string COLOR = "green";
        #endregion

        #region Incoming properties 

        public string AuthorizationToken;
        public string From;

        public string Name;
        public string Email;
        public string Role;
        public string Job_Title;
        public string Description;

        #endregion

        #region Public methods

        public ICustomActivityResult Execute()
        {

            if (!IsValid(From) || !IsValid(Email))
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
                        throw new Exception(ExposeJson(JObject.Parse(responseString), "error_errors"));
                    }
                }

                if (httpResponse.StatusCode == HttpStatusCode.Created)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var responseString = streamReader.ReadLine();
                        var id = ExposeJson(JObject.Parse(responseString), "user_id");
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
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
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
            var body = new
            {
                TYPE,
                name = Name,
                email = Email,
                COLOR,
                role = Role,
                job_title = Job_Title,
                description = Description,
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
