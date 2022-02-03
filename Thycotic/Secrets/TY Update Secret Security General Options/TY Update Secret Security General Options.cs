using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.Thycotic
{
    public class TY_Update_Secret_Security_General_Options : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "security-general";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string dirty = "";
    
    public string value = "";
    
    public string enableDoubleLock_dirty = "";
    
    public string enableDoubleLock_value = "";
    
    public string hideLauncherPassword_dirty = "";
    
    public string hideLauncherPassword_value = "";
    
    public string proxyEnabled_dirty = "";
    
    public string proxyEnabled_value = "";
    
    public string requiresComment_dirty = "";
    
    public string requiresComment_value = "";
    
    public string sessionRecordingEnabled_dirty = "";
    
    public string sessionRecordingEnabled_value = "";
    
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
_uriBuilderPath = string.Format("SecretServer/api/v1/secrets/{0}/security-general",id_p);
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
_postData = string.Format("{{ \"data\": {{   \"doubleLockId\": {{     \"dirty\": \"{0}\",      \"value\": \"{1}\"     }},    \"enableDoubleLock\": {{     \"dirty\": \"{2}\",      \"value\": \"{3}\"     }},    \"hideLauncherPassword\": {{     \"dirty\": \"{4}\",      \"value\": \"{5}\"     }},    \"proxyEnabled\": {{     \"dirty\": \"{6}\",      \"value\": \"{7}\"     }},    \"requiresComment\": {{     \"dirty\": \"{8}\",      \"value\": \"{9}\"     }},    \"sessionRecordingEnabled\": {{     \"dirty\": \"{10}\",      \"value\": \"{11}\"     }}   }} }}",dirty,value,enableDoubleLock_dirty,enableDoubleLock_value,hideLauncherPassword_dirty,hideLauncherPassword_value,proxyEnabled_dirty,proxyEnabled_value,requiresComment_dirty,requiresComment_value,sessionRecordingEnabled_dirty,sessionRecordingEnabled_value);
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
_headers = new Dictionary<string, string>() { {"Authorization","Bearer " + password1} };
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
    
    public TY_Update_Secret_Security_General_Options() {
    }
    
    public TY_Update_Secret_Security_General_Options(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string dirty, 
                string value, 
                string enableDoubleLock_dirty, 
                string enableDoubleLock_value, 
                string hideLauncherPassword_dirty, 
                string hideLauncherPassword_value, 
                string proxyEnabled_dirty, 
                string proxyEnabled_value, 
                string requiresComment_dirty, 
                string requiresComment_value, 
                string sessionRecordingEnabled_dirty, 
                string sessionRecordingEnabled_value) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.dirty = dirty;
        this.value = value;
        this.enableDoubleLock_dirty = enableDoubleLock_dirty;
        this.enableDoubleLock_value = enableDoubleLock_value;
        this.hideLauncherPassword_dirty = hideLauncherPassword_dirty;
        this.hideLauncherPassword_value = hideLauncherPassword_value;
        this.proxyEnabled_dirty = proxyEnabled_dirty;
        this.proxyEnabled_value = proxyEnabled_value;
        this.requiresComment_dirty = requiresComment_dirty;
        this.requiresComment_value = requiresComment_value;
        this.sessionRecordingEnabled_dirty = sessionRecordingEnabled_dirty;
        this.sessionRecordingEnabled_value = sessionRecordingEnabled_value;
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
                    myHttpRequestMessage.Content = new StringContent(postData, Encoding.UTF8, contentType);


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