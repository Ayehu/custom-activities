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
    public class TY_Update_Secret : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string accessRequestWorkflowMapId = "";
    
    public string active = "";
    
    public string autoChangeEnabled = "";
    
    public string autoChangeNextPassword = "";
    
    public string checkOutChangePasswordEnabled = "";
    
    public string checkOutEnabled = "";
    
    public string checkOutIntervalMinutes = "";
    
    public string comment = "";
    
    public string doubleLockPassword = "";
    
    public string enableInheritPermissions = "";
    
    public string enableInheritSecretPolicy = "";
    
    public string folderId = "";
    
    public string forceCheckIn = "";
    
    public string _id = "";
    
    public string includeInactive = "";
    
    public string items = "";
    
    public string launcherConnectAsSecretId = "";
    
    public string name_p = "";
    
    public string newPassword = "";
    
    public string passwordTypeWebScriptId = "";
    
    public string proxyEnabled = "";
    
    public string requiresComment = "";
    
    public string secretPolicyId = "";
    
    public string sessionRecordingEnabled = "";
    
    public string siteId = "";
    
    public string generatePassphrase = "";
    
    public string generateSshKeys = "";
    
    public string ticketNumber = "";
    
    public string ticketSystemId = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "PUT";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = string.Format("SecretServer/api/v1/secrets/{0}",id_p);
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
_postData = string.Format("{{ \"accessRequestWorkflowMapId\": \"{0}\",  \"active\": \"{1}\",  \"autoChangeEnabled\": \"{2}\",  \"autoChangeNextPassword\": \"{3}\",  \"checkOutChangePasswordEnabled\": \"{4}\",  \"checkOutEnabled\": \"{5}\",  \"checkOutIntervalMinutes\": \"{6}\",  \"comment\": \"{7}\",  \"doubleLockPassword\": \"{8}\",  \"enableInheritPermissions\": \"{9}\",  \"enableInheritSecretPolicy\": \"{10}\",  \"folderId\": \"{11}\",  \"forceCheckIn\": \"{12}\",  \"id\": \"{13}\",  \"includeInactive\": \"{14}\",  \"items\": {15},  \"launcherConnectAsSecretId\": \"{16}\",  \"name\": \"{17}\",  \"newPassword\": \"{18}\",  \"passwordTypeWebScriptId\": \"{19}\",  \"proxyEnabled\": \"{20}\",  \"requiresComment\": \"{21}\",  \"secretPolicyId\": \"{22}\",  \"sessionRecordingEnabled\": \"{23}\",  \"siteId\": \"{24}\",  \"sshKeyArgs\": {{   \"generatePassphrase\": \"{25}\",    \"generateSshKeys\": \"{26}\"   }},  \"ticketNumber\": \"{27}\",  \"ticketSystemId\": \"{28}\" }}",accessRequestWorkflowMapId,active,autoChangeEnabled,autoChangeNextPassword,checkOutChangePasswordEnabled,checkOutEnabled,checkOutIntervalMinutes,comment,doubleLockPassword,enableInheritPermissions,enableInheritSecretPolicy,folderId,forceCheckIn,_id,includeInactive,items,launcherConnectAsSecretId,name_p,newPassword,passwordTypeWebScriptId,proxyEnabled,requiresComment,secretPolicyId,sessionRecordingEnabled,siteId,generatePassphrase,generateSshKeys,ticketNumber,ticketSystemId);
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
    
    public TY_Update_Secret() {
    }
    
    public TY_Update_Secret(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string accessRequestWorkflowMapId, 
                string active, 
                string autoChangeEnabled, 
                string autoChangeNextPassword, 
                string checkOutChangePasswordEnabled, 
                string checkOutEnabled, 
                string checkOutIntervalMinutes, 
                string comment, 
                string doubleLockPassword, 
                string enableInheritPermissions, 
                string enableInheritSecretPolicy, 
                string folderId, 
                string forceCheckIn, 
                string _id, 
                string includeInactive, 
                string items, 
                string launcherConnectAsSecretId, 
                string name_p, 
                string newPassword, 
                string passwordTypeWebScriptId, 
                string proxyEnabled, 
                string requiresComment, 
                string secretPolicyId, 
                string sessionRecordingEnabled, 
                string siteId, 
                string generatePassphrase, 
                string generateSshKeys, 
                string ticketNumber, 
                string ticketSystemId) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.accessRequestWorkflowMapId = accessRequestWorkflowMapId;
        this.active = active;
        this.autoChangeEnabled = autoChangeEnabled;
        this.autoChangeNextPassword = autoChangeNextPassword;
        this.checkOutChangePasswordEnabled = checkOutChangePasswordEnabled;
        this.checkOutEnabled = checkOutEnabled;
        this.checkOutIntervalMinutes = checkOutIntervalMinutes;
        this.comment = comment;
        this.doubleLockPassword = doubleLockPassword;
        this.enableInheritPermissions = enableInheritPermissions;
        this.enableInheritSecretPolicy = enableInheritSecretPolicy;
        this.folderId = folderId;
        this.forceCheckIn = forceCheckIn;
        this._id = _id;
        this.includeInactive = includeInactive;
        this.items = items;
        this.launcherConnectAsSecretId = launcherConnectAsSecretId;
        this.name_p = name_p;
        this.newPassword = newPassword;
        this.passwordTypeWebScriptId = passwordTypeWebScriptId;
        this.proxyEnabled = proxyEnabled;
        this.requiresComment = requiresComment;
        this.secretPolicyId = secretPolicyId;
        this.sessionRecordingEnabled = sessionRecordingEnabled;
        this.siteId = siteId;
        this.generatePassphrase = generatePassphrase;
        this.generateSshKeys = generateSshKeys;
        this.ticketNumber = ticketNumber;
        this.ticketSystemId = ticketSystemId;
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