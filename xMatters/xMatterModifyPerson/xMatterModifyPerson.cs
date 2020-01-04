using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Net;
using System.Text;
using System.IO;
using System;

namespace xMatters.ModifyAPerson
{
    class xMattersModifyAPerson : IActivity
    {
        public string emailAddress;
        public string password;
        public string domainxmatters;
        public string idperson;
        public string targetName;
        public string firstName;
		public string lastName;
		public string recipientType;
		public string language;
		public string timezone;
		public string webLogin;
		public string phoneLogin;
		public string status;
		
        public ICustomActivityResult Execute()
        {
            string Message = string.Empty;
            string bodyPerson = "{\"id\": \"" + idperson + "\"";
			if(!string.IsNullOrEmpty(targetName)) {
				bodyPerson += ",\"targetName\": \"" + targetName + "\"";
			}
			if(!string.IsNullOrEmpty(firstName)) {
				bodyPerson += ",\"firstName\": \"" + firstName + "\"";
			}
			if(!string.IsNullOrEmpty(lastName)) {
				bodyPerson += ",\"lastName\": \"" + lastName + "\"";
			}
			if(!string.IsNullOrEmpty(recipientType)) {
				bodyPerson += ",\"recipientType\": \"" + recipientType + "\"";
			}
			if(!string.IsNullOrEmpty(language)) {
				bodyPerson += ",\"language\": \"" + language + "\"";
			}
			if(!string.IsNullOrEmpty(timezone)) {
				bodyPerson += ",\"timezone\": \"" + timezone + "\"";
			}
			if(!string.IsNullOrEmpty(webLogin)) {
				bodyPerson += ",\"webLogin\": \"" + webLogin + "\"";
			}
			if(!string.IsNullOrEmpty(phoneLogin)) {
				bodyPerson += ",\"phoneLogin\": \"" + phoneLogin + "\"";
			}
			if(!string.IsNullOrEmpty(status)) {
				bodyPerson += ",\"status\": \"" + status + "\"";
			}
			bodyPerson += "}";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(bodyPerson);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            NetworkCredential myCredentials = new NetworkCredential("", "");
            myCredentials.UserName = emailAddress;
            myCredentials.Password = password;
            string url = "https://" + domainxmatters + ".xmatters.com/api/xm/1/people";
            WebRequest myWebRequest = WebRequest.Create(url);
            myWebRequest.Credentials = myCredentials;
            myWebRequest.Method = "POST";
            myWebRequest.ContentType = "application/json";
            myWebRequest.ContentLength = byte1.Length;
            try
            {
                Stream newStream = myWebRequest.GetRequestStream();
                newStream.Write(byte1, 0, byte1.Length);
                WebResponse myWebResponse = myWebRequest.GetResponse();
                var getsponse = myWebResponse.GetResponseStream();
                StreamReader reader = new StreamReader(getsponse);
                Message = "Success";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return this.GenerateActivityResult(Message);
        }
    }
}
