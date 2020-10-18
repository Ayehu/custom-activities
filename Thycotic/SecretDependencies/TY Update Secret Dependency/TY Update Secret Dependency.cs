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
    public class TY_Update_Secret_Dependency : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string active = "";
    
    public string conditionDependencyId = "";
    
    public string conditionMode = "";
    
    public string changerScriptId = "";
    
    public string dependencyScanItemFields = "";
    
    public string scriptName = "";
    
    public string secretDependencyChangerId = "";
    
    public string secretDependencyTemplateId = "";
    
    public string description_p = "";
    
    public string groupId = "";
    
    public string _id = "";
    
    public string machineName = "";
    
    public string privilegedAccountSecretId = "";
    
    public string runScript_machineName = "";
    
    public string odbcConnectionArguments = "";
    
    public string scriptArguments = "";
    
    public string scriptId = "";
    
    public string runScript_scriptName = "";
    
    public string serviceName = "";
    
    public string secretId = "";
    
    public string secretName = "";
    
    public string _serviceName = "";
    
    public string settings_p = "";
    
    public string sortOrder = "";
    
    public string sshKeySecretId = "";
    
    public string typeId = "";
    
    public string typeName = "";
    
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
_uriBuilderPath = string.Format("SecretServer/api/v1/secret-dependencies/{0}",id_p);
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
_postData = string.Format("{{ \"active\": \"{0}\",  \"conditionDependencyId\": \"{1}\",  \"conditionMode\": \"{2}\",  \"dependencyTemplate\": {{   \"changerScriptId\": \"{3}\",    \"dependencyScanItemFields\": {4},    \"scriptName\": \"{5}\",    \"secretDependencyChangerId\": \"{6}\",    \"secretDependencyTemplateId\": \"{7}\"   }},  \"description\": \"{8}\",  \"groupId\": \"{9}\",  \"id\": \"{10}\",  \"machineName\": \"{11}\",  \"privilegedAccountSecretId\": \"{12}\",  \"runScript\": {{   \"machineName\": \"{13}\",    \"odbcConnectionArguments\": {14},    \"scriptArguments\": {15},    \"scriptId\": \"{16}\",    \"scriptName\": \"{17}\",    \"serviceName\": \"{18}\"   }},  \"secretId\": \"{19}\",  \"secretName\": \"{20}\",  \"serviceName\": \"{21}\",  \"settings\": {22},  \"sortOrder\": \"{23}\",  \"sshKeySecretId\": \"{24}\",  \"typeId\": \"{25}\",  \"typeName\": \"{26}\" }}",active,conditionDependencyId,conditionMode,changerScriptId,dependencyScanItemFields,scriptName,secretDependencyChangerId,secretDependencyTemplateId,description_p,groupId,_id,machineName,privilegedAccountSecretId,runScript_machineName,odbcConnectionArguments,scriptArguments,scriptId,runScript_scriptName,serviceName,secretId,secretName,_serviceName,settings_p,sortOrder,sshKeySecretId,typeId,typeName);
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
    
    public TY_Update_Secret_Dependency() {
    }
    
    public TY_Update_Secret_Dependency(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string active, 
                string conditionDependencyId, 
                string conditionMode, 
                string changerScriptId, 
                string dependencyScanItemFields, 
                string scriptName, 
                string secretDependencyChangerId, 
                string secretDependencyTemplateId, 
                string description_p, 
                string groupId, 
                string _id, 
                string machineName, 
                string privilegedAccountSecretId, 
                string runScript_machineName, 
                string odbcConnectionArguments, 
                string scriptArguments, 
                string scriptId, 
                string runScript_scriptName, 
                string serviceName, 
                string secretId, 
                string secretName, 
                string _serviceName, 
                string settings_p, 
                string sortOrder, 
                string sshKeySecretId, 
                string typeId, 
                string typeName) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.active = active;
        this.conditionDependencyId = conditionDependencyId;
        this.conditionMode = conditionMode;
        this.changerScriptId = changerScriptId;
        this.dependencyScanItemFields = dependencyScanItemFields;
        this.scriptName = scriptName;
        this.secretDependencyChangerId = secretDependencyChangerId;
        this.secretDependencyTemplateId = secretDependencyTemplateId;
        this.description_p = description_p;
        this.groupId = groupId;
        this._id = _id;
        this.machineName = machineName;
        this.privilegedAccountSecretId = privilegedAccountSecretId;
        this.runScript_machineName = runScript_machineName;
        this.odbcConnectionArguments = odbcConnectionArguments;
        this.scriptArguments = scriptArguments;
        this.scriptId = scriptId;
        this.runScript_scriptName = runScript_scriptName;
        this.serviceName = serviceName;
        this.secretId = secretId;
        this.secretName = secretName;
        this._serviceName = _serviceName;
        this.settings_p = settings_p;
        this.sortOrder = sortOrder;
        this.sshKeySecretId = sshKeySecretId;
        this.typeId = typeId;
        this.typeName = typeName;
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