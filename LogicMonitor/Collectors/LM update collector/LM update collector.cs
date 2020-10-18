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
    public class LM_update_collector : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string accessid = "";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string dayOfWeek = "";
    
    public string description_p = "";
    
    public string hour = "";
    
    public string minute = "";
    
    public string occurrence = "";
    
    public string timezone = "";
    
    public string version = "";
    
    public string backupAgentId = "";
    
    public string collectorGroupId = "";
    
    public string customProperties = "";
    
    public string _description = "";
    
    public string enableFailBack = "";
    
    public string enableFailOverOnCollectorDevice = "";
    
    public string escalatingChainId = "";
    
    public string needAutoCreateCollectorDevice = "";
    
    public string numberOfInstances = "";
    
    public string onetimeDowngradeInfo_description = "";
    
    public string majorVersion = "";
    
    public string minorVersion = "";
    
    public string startEpoch = "";
    
    public string onetimeDowngradeInfo_timezone = "";
    
    public string onetimeUpgradeInfo_description = "";
    
    public string onetimeUpgradeInfo_majorVersion = "";
    
    public string onetimeUpgradeInfo_minorVersion = "";
    
    public string onetimeUpgradeInfo_startEpoch = "";
    
    public string onetimeUpgradeInfo_timezone = "";
    
    public string resendIval = "";
    
    public string specifiedCollectorDeviceGroupId = "";
    
    public string suppressAlertClear = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "PATCH";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = string.Format("/setting/collector/collectors/{0}",id_p);
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
_postData = string.Format("{{ \"automaticUpgradeInfo\": {{   \"dayOfWeek\": \"{0}\",    \"description\": \"{1}\",    \"hour\": \"{2}\",    \"minute\": \"{3}\",    \"occurrence\": \"{4}\",    \"timezone\": \"{5}\",    \"version\": \"{6}\"   }},  \"backupAgentId\": \"{7}\",  \"collectorGroupId\": \"{8}\",  \"customProperties\": {9},  \"description\": \"{10}\",  \"enableFailBack\": \"{11}\",  \"enableFailOverOnCollectorDevice\": \"{12}\",  \"escalatingChainId\": \"{13}\",  \"needAutoCreateCollectorDevice\": \"{14}\",  \"numberOfInstances\": \"{15}\",  \"onetimeDowngradeInfo\": {{   \"description\": \"{16}\",    \"majorVersion\": \"{17}\",    \"minorVersion\": \"{18}\",    \"startEpoch\": \"{19}\",    \"timezone\": \"{20}\"   }},  \"onetimeUpgradeInfo\": {{   \"description\": \"{21}\",    \"majorVersion\": \"{22}\",    \"minorVersion\": \"{23}\",    \"startEpoch\": \"{24}\",    \"timezone\": \"{25}\"   }},  \"resendIval\": \"{26}\",  \"specifiedCollectorDeviceGroupId\": \"{27}\",  \"suppressAlertClear\": \"{28}\" }}",dayOfWeek,description_p,hour,minute,occurrence,timezone,version,backupAgentId,collectorGroupId,customProperties,_description,enableFailBack,enableFailOverOnCollectorDevice,escalatingChainId,needAutoCreateCollectorDevice,numberOfInstances,onetimeDowngradeInfo_description,majorVersion,minorVersion,startEpoch,onetimeDowngradeInfo_timezone,onetimeUpgradeInfo_description,onetimeUpgradeInfo_majorVersion,onetimeUpgradeInfo_minorVersion,onetimeUpgradeInfo_startEpoch,onetimeUpgradeInfo_timezone,resendIval,specifiedCollectorDeviceGroupId,suppressAlertClear);
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
    
    public LM_update_collector() {
    }
    
    public LM_update_collector(
                string endPoint, 
                string Jsonkeypath, 
                string accessid, 
                string password1, 
                string id_p, 
                string dayOfWeek, 
                string description_p, 
                string hour, 
                string minute, 
                string occurrence, 
                string timezone, 
                string version, 
                string backupAgentId, 
                string collectorGroupId, 
                string customProperties, 
                string _description, 
                string enableFailBack, 
                string enableFailOverOnCollectorDevice, 
                string escalatingChainId, 
                string needAutoCreateCollectorDevice, 
                string numberOfInstances, 
                string onetimeDowngradeInfo_description, 
                string majorVersion, 
                string minorVersion, 
                string startEpoch, 
                string onetimeDowngradeInfo_timezone, 
                string onetimeUpgradeInfo_description, 
                string onetimeUpgradeInfo_majorVersion, 
                string onetimeUpgradeInfo_minorVersion, 
                string onetimeUpgradeInfo_startEpoch, 
                string onetimeUpgradeInfo_timezone, 
                string resendIval, 
                string specifiedCollectorDeviceGroupId, 
                string suppressAlertClear) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.accessid = accessid;
        this.password1 = password1;
        this.id_p = id_p;
        this.dayOfWeek = dayOfWeek;
        this.description_p = description_p;
        this.hour = hour;
        this.minute = minute;
        this.occurrence = occurrence;
        this.timezone = timezone;
        this.version = version;
        this.backupAgentId = backupAgentId;
        this.collectorGroupId = collectorGroupId;
        this.customProperties = customProperties;
        this._description = _description;
        this.enableFailBack = enableFailBack;
        this.enableFailOverOnCollectorDevice = enableFailOverOnCollectorDevice;
        this.escalatingChainId = escalatingChainId;
        this.needAutoCreateCollectorDevice = needAutoCreateCollectorDevice;
        this.numberOfInstances = numberOfInstances;
        this.onetimeDowngradeInfo_description = onetimeDowngradeInfo_description;
        this.majorVersion = majorVersion;
        this.minorVersion = minorVersion;
        this.startEpoch = startEpoch;
        this.onetimeDowngradeInfo_timezone = onetimeDowngradeInfo_timezone;
        this.onetimeUpgradeInfo_description = onetimeUpgradeInfo_description;
        this.onetimeUpgradeInfo_majorVersion = onetimeUpgradeInfo_majorVersion;
        this.onetimeUpgradeInfo_minorVersion = onetimeUpgradeInfo_minorVersion;
        this.onetimeUpgradeInfo_startEpoch = onetimeUpgradeInfo_startEpoch;
        this.onetimeUpgradeInfo_timezone = onetimeUpgradeInfo_timezone;
        this.resendIval = resendIval;
        this.specifiedCollectorDeviceGroupId = specifiedCollectorDeviceGroupId;
        this.suppressAlertClear = suppressAlertClear;
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