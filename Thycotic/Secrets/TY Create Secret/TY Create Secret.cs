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
    public class TY_Create_Secret : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "secrets";
    
    public string password1 = "";
    
    public string autoChangeEnabled = "";
    
    public string checkOutChangePasswordEnabled = "";
    
    public string checkOutEnabled = "";
    
    public string checkOutIntervalMinutes = "";
    
    public string enableInheritPermissions = "";
    
    public string enableInheritSecretPolicy = "";
    
    public string folderId = "";
    
    public string items = "";
    
    public string launcherConnectAsSecretId = "";
    
    public string name_p = "";
    
    public string passwordTypeWebScriptId = "";
    
    public string proxyEnabled = "";
    
    public string requiresComment = "";
    
    public string secretPolicyId = "";
    
    public string secretTemplateId = "";
    
    public string sessionRecordingEnabled = "";
    
    public string siteId = "";
    
    public string generatePassphrase = "";
    
    public string generateSshKeys = "";
    
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
_uriBuilderPath = "SecretServer/api/v1/secrets";
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
_postData = string.Format("{{ \"autoChangeEnabled\": \"{0}\",  \"checkOutChangePasswordEnabled\": \"{1}\",  \"checkOutEnabled\": \"{2}\",  \"checkOutIntervalMinutes\": \"{3}\",  \"enableInheritPermissions\": \"{4}\",  \"enableInheritSecretPolicy\": \"{5}\",  \"folderId\": \"{6}\",  \"items\": {7},  \"launcherConnectAsSecretId\": \"{8}\",  \"name\": \"{9}\",  \"passwordTypeWebScriptId\": \"{10}\",  \"proxyEnabled\": \"{11}\",  \"requiresComment\": \"{12}\",  \"secretPolicyId\": \"{13}\",  \"secretTemplateId\": \"{14}\",  \"sessionRecordingEnabled\": \"{15}\",  \"siteId\": \"{16}\",  \"sshKeyArgs\": {{   \"generatePassphrase\": \"{17}\",    \"generateSshKeys\": \"{18}\"   }} }}",autoChangeEnabled,checkOutChangePasswordEnabled,checkOutEnabled,checkOutIntervalMinutes,enableInheritPermissions,enableInheritSecretPolicy,folderId,items,launcherConnectAsSecretId,name_p,passwordTypeWebScriptId,proxyEnabled,requiresComment,secretPolicyId,secretTemplateId,sessionRecordingEnabled,siteId,generatePassphrase,generateSshKeys);
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
    
    public TY_Create_Secret() {
    }
    
    public TY_Create_Secret(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string autoChangeEnabled, 
                string checkOutChangePasswordEnabled, 
                string checkOutEnabled, 
                string checkOutIntervalMinutes, 
                string enableInheritPermissions, 
                string enableInheritSecretPolicy, 
                string folderId, 
                string items, 
                string launcherConnectAsSecretId, 
                string name_p, 
                string passwordTypeWebScriptId, 
                string proxyEnabled, 
                string requiresComment, 
                string secretPolicyId, 
                string secretTemplateId, 
                string sessionRecordingEnabled, 
                string siteId, 
                string generatePassphrase, 
                string generateSshKeys) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.autoChangeEnabled = autoChangeEnabled;
        this.checkOutChangePasswordEnabled = checkOutChangePasswordEnabled;
        this.checkOutEnabled = checkOutEnabled;
        this.checkOutIntervalMinutes = checkOutIntervalMinutes;
        this.enableInheritPermissions = enableInheritPermissions;
        this.enableInheritSecretPolicy = enableInheritSecretPolicy;
        this.folderId = folderId;
        this.items = items;
        this.launcherConnectAsSecretId = launcherConnectAsSecretId;
        this.name_p = name_p;
        this.passwordTypeWebScriptId = passwordTypeWebScriptId;
        this.proxyEnabled = proxyEnabled;
        this.requiresComment = requiresComment;
        this.secretPolicyId = secretPolicyId;
        this.secretTemplateId = secretTemplateId;
        this.sessionRecordingEnabled = sessionRecordingEnabled;
        this.siteId = siteId;
        this.generatePassphrase = generatePassphrase;
        this.generateSshKeys = generateSshKeys;
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