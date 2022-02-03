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
    public class TY_Update_the_SSH_proxy_configuration : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "config";
    
    public string password1 = "";
    
    public string daysToKeepOperationalLogs = "";
    
    public string enableProxyInactivityTimeout = "";
    
    public string enableSshProxy = "";
    
    public string enableSshTerminal = "";
    
    public string enableSshTunneling = "";
    
    public string enableTerminalInactivityTimeout = "";
    
    public string isCloud = "";
    
    public string proxyInactivityTimeoutSeconds = "";
    
    public string proxyNewSecretsByDefault = "";
    
    public string sshHostKey = "";
    
    public string sshProxyBanner = "";
    
    public string sshProxyHostFingerprint = "";
    
    public string sshProxyPort = "";
    
    public string sshTerminalBanner = "";
    
    public string terminalInactivityTimeoutSeconds = "";
    
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
_uriBuilderPath = "SecretServer/api/v1/proxy/ssh/config";
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
_postData = string.Format("{{ \"daysToKeepOperationalLogs\": \"{0}\",  \"enableProxyInactivityTimeout\": \"{1}\",  \"enableSshProxy\": \"{2}\",  \"enableSshTerminal\": \"{3}\",  \"enableSshTunneling\": \"{4}\",  \"enableTerminalInactivityTimeout\": \"{5}\",  \"isCloud\": \"{6}\",  \"proxyInactivityTimeoutSeconds\": \"{7}\",  \"proxyNewSecretsByDefault\": \"{8}\",  \"sshHostKey\": \"{9}\",  \"sshProxyBanner\": \"{10}\",  \"sshProxyHostFingerprint\": \"{11}\",  \"sshProxyPort\": \"{12}\",  \"sshTerminalBanner\": \"{13}\",  \"terminalInactivityTimeoutSeconds\": \"{14}\" }}",daysToKeepOperationalLogs,enableProxyInactivityTimeout,enableSshProxy,enableSshTerminal,enableSshTunneling,enableTerminalInactivityTimeout,isCloud,proxyInactivityTimeoutSeconds,proxyNewSecretsByDefault,sshHostKey,sshProxyBanner,sshProxyHostFingerprint,sshProxyPort,sshTerminalBanner,terminalInactivityTimeoutSeconds);
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
    
    public TY_Update_the_SSH_proxy_configuration() {
    }
    
    public TY_Update_the_SSH_proxy_configuration(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string daysToKeepOperationalLogs, 
                string enableProxyInactivityTimeout, 
                string enableSshProxy, 
                string enableSshTerminal, 
                string enableSshTunneling, 
                string enableTerminalInactivityTimeout, 
                string isCloud, 
                string proxyInactivityTimeoutSeconds, 
                string proxyNewSecretsByDefault, 
                string sshHostKey, 
                string sshProxyBanner, 
                string sshProxyHostFingerprint, 
                string sshProxyPort, 
                string sshTerminalBanner, 
                string terminalInactivityTimeoutSeconds) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.daysToKeepOperationalLogs = daysToKeepOperationalLogs;
        this.enableProxyInactivityTimeout = enableProxyInactivityTimeout;
        this.enableSshProxy = enableSshProxy;
        this.enableSshTerminal = enableSshTerminal;
        this.enableSshTunneling = enableSshTunneling;
        this.enableTerminalInactivityTimeout = enableTerminalInactivityTimeout;
        this.isCloud = isCloud;
        this.proxyInactivityTimeoutSeconds = proxyInactivityTimeoutSeconds;
        this.proxyNewSecretsByDefault = proxyNewSecretsByDefault;
        this.sshHostKey = sshHostKey;
        this.sshProxyBanner = sshProxyBanner;
        this.sshProxyHostFingerprint = sshProxyHostFingerprint;
        this.sshProxyPort = sshProxyPort;
        this.sshTerminalBanner = sshTerminalBanner;
        this.terminalInactivityTimeoutSeconds = terminalInactivityTimeoutSeconds;
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