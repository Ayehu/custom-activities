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
    public class TY_Change_Secret_Password : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "change-password";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string comment = "";
    
    public string doubleLockPassword = "";
    
    public string forceCheckIn = "";
    
    public string includeInactive = "";
    
    public string newPassword = "";
    
    public string generatePassphrase = "";
    
    public string generateSshKeys = "";
    
    public string passphrase = "";
    
    public string privateKey = "";
    
    public string ticketNumber = "";
    
    public string ticketSystemId = "";
    
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
_uriBuilderPath = string.Format("SecretServer/api/v1/secrets/{0}/change-password",id_p);
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
_postData = string.Format("{{ \"comment\": \"{0}\",  \"doubleLockPassword\": \"{1}\",  \"forceCheckIn\": \"{2}\",  \"includeInactive\": \"{3}\",  \"newPassword\": \"{4}\",  \"sshKeyArgs\": {{   \"generatePassphrase\": \"{5}\",    \"generateSshKeys\": \"{6}\",    \"passphrase\": \"{7}\",    \"privateKey\": \"{8}\"   }},  \"ticketNumber\": \"{9}\",  \"ticketSystemId\": \"{10}\" }}",comment,doubleLockPassword,forceCheckIn,includeInactive,newPassword,generatePassphrase,generateSshKeys,passphrase,privateKey,ticketNumber,ticketSystemId);
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
    
    public TY_Change_Secret_Password() {
    }
    
    public TY_Change_Secret_Password(string endPoint, string Jsonkeypath, string password1, string id_p, string comment, string doubleLockPassword, string forceCheckIn, string includeInactive, string newPassword, string generatePassphrase, string generateSshKeys, string passphrase, string privateKey, string ticketNumber, string ticketSystemId) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.comment = comment;
        this.doubleLockPassword = doubleLockPassword;
        this.forceCheckIn = forceCheckIn;
        this.includeInactive = includeInactive;
        this.newPassword = newPassword;
        this.generatePassphrase = generatePassphrase;
        this.generateSshKeys = generateSshKeys;
        this.passphrase = passphrase;
        this.privateKey = privateKey;
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