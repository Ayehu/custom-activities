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
    public class TY_Update_Password_Type : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string active = "";
    
    public string canEdit = "";
    
    public string customPort = "";
    
    public string exitCommand = "";
    
    public string hasCommands = "";
    
    public string heartbeatScriptArgs = "";
    
    public string heartbeatScriptId = "";
    
    public string ignoreSSL = "";
    
    public string isWeb = "";
    
    public string ldapConnectionSettingsId = "";
    
    public string lineEnding = "";
    
    public string mainframeConnectionString = "";
    
    public string name_p = "";
    
    public string odbcConnectionString = "";
    
    public string rpcScriptArgs = "";
    
    public string rpcScriptId = "";
    
    public string runnerType = "";
    
    public string scanItemTemplateId = "";
    
    public string useSSL = "";
    
    public string useUsernameAndPassword = "";
    
    public string validForTakeover = "";
    
    public string windowsCustomPorts = "";
    
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
_uriBuilderPath = string.Format("SecretServer/api/v1/remote-password-changing/password-types/{0}",id_p);
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
_postData = string.Format("{{ \"active\": \"{0}\",  \"canEdit\": \"{1}\",  \"customPort\": \"{2}\",  \"exitCommand\": \"{3}\",  \"hasCommands\": \"{4}\",  \"heartbeatScriptArgs\": \"{5}\",  \"heartbeatScriptId\": \"{6}\",  \"ignoreSSL\": \"{7}\",  \"isWeb\": \"{8}\",  \"ldapConnectionSettingsId\": \"{9}\",  \"lineEnding\": \"{10}\",  \"mainframeConnectionString\": \"{11}\",  \"name\": \"{12}\",  \"odbcConnectionString\": \"{13}\",  \"rpcScriptArgs\": \"{14}\",  \"rpcScriptId\": \"{15}\",  \"runnerType\": \"{16}\",  \"scanItemTemplateId\": \"{17}\",  \"useSSL\": \"{18}\",  \"useUsernameAndPassword\": \"{19}\",  \"validForTakeover\": \"{20}\",  \"windowsCustomPorts\": \"{21}\" }}",active,canEdit,customPort,exitCommand,hasCommands,heartbeatScriptArgs,heartbeatScriptId,ignoreSSL,isWeb,ldapConnectionSettingsId,lineEnding,mainframeConnectionString,name_p,odbcConnectionString,rpcScriptArgs,rpcScriptId,runnerType,scanItemTemplateId,useSSL,useUsernameAndPassword,validForTakeover,windowsCustomPorts);
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
    
    public TY_Update_Password_Type() {
    }
    
    public TY_Update_Password_Type(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string active, 
                string canEdit, 
                string customPort, 
                string exitCommand, 
                string hasCommands, 
                string heartbeatScriptArgs, 
                string heartbeatScriptId, 
                string ignoreSSL, 
                string isWeb, 
                string ldapConnectionSettingsId, 
                string lineEnding, 
                string mainframeConnectionString, 
                string name_p, 
                string odbcConnectionString, 
                string rpcScriptArgs, 
                string rpcScriptId, 
                string runnerType, 
                string scanItemTemplateId, 
                string useSSL, 
                string useUsernameAndPassword, 
                string validForTakeover, 
                string windowsCustomPorts) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.active = active;
        this.canEdit = canEdit;
        this.customPort = customPort;
        this.exitCommand = exitCommand;
        this.hasCommands = hasCommands;
        this.heartbeatScriptArgs = heartbeatScriptArgs;
        this.heartbeatScriptId = heartbeatScriptId;
        this.ignoreSSL = ignoreSSL;
        this.isWeb = isWeb;
        this.ldapConnectionSettingsId = ldapConnectionSettingsId;
        this.lineEnding = lineEnding;
        this.mainframeConnectionString = mainframeConnectionString;
        this.name_p = name_p;
        this.odbcConnectionString = odbcConnectionString;
        this.rpcScriptArgs = rpcScriptArgs;
        this.rpcScriptId = rpcScriptId;
        this.runnerType = runnerType;
        this.scanItemTemplateId = scanItemTemplateId;
        this.useSSL = useSSL;
        this.useUsernameAndPassword = useUsernameAndPassword;
        this.validForTakeover = validForTakeover;
        this.windowsCustomPorts = windowsCustomPorts;
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