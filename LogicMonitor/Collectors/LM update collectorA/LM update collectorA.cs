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
    public class CustomActivity_LM_update_collectorA : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string accessid = "";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string forceUpdateFailedOverDevices = "";
    
    public string dayOfWeek = "";
    
    public string description = "";
    
    public string hour = "";
    
    public string minute = "";
    
    public string occurrence = "";
    
    public string timezone = "";
    
    public string version = "";
    
    public string backupAgentId = "";
    
    public string collectorGroupId = "";
    
    public string customProperties__ = "";
    
    public string name_p = "";
    
    public string value = "";
    
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
    
    private string uriBuilderPath {
        get {
            return string.Format("/setting/collector/collectors/{0}",id_p);
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"automaticUpgradeInfo\": {{   \"dayOfWeek\": \"{0}\",    \"description\": \"{1}\",    \"hour\": \"{2}\",    \"minute\": \"{3}\",    \"occurrence\": \"{4}\",    \"timezone\": \"{5}\",    \"version\": \"{6}\"   }},  \"backupAgentId\": \"{7}\",  \"collectorGroupId\": \"{8}\",  \"customProperties\": [    {{     \"name\": \"{9}\",      \"value\": \"{10}\"     }}  ],  \"description\": \"{11}\",  \"enableFailBack\": \"{12}\",  \"enableFailOverOnCollectorDevice\": \"{13}\",  \"escalatingChainId\": \"{14}\",  \"needAutoCreateCollectorDevice\": \"{15}\",  \"numberOfInstances\": \"{16}\",  \"onetimeDowngradeInfo\": {{   \"description\": \"{17}\",    \"majorVersion\": \"{18}\",    \"minorVersion\": \"{19}\",    \"startEpoch\": \"{20}\",    \"timezone\": \"{21}\"   }},  \"onetimeUpgradeInfo\": {{   \"description\": \"{22}\",    \"majorVersion\": \"{23}\",    \"minorVersion\": \"{24}\",    \"startEpoch\": \"{25}\",    \"timezone\": \"{26}\"   }},  \"resendIval\": \"{27}\",  \"specifiedCollectorDeviceGroupId\": \"{28}\",  \"suppressAlertClear\": \"{29}\" }}",dayOfWeek,description,hour,minute,occurrence,timezone,version,backupAgentId,collectorGroupId,name_p,value,_description,enableFailBack,enableFailOverOnCollectorDevice,escalatingChainId,needAutoCreateCollectorDevice,numberOfInstances,onetimeDowngradeInfo_description,majorVersion,minorVersion,startEpoch,onetimeDowngradeInfo_timezone,onetimeUpgradeInfo_description,onetimeUpgradeInfo_majorVersion,onetimeUpgradeInfo_minorVersion,onetimeUpgradeInfo_startEpoch,onetimeUpgradeInfo_timezone,resendIval,specifiedCollectorDeviceGroupId,suppressAlertClear);
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