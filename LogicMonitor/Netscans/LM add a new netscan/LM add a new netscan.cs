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
    public class LM_add_a_new_netscan : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "netscans";
    
    public string accessid = "";
    
    public string password1 = "";
    
    public string collector = "";
    
    public string collectorDescription = "";
    
    public string collectorGroup = "";
    
    public string collectorGroupName = "";
    
    public string creator = "";
    
    public string description_p = "";
    
    public string type_p = "";
    
    public string group = "";
    
    public string id_p = "";
    
    public string method = "";
    
    public string name_p = "";
    
    public string nextStart = "";
    
    public string nextStartEpoch = "";
    
    public string nsgId = "";
    
    public string cron = "";
    
    public string notify = "";
    
    public string timezone = "";
    
    public string schedule_type = "";
    
    public string version = "";
    
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
_uriBuilderPath = "/setting/netscans";
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
_postData = string.Format("{{ \"collector\": \"{0}\",  \"collectorDescription\": \"{1}\",  \"collectorGroup\": \"{2}\",  \"collectorGroupName\": \"{3}\",  \"creator\": \"{4}\",  \"description\": \"{5}\",  \"duplicate\": {{   \"type\": \"{6}\"   }},  \"group\": \"{7}\",  \"id\": \"{8}\",  \"method\": \"{9}\",  \"name\": \"{10}\",  \"nextStart\": \"{11}\",  \"nextStartEpoch\": \"{12}\",  \"nsgId\": \"{13}\",  \"schedule\": {{   \"cron\": \"{14}\",    \"notify\": \"{15}\",    \"timezone\": \"{16}\",    \"type\": \"{17}\"   }},  \"version\": \"{18}\" }}",collector,collectorDescription,collectorGroup,collectorGroupName,creator,description_p,type_p,group,id_p,method,name_p,nextStart,nextStartEpoch,nsgId,cron,notify,timezone,schedule_type,version);
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
    
    public LM_add_a_new_netscan() {
    }
    
    public LM_add_a_new_netscan(
                string endPoint, 
                string Jsonkeypath, 
                string accessid, 
                string password1, 
                string collector, 
                string collectorDescription, 
                string collectorGroup, 
                string collectorGroupName, 
                string creator, 
                string description_p, 
                string type_p, 
                string group, 
                string id_p, 
                string method, 
                string name_p, 
                string nextStart, 
                string nextStartEpoch, 
                string nsgId, 
                string cron, 
                string notify, 
                string timezone, 
                string schedule_type, 
                string version) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.accessid = accessid;
        this.password1 = password1;
        this.collector = collector;
        this.collectorDescription = collectorDescription;
        this.collectorGroup = collectorGroup;
        this.collectorGroupName = collectorGroupName;
        this.creator = creator;
        this.description_p = description_p;
        this.type_p = type_p;
        this.group = group;
        this.id_p = id_p;
        this.method = method;
        this.name_p = name_p;
        this.nextStart = nextStart;
        this.nextStartEpoch = nextStartEpoch;
        this.nsgId = nsgId;
        this.cron = cron;
        this.notify = notify;
        this.timezone = timezone;
        this.schedule_type = schedule_type;
        this.version = version;
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