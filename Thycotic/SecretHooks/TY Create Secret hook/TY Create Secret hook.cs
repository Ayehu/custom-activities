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
    public class TY_Create_Secret_hook : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "hook";
    
    public string password1 = "";
    
    public string secretId = "";
    
    public string arguments = "";
    
    public string database = "";
    
    public string description_p = "";
    
    public string eventActionId = "";
    
    public string failureMessage = "";
    
    public string name_p = "";
    
    public string parameters = "";
    
    public string port = "";
    
    public string prePostOption = "";
    
    public string privilegedSecretId = "";
    
    public string scriptId = "";
    
    public string data_secretId = "";
    
    public string serverKeyDigest = "";
    
    public string serverName = "";
    
    public string sshKeySecretId = "";
    
    public string stopOnFailure = "";
    
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
_uriBuilderPath = string.Format("SecretServer/api/v1/secret-detail/{0}/hook",secretId);
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
_postData = string.Format("{{ \"data\": {{   \"arguments\": \"{0}\",    \"database\": \"{1}\",    \"description\": \"{2}\",    \"eventActionId\": \"{3}\",    \"failureMessage\": \"{4}\",    \"name\": \"{5}\",    \"parameters\": {6},    \"port\": \"{7}\",    \"prePostOption\": \"{8}\",    \"privilegedSecretId\": \"{9}\",    \"scriptId\": \"{10}\",    \"secretId\": \"{11}\",    \"serverKeyDigest\": \"{12}\",    \"serverName\": \"{13}\",    \"sshKeySecretId\": \"{14}\",    \"stopOnFailure\": \"{15}\"   }} }}",arguments,database,description_p,eventActionId,failureMessage,name_p,parameters,port,prePostOption,privilegedSecretId,scriptId,data_secretId,serverKeyDigest,serverName,sshKeySecretId,stopOnFailure);
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
    
    public TY_Create_Secret_hook() {
    }
    
    public TY_Create_Secret_hook(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string secretId, 
                string arguments, 
                string database, 
                string description_p, 
                string eventActionId, 
                string failureMessage, 
                string name_p, 
                string parameters, 
                string port, 
                string prePostOption, 
                string privilegedSecretId, 
                string scriptId, 
                string data_secretId, 
                string serverKeyDigest, 
                string serverName, 
                string sshKeySecretId, 
                string stopOnFailure) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.secretId = secretId;
        this.arguments = arguments;
        this.database = database;
        this.description_p = description_p;
        this.eventActionId = eventActionId;
        this.failureMessage = failureMessage;
        this.name_p = name_p;
        this.parameters = parameters;
        this.port = port;
        this.prePostOption = prePostOption;
        this.privilegedSecretId = privilegedSecretId;
        this.scriptId = scriptId;
        this.data_secretId = data_secretId;
        this.serverKeyDigest = serverKeyDigest;
        this.serverName = serverName;
        this.sshKeySecretId = sshKeySecretId;
        this.stopOnFailure = stopOnFailure;
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