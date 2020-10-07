using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.Sdk.ActivityCreation
{
    public class CustomActivity_LM_add_escalation_chain : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "chains";
    
    public string accessid = "";
    
    public string password1 = "";
    
    public string ccDestinations__ = "";
    
    public string addr = "";
    
    public string contact = "";
    
    public string method = "";
    
    public string type = "";
    
    public string description = "";
    
    public string destinations__ = "";
    
    public string endMinutes = "";
    
    public string startMinutes = "";
    
    public string timezone = "";
    
    public string weekDays__ = "";
    
    public string stages__ = "";
    
    public string stages_addr = "";
    
    public string stages_contact = "";
    
    public string stages_method = "";
    
    public string stages_type = "";
    
    public string destinations_type = "";
    
    public string enableThrottling = "";
    
    public string name_p = "";
    
    public string throttlingAlerts = "";
    
    public string throttlingPeriod = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "/setting/alert/chains";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"ccDestinations\": [    {{     \"addr\": \"{0}\",      \"contact\": \"{1}\",      \"method\": \"{2}\",      \"type\": \"{3}\"     }}  ],  \"description\": \"{4}\",  \"destinations\": [    {{     \"period\": {{       \"endMinutes\": \"{5}\",        \"startMinutes\": \"{6}\",        \"timezone\": \"{7}\"       }},      \"stages\": [        [          {{           \"addr\": \"{8}\",            \"contact\": \"{9}\",            \"method\": \"{10}\",            \"type\": \"{11}\"           }}        ]      ],      \"type\": \"{12}\"     }}  ],  \"enableThrottling\": \"{13}\",  \"name\": \"{14}\",  \"throttlingAlerts\": \"{15}\",  \"throttlingPeriod\": \"{16}\" }}",addr,contact,method,type,description,endMinutes,startMinutes,timezone,stages_addr,stages_contact,stages_method,stages_type,destinations_type,enableThrottling,name_p,throttlingAlerts,throttlingPeriod);
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> headers {
        get {
            return new Dictionary<string, string>() {};
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> queryStringArray {
        get {
            return new Dictionary<string, string>() {};
        }
    }


        public async System.Threading.Tasks.Task<ICustomActivityResult> Execute()
        {

            HttpClient client = new HttpClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            UriBuilder UriBuilder = new UriBuilder(endPoint); 
            UriBuilder.Path =  "/santaba/rest" + uriBuilderPath;
            UriBuilder.Query = AyehuHelper.queryStringBuilder(queryStringArray);
            HttpRequestMessage myHttpRequestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), UriBuilder.ToString());
           
            string data =  postData;

            if (string.IsNullOrEmpty(postData) == false)
            {
               if (omitJsonEmptyorNull)
                  data = AyehuHelper.omitJsonEmptyorNull(postData);
                  myHttpRequestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
            }
               
            var epoch = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
            var authHeaderValue = string.Format("LMv1 {0}:{1}:{2}", accessid, GenerateSignature(epoch, httpMethod, data, uriBuilderPath, password1), epoch);

            client.DefaultRequestHeaders.Add("Authorization", authHeaderValue);

            HttpResponseMessage response = client.SendAsync(myHttpRequestMessage).Result;

            switch (response.StatusCode)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.OK:
                    {
                        if (string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result) == false)
                            return this.GenerateActivityResult(response.Content.ReadAsStringAsync().Result, Jsonkeypath);
                        else
                            return this.GenerateActivityResult("Success");
                    }
                default:
                    {
                        if (string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result) == false)
                            throw new Exception(response.Content.ReadAsStringAsync().Result);
                        else if (string.IsNullOrEmpty(response.ReasonPhrase) == false)
                            throw new Exception(response.ReasonPhrase);
                        else
                            throw new Exception(response.StatusCode.ToString());
                    }
            }
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
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