using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace Ayehu.Sdk.ActivityCreation
{
    public class PagerDutyDeleteUser : IActivity
    {
        #region Private readonly properties

        private readonly string API_REQUEST_URL = "https://api.pagerduty.com/users/{0}";
        private readonly string CONTENT_TYPE = "application/json";
        private readonly string ACCEPT = "application/vnd.pagerduty+json;version=2";
        private readonly string METHOD = "DELETE";

        #endregion

        #region Incoming properties 

        public string AuthorizationToken;
        public string UserId;

        #endregion

        #region Public methods

        public ICustomActivityResult Execute()
        {
            var httpWebRequest = HttpRequest();

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
                    throw new Exception(ExposeJson(JObject.Parse(responseString), "error_message"));
                }
            }
            if (httpResponse.StatusCode == HttpStatusCode.NoContent)
            {
                return this.GenerateActivityResult("Success");
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
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(API_REQUEST_URL, UserId));
            httpWebRequest.ContentType = CONTENT_TYPE;
            httpWebRequest.Accept = ACCEPT;
            httpWebRequest.Headers.Add("Authorization", string.Format("Token token={0}", AuthorizationToken));
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
                else if (jToken.Type == JTokenType.Array)
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
