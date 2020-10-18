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
    public class LM_add_website : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "websites";
    
    public string accessid = "";
    
    public string password1 = "";
    
    public string description_p = "";
    
    public string disableAlerting = "";
    
    public string globalSmAlertCond = "";
    
    public string individualAlertLevel = "";
    
    public string individualSmAlertEnable = "";
    
    public string isInternal = "";
    
    public string name_p = "";
    
    public string overallAlertLevel = "";
    
    public string pollingInterval = "";
    
    public string stopMonitoring = "";
    
    public string all = "";
    
    public string transition = "";
    
    public string type_p = "";
    
    public string useDefaultAlertSetting = "";
    
    public string useDefaultLocationSetting = "";
    
    public string userPermission = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = "/website/websites";
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
_postData = string.Format("{{ \"description\": \"{0}\",  \"disableAlerting\": \"{1}\",  \"globalSmAlertCond\": \"{2}\",  \"individualAlertLevel\": \"{3}\",  \"individualSmAlertEnable\": \"{4}\",  \"isInternal\": \"{5}\",  \"name\": \"{6}\",  \"overallAlertLevel\": \"{7}\",  \"pollingInterval\": \"{8}\",  \"stopMonitoring\": \"{9}\",  \"testLocation\": {{   \"all\": \"{10}\"   }},  \"transition\": \"{11}\",  \"type\": \"{12}\",  \"useDefaultAlertSetting\": \"{13}\",  \"useDefaultLocationSetting\": \"{14}\",  \"userPermission\": \"{15}\" }}",description_p,disableAlerting,globalSmAlertCond,individualAlertLevel,individualSmAlertEnable,isInternal,name_p,overallAlertLevel,pollingInterval,stopMonitoring,all,transition,type_p,useDefaultAlertSetting,useDefaultLocationSetting,userPermission);
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
_queryStringArray = new Dictionary<string, string>() {  };
            }
return _queryStringArray;
        }
        set {
            this._queryStringArray = value;
        }
    }
    
    public LM_add_website() {
    }
    
    public LM_add_website(
                string endPoint, 
                string Jsonkeypath, 
                string accessid, 
                string password1, 
                string description_p, 
                string disableAlerting, 
                string globalSmAlertCond, 
                string individualAlertLevel, 
                string individualSmAlertEnable, 
                string isInternal, 
                string name_p, 
                string overallAlertLevel, 
                string pollingInterval, 
                string stopMonitoring, 
                string all, 
                string transition, 
                string type_p, 
                string useDefaultAlertSetting, 
                string useDefaultLocationSetting, 
                string userPermission) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.accessid = accessid;
        this.password1 = password1;
        this.description_p = description_p;
        this.disableAlerting = disableAlerting;
        this.globalSmAlertCond = globalSmAlertCond;
        this.individualAlertLevel = individualAlertLevel;
        this.individualSmAlertEnable = individualSmAlertEnable;
        this.isInternal = isInternal;
        this.name_p = name_p;
        this.overallAlertLevel = overallAlertLevel;
        this.pollingInterval = pollingInterval;
        this.stopMonitoring = stopMonitoring;
        this.all = all;
        this.transition = transition;
        this.type_p = type_p;
        this.useDefaultAlertSetting = useDefaultAlertSetting;
        this.useDefaultLocationSetting = useDefaultLocationSetting;
        this.userPermission = userPermission;
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