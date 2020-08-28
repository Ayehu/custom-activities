using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Ayehu.Sdk.ActivityCreation
{
    public class ActivityClass : IActivity
    {
        public string AlertId = "";
        public string AckComment = "";
        public string AccountName = "";
        public string AccessId = "";
        public string AccessKey = "";

        public ICustomActivityResult Execute()
        {
            if (string.IsNullOrEmpty(AlertId))
            {
                throw new ArgumentException("AlertId can not be empty.");
            }

            if (string.IsNullOrEmpty(AckComment))
            {
                throw new ArgumentException("Comment can not be empty.");
            }

            if (string.IsNullOrEmpty(AccountName))
            {
                throw new ArgumentException("AccountName can not be empty.");
            }

            if (string.IsNullOrEmpty(AccessId))
            {
                throw new ArgumentException("AccessId can not be empty.");
            }

            if (string.IsNullOrEmpty(AccessKey))
            {
                throw new ArgumentException("AccessKey can not be empty.");
            }

            var resourcePath = string.Format("/alert/alerts/{0}/ack", AlertId);
            var apiURL = string.Format("https://{0}.logicmonitor.com/santaba/rest{1}", AccountName, resourcePath);

            var data = string.Format("{{ \"ackComment\": \"{0}\" }}", AckComment);
            const string httpVerb = "POST";

            var epoch = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
            var authHeaderValue = string.Format("LMv1 {0}:{1}:{2}", AccessId, GenerateSignature(epoch, httpVerb, data, resourcePath, AccessKey), epoch);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var request = (HttpWebRequest)WebRequest.Create(apiURL);
            request.Method = httpVerb;
            request.Headers["Authorization"] = authHeaderValue;
            request.ContentType = "application/json";

            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(data);
                }

                using (var httpResponse = (HttpWebResponse)request.GetResponse())
                {
                    var test = httpResponse.StatusCode;
                    using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var objText = reader.ReadToEnd();
                        if (!string.IsNullOrEmpty(objText))
                        {
                            var jRes = JObject.Parse(objText);
                            if (jRes.ContainsKey("errmsg"))
                            {
                                throw new Exception(jRes["errmsg"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!string.Equals(ex.Message, "ok", StringComparison.OrdinalIgnoreCase))
                {
                    return this.GenerateActivityResult(ex.Message);
                }
            }

            return this.GenerateActivityResult("Success");
        }

        private static string GenerateSignature(long epoch, string httpVerb, string data, string resourcePath, string accessKey)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256 { Key = Encoding.UTF8.GetBytes(accessKey) })
            {
                var compoundString = httpVerb + epoch + data + resourcePath;
                var signatureBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(compoundString));
                var signatureHex = BitConverter.ToString(signatureBytes).Replace("-", "").ToLower();
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(signatureHex));
            }
        }
    }
}
