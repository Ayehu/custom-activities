using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Net;
using System.IO;
using System;

namespace xMatters
{
    class xMattersDeletePerson : IActivity
    {
        public string emailAddress;
        public string password;
        public string domainxmatters;
        public string targetName;
        public ICustomActivityResult Execute()
        {
            string Message = string.Empty;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(emailAddress + ":" + password));
            string url = "https://" + domainxmatters + ".xmatters.com/api/xm/1/people/" + targetName;
            WebRequest myWebRequest = WebRequest.Create(url);
            myWebRequest.Method = "DELETE";
            myWebRequest.Headers.Add("Authorization", "Basic " + encoded);
            WebResponse myWebResponse = myWebRequest.GetResponse();
            var getsponse = myWebResponse.GetResponseStream();
            StreamReader reader = new StreamReader(getsponse);
            string responseFromServer = reader.ReadToEnd();
            if (!string.IsNullOrEmpty(responseFromServer))
            {
                Message = "Success";
            }
            else
            {
                Message = "No response";
            }
            return this.GenerateActivityResult(Message);
        }
    }
}
