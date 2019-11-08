using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using System;
using System.Net;

namespace Ayehu.Sdk.ActivityCreation
{
    public class OktaResetPassword : IActivity
    {
        #region Private readonly properties

        private readonly string API_REQUEST_URL = "{0}/api/v1/users/{1}/lifecycle/reset_password?sendEmail=true";
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
            var httpWebRequest = HttpRequest();

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return this.GenerateActivityResult("The email has been sent.");
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

        #endregion
    }
}