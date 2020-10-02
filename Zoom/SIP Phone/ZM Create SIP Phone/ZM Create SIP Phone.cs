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
    public class CustomActivity_ZM_Create_SIP_Phone : IActivityAsync
    {


    
    public string Jsonkeypath = "sip_phones";
    
    public string apikey = "";
    
    public string password1 = "";
    
    public string domain = "";
    
    public string register_server = "";
    
    public string transport_protocol = "";
    
    public string proxy_server = "";
    
    public string register_server2 = "";
    
    public string transport_protocol2 = "";
    
    public string proxy_server2 = "";
    
    public string register_server3 = "";
    
    public string transport_protocol3 = "";
    
    public string proxy_server3 = "";
    
    public string registration_expire_time = "";
    
    public string user_name = "";
    
    public string password = "";
    
    public string authorization_name = "";
    
    public string user_email = "";
    
    public string voice_mail = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string endPoint = "https://api.zoom.us";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "v2/sip_phones";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{   \"domain\": \"{0}\",   \"register_server\": \"{1}\",   \"transport_protocol\": \"{2}\",   \"proxy_server\": \"{3}\",   \"register_server2\": \"{4}\",   \"transport_protocol2\": \"{5}\",   \"proxy_server2\": \"{6}\",   \"register_server3\": \"{7}\",   \"transport_protocol3\": \"{8}\",   \"proxy_server3\": \"{9}\",   \"registration_expire_time\": \"{10}\",   \"user_name\": \"{11}\",   \"password\": \"{12}\",   \"authorization_name\": \"{13}\",   \"user_email\": \"{14}\",   \"voice_mail\": \"{15}\" }}",domain,register_server,transport_protocol,proxy_server,register_server2,transport_protocol2,proxy_server2,register_server3,transport_protocol3,proxy_server3,registration_expire_time,user_name,password,authorization_name,user_email,voice_mail);
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> headers {
        get {
            return new Dictionary<string, string>() {{"authorization","Bearer " + AyehuHelper.JWTToken(apikey,password1,"HS256","JWT", 120)}};
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
            UriBuilder.Path = uriBuilderPath;
            UriBuilder.Query = AyehuHelper.queryStringBuilder(queryStringArray);
            HttpRequestMessage myHttpRequestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), UriBuilder.ToString());
           
            if (contentType == "application/x-www-form-urlencoded")
                myHttpRequestMessage.Content = AyehuHelper.formUrlEncodedContent(postData);
            else
              if (string.IsNullOrEmpty(postData) == false)
                if (omitJsonEmptyorNull)
                    myHttpRequestMessage.Content = new StringContent(AyehuHelper.omitJsonEmptyorNull(postData), Encoding.UTF8, "application/json");
                else
                    myHttpRequestMessage.Content = new StringContent(postData, Encoding.UTF8, "application/json");


            foreach (KeyValuePair<string, string> headeritem in headers)
                client.DefaultRequestHeaders.Add(headeritem.Key, headeritem.Value);

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
    }
}