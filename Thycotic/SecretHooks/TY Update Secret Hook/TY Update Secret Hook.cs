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
    public class TY_Update_Secret_Hook : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string password1 = "";
    
    public string secretHookId = "";
    
    public string secretId = "";
    
    public string dirty = "";
    
    public string value = "";
    
    public string database_dirty = "";
    
    public string database_value = "";
    
    public string description_dirty = "";
    
    public string description_value = "";
    
    public string eventActionId_dirty = "";
    
    public string eventActionId_value = "";
    
    public string failureMessage_dirty = "";
    
    public string failureMessage_value = "";
    
    public string name_dirty = "";
    
    public string name_value = "";
    
    public string parameters = "";
    
    public string port_dirty = "";
    
    public string port_value = "";
    
    public string prePostOption_dirty = "";
    
    public string prePostOption_value = "";
    
    public string privilegedSecretId_dirty = "";
    
    public string privilegedSecretId_value = "";
    
    public string scriptId_dirty = "";
    
    public string scriptId_value = "";
    
    public string scriptTypeId_dirty = "";
    
    public string scriptTypeId_value = "";
    
    public string serverKeyDigest_dirty = "";
    
    public string serverKeyDigest_value = "";
    
    public string serverName_dirty = "";
    
    public string serverName_value = "";
    
    public string sortOrder_dirty = "";
    
    public string sortOrder_value = "";
    
    public string sshKeySecretId_dirty = "";
    
    public string sshKeySecretId_value = "";
    
    public string status_dirty = "";
    
    public string status_value = "";
    
    public string stopOnFailure_dirty = "";
    
    public string stopOnFailure_value = "";
    
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
_uriBuilderPath = string.Format("SecretServer/api/v1/secret-detail/{1}/hook/{0}",secretHookId,secretId);
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
_postData = string.Format("{{ \"data\": {{   \"arguments\": {{     \"dirty\": \"{0}\",      \"value\": \"{1}\"     }},    \"database\": {{     \"dirty\": \"{2}\",      \"value\": \"{3}\"     }},    \"description\": {{     \"dirty\": \"{4}\",      \"value\": \"{5}\"     }},    \"eventActionId\": {{     \"dirty\": \"{6}\",      \"value\": \"{7}\"     }},    \"failureMessage\": {{     \"dirty\": \"{8}\",      \"value\": \"{9}\"     }},    \"name\": {{     \"dirty\": \"{10}\",      \"value\": \"{11}\"     }},    \"parameters\": {12},    \"port\": {{     \"dirty\": \"{13}\",      \"value\": \"{14}\"     }},    \"prePostOption\": {{     \"dirty\": \"{15}\",      \"value\": \"{16}\"     }},    \"privilegedSecretId\": {{     \"dirty\": \"{17}\",      \"value\": \"{18}\"     }},    \"scriptId\": {{     \"dirty\": \"{19}\",      \"value\": \"{20}\"     }},    \"scriptTypeId\": {{     \"dirty\": \"{21}\",      \"value\": \"{22}\"     }},    \"serverKeyDigest\": {{     \"dirty\": \"{23}\",      \"value\": \"{24}\"     }},    \"serverName\": {{     \"dirty\": \"{25}\",      \"value\": \"{26}\"     }},    \"sortOrder\": {{     \"dirty\": \"{27}\",      \"value\": \"{28}\"     }},    \"sshKeySecretId\": {{     \"dirty\": \"{29}\",      \"value\": \"{30}\"     }},    \"status\": {{     \"dirty\": \"{31}\",      \"value\": \"{32}\"     }},    \"stopOnFailure\": {{     \"dirty\": \"{33}\",      \"value\": \"{34}\"     }}   }} }}",dirty,value,database_dirty,database_value,description_dirty,description_value,eventActionId_dirty,eventActionId_value,failureMessage_dirty,failureMessage_value,name_dirty,name_value,parameters,port_dirty,port_value,prePostOption_dirty,prePostOption_value,privilegedSecretId_dirty,privilegedSecretId_value,scriptId_dirty,scriptId_value,scriptTypeId_dirty,scriptTypeId_value,serverKeyDigest_dirty,serverKeyDigest_value,serverName_dirty,serverName_value,sortOrder_dirty,sortOrder_value,sshKeySecretId_dirty,sshKeySecretId_value,status_dirty,status_value,stopOnFailure_dirty,stopOnFailure_value);
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
    
    public TY_Update_Secret_Hook() {
    }
    
    public TY_Update_Secret_Hook(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string secretHookId, 
                string secretId, 
                string dirty, 
                string value, 
                string database_dirty, 
                string database_value, 
                string description_dirty, 
                string description_value, 
                string eventActionId_dirty, 
                string eventActionId_value, 
                string failureMessage_dirty, 
                string failureMessage_value, 
                string name_dirty, 
                string name_value, 
                string parameters, 
                string port_dirty, 
                string port_value, 
                string prePostOption_dirty, 
                string prePostOption_value, 
                string privilegedSecretId_dirty, 
                string privilegedSecretId_value, 
                string scriptId_dirty, 
                string scriptId_value, 
                string scriptTypeId_dirty, 
                string scriptTypeId_value, 
                string serverKeyDigest_dirty, 
                string serverKeyDigest_value, 
                string serverName_dirty, 
                string serverName_value, 
                string sortOrder_dirty, 
                string sortOrder_value, 
                string sshKeySecretId_dirty, 
                string sshKeySecretId_value, 
                string status_dirty, 
                string status_value, 
                string stopOnFailure_dirty, 
                string stopOnFailure_value) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.secretHookId = secretHookId;
        this.secretId = secretId;
        this.dirty = dirty;
        this.value = value;
        this.database_dirty = database_dirty;
        this.database_value = database_value;
        this.description_dirty = description_dirty;
        this.description_value = description_value;
        this.eventActionId_dirty = eventActionId_dirty;
        this.eventActionId_value = eventActionId_value;
        this.failureMessage_dirty = failureMessage_dirty;
        this.failureMessage_value = failureMessage_value;
        this.name_dirty = name_dirty;
        this.name_value = name_value;
        this.parameters = parameters;
        this.port_dirty = port_dirty;
        this.port_value = port_value;
        this.prePostOption_dirty = prePostOption_dirty;
        this.prePostOption_value = prePostOption_value;
        this.privilegedSecretId_dirty = privilegedSecretId_dirty;
        this.privilegedSecretId_value = privilegedSecretId_value;
        this.scriptId_dirty = scriptId_dirty;
        this.scriptId_value = scriptId_value;
        this.scriptTypeId_dirty = scriptTypeId_dirty;
        this.scriptTypeId_value = scriptTypeId_value;
        this.serverKeyDigest_dirty = serverKeyDigest_dirty;
        this.serverKeyDigest_value = serverKeyDigest_value;
        this.serverName_dirty = serverName_dirty;
        this.serverName_value = serverName_value;
        this.sortOrder_dirty = sortOrder_dirty;
        this.sortOrder_value = sortOrder_value;
        this.sshKeySecretId_dirty = sshKeySecretId_dirty;
        this.sshKeySecretId_value = sshKeySecretId_value;
        this.status_dirty = status_dirty;
        this.status_value = status_value;
        this.stopOnFailure_dirty = stopOnFailure_dirty;
        this.stopOnFailure_value = stopOnFailure_value;
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