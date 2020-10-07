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
    public class CustomActivity_LM_update_user : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string accessid = "";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string changePassword = "";
    
    public string acceptEULA = "";
    
    public string apiTokens__ = "";
    
    public string note = "";
    
    public string status = "";
    
    public string apionly = "";
    
    public string contactMethod = "";
    
    public string createdBy = "";
    
    public string email = "";
    
    public string firstName = "";
    
    public string forcePasswordChange = "";
    
    public string lastName = "";
    
    public string _note = "";
    
    public string password = "";
    
    public string phone = "";
    
    public string roles__ = "";
    
    public string customHelpLabel = "";
    
    public string customHelpURL = "";
    
    public string description = "";
    
    public string name_p = "";
    
    public string privileges__ = "";
    
    public string objectId = "";
    
    public string objectType = "";
    
    public string operation = "";
    
    public string requireEULA = "";
    
    public string twoFARequired = "";
    
    public string smsEmail = "";
    
    public string smsEmailFormat = "";
    
    public string _status = "";
    
    public string timezone = "";
    
    public string twoFAEnabled = "";
    
    public string username = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "PUT";
    
    private string uriBuilderPath {
        get {
            return string.Format("/setting/admins/{0}",id_p);
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"acceptEULA\": \"{0}\",  \"apiTokens\": [    {{     \"note\": \"{1}\",      \"status\": \"{2}\"     }}  ],  \"apionly\": \"{3}\",  \"contactMethod\": \"{4}\",  \"createdBy\": \"{5}\",  \"email\": \"{6}\",  \"firstName\": \"{7}\",  \"forcePasswordChange\": \"{8}\",  \"lastName\": \"{9}\",  \"note\": \"{10}\",  \"password\": \"{11}\",  \"phone\": \"{12}\",  \"roles\": [    {{     \"customHelpLabel\": \"{13}\",      \"customHelpURL\": \"{14}\",      \"description\": \"{15}\",      \"name\": \"{16}\",      \"privileges\": [        {{         \"objectId\": \"{17}\",          \"objectType\": \"{18}\",          \"operation\": \"{19}\"         }}      ],      \"requireEULA\": \"{20}\",      \"twoFARequired\": \"{21}\"     }}  ],  \"smsEmail\": \"{22}\",  \"smsEmailFormat\": \"{23}\",  \"status\": \"{24}\",  \"timezone\": \"{25}\",  \"twoFAEnabled\": \"{26}\",  \"username\": \"{27}\" }}",acceptEULA,note,status,apionly,contactMethod,createdBy,email,firstName,forcePasswordChange,lastName,_note,password,phone,customHelpLabel,customHelpURL,description,name_p,objectId,objectType,operation,requireEULA,twoFARequired,smsEmail,smsEmailFormat,_status,timezone,twoFAEnabled,username);
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