using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Net;
using System.Text;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace xMatters
{
    class xMattersCreatePerson : IActivity
    {
        public string emailAddress;
        public string passX;
        public string domainxmatters;
        public string targetName;
        public string firstName;
        public string lastName;
        public string phoneLogin;
        public string roleKey;
        public ICustomActivityResult Execute()
        {
            string bodyCreatePerson = "{\"targetName\": \"" + targetName + "\",\"firstName\": \"" + firstName + "\",\"lastName\": \"" + lastName + "\",\"phoneLogin\": \"" + phoneLogin + "\",\"roles\": [\"" + roleKey + "\"]}";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(bodyCreatePerson);

            string Message = string.Empty;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            NetworkCredential myCredentials = new NetworkCredential("", "");
            myCredentials.UserName = emailAddress;
            myCredentials.Password = passX;
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(emailAddress + ":" + passX));

            string url = "https://" + domainxmatters + ".xmatters.com/api/xm/1/people";
            WebRequest myWebRequest = WebRequest.Create(url);
            myWebRequest.Method = "POST";
            myWebRequest.ContentType = "application/json";
            myWebRequest.ContentLength = byte1.Length;
            myWebRequest.Headers.Add("Authorization", "Basic " + encoded);
            try
            {
                Stream newStream = myWebRequest.GetRequestStream();
                newStream.Write(byte1, 0, byte1.Length);
                WebResponse myWebResponse = myWebRequest.GetResponse();
                var getsponse = myWebResponse.GetResponseStream();
                StreamReader reader = new StreamReader(getsponse);
                var rs = reader.ReadToEnd();
                RootObject eventsList = JsonConvert.DeserializeObject<RootObject>(rs);
                Message = eventsList.id;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return this.GenerateActivityResult(Message);
        }
    }
    public class Links
    {
        public string self { get; set; }
    }

    public class Links2
    {
        public string self { get; set; }
    }

    public class Site
    {
        public string id { get; set; }
        public string name { get; set; }
        public Links2 links { get; set; }
    }

    public class Links3
    {
        public string self { get; set; }
    }

    public class Links4
    {
        public string self { get; set; }
    }

    public class Site2
    {
        public string id { get; set; }
        public string name { get; set; }
        public Links4 links { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public string targetName { get; set; }
        public string recipientType { get; set; }
        public bool externallyOwned { get; set; }
        public Links3 links { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string language { get; set; }
        public string timezone { get; set; }
        public string webLogin { get; set; }
        public Site2 site { get; set; }
        public DateTime lastLogin { get; set; }
        public string status { get; set; }
    }

    public class Links5
    {
        public string self { get; set; }
    }

    public class Supervisors
    {
        public int count { get; set; }
        public int total { get; set; }
        public List<Datum> data { get; set; }
        public Links5 links { get; set; }
    }

    public class RootObject
    {
        public string id { get; set; }
        public string targetName { get; set; }
        public string recipientType { get; set; }
        public bool externallyOwned { get; set; }
        public Links links { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string language { get; set; }
        public string timezone { get; set; }
        public string webLogin { get; set; }
        public string phoneLogin { get; set; }
        public Site site { get; set; }
        public Supervisors supervisors { get; set; }
        public string status { get; set; }
    }
}
