using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.LogicMonitor
{
    public class LM_Get_the_result_of_a_Collector_debug_command : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string accessid = "";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string collectorId = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "GET";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = string.Format("/debug/{0}",id_p);
            }
return _uriBuilderPath;
        }
        set {
            this._uriBuilderPath = value;
        }
    }
    
    private string postData {
        get {
            if (string.IsNullOrEmpty(_postData)) {
_postData = "";
            }
return _postData;
        }
        set {
            this._postData = value;
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> headers {
        get {
            if (_headers == null) {
_headers = new Dictionary<string, string>() {  };
            }
return _headers;
        }
        set {
            this._headers = value;
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> queryStringArray {
        get {
            if (_queryStringArray == null) {
_queryStringArray = new Dictionary<string, string>() { {"collectorId",collectorId} };
            }
return _queryStringArray;
        }
        set {
            this._queryStringArray = value;
        }
    }
    
    public LM_Get_the_result_of_a_Collector_debug_command() {
    }
    
    public LM_Get_the_result_of_a_Collector_debug_command(string endPoint, string Jsonkeypath, string accessid, string password1, string id_p, string collectorId) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.accessid = accessid;
        this.password1 = password1;
        this.id_p = id_p;
        this.collectorId = collectorId;
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
                  myHttpRequestMessage.Content = new StringContent(data, Encoding.UTF8, contentType);
            }
               
            var epoch = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
            var authHeaderValue = string.Format("LMv1 {0}:{1}:{2}", accessid, GenerateSignature(epoch, httpMethod, data, uriBuilderPath, password1), epoch);

            client.DefaultRequestHeaders.Add("Authorization", authHeaderValue);
            client.DefaultRequestHeaders.Add("X-Version", "2");

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