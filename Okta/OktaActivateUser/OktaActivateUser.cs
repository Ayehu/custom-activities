using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Ayehu.Sdk.ActivityCreation
{
    public class OktaActivateUser : IActivity
    {
        #region Private readonly properties

        private readonly string API_REQUEST_URL = "{0}/api/v1/users/{1}/lifecycle/activate?sendEmail=true";
        private readonly string CONTENT_TYPE = "application/json";
        private readonly string ACCEPT = "application/json";
        private readonly string METHOD = "POST";

        #endregion

        #region Incoming properties 

        public string AuthorizationToken;
        public string Domain;

        public string UserId;

        #endregion

        #region Public methods

        public ICustomActivityResult Execute()
        {

            HttpWebResponse httpResponse = null;
            try
            {
                var httpWebRequest = HttpRequest();

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (WebException ex)
            {
                using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    var responseString = streamReader.ReadToEnd();
                    throw new Exception(ExposeJson(JObject.Parse(responseString), "errorSummary"));
                }
            }
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return this.GenerateActivityResult("Activation email has been sent to the user");
            }
            else
            {
                throw new Exception("Error");
            }
        }

        #endregion

        #region Private methods 

        private WebRequest HttpRequest()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(API_REQUEST_URL, Domain, UserId));
            httpWebRequest.ContentType = CONTENT_TYPE;
            httpWebRequest.Accept = ACCEPT;
            httpWebRequest.Headers.Add("Authorization", string.Format("SSWS {0}", AuthorizationToken));
            httpWebRequest.Method = METHOD;

            return httpWebRequest;
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

        #endregion
    }
}