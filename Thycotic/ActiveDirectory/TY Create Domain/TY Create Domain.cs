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
    public class TY_Create_Domain : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "domains";
    
    public string password1 = "";
    
    public string active = "";
    
    public string discoverSpecificOUs = "";
    
    public string domainName = "";
    
    public string enableDiscovery = "";
    
    public string enableLogin = "";
    
    public string friendlyName = "";
    
    public string requireDuoAuthentication = "";
    
    public string requireEmailAuthentication = "";
    
    public string requireFido2Authentication = "";
    
    public string requireOATHAuthentication = "";
    
    public string requireRadiusAuthentication = "";
    
    public string siteId = "";
    
    public string syncSecretId = "";
    
    public string useAES256 = "";
    
    public string useSecureLDAP = "";
    
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
_uriBuilderPath = "SecretServer/api/v1/active-directory/domains";
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
_postData = string.Format("{{ \"active\": \"{0}\",  \"discoverSpecificOUs\": \"{1}\",  \"domainName\": \"{2}\",  \"enableDiscovery\": \"{3}\",  \"enableLogin\": \"{4}\",  \"friendlyName\": \"{5}\",  \"requireDuoAuthentication\": \"{6}\",  \"requireEmailAuthentication\": \"{7}\",  \"requireFido2Authentication\": \"{8}\",  \"requireOATHAuthentication\": \"{9}\",  \"requireRadiusAuthentication\": \"{10}\",  \"siteId\": \"{11}\",  \"syncSecretId\": \"{12}\",  \"useAES256\": \"{13}\",  \"useSecureLDAP\": \"{14}\" }}",active,discoverSpecificOUs,domainName,enableDiscovery,enableLogin,friendlyName,requireDuoAuthentication,requireEmailAuthentication,requireFido2Authentication,requireOATHAuthentication,requireRadiusAuthentication,siteId,syncSecretId,useAES256,useSecureLDAP);
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
    
    public TY_Create_Domain() {
    }
    
    public TY_Create_Domain(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string active, 
                string discoverSpecificOUs, 
                string domainName, 
                string enableDiscovery, 
                string enableLogin, 
                string friendlyName, 
                string requireDuoAuthentication, 
                string requireEmailAuthentication, 
                string requireFido2Authentication, 
                string requireOATHAuthentication, 
                string requireRadiusAuthentication, 
                string siteId, 
                string syncSecretId, 
                string useAES256, 
                string useSecureLDAP) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.active = active;
        this.discoverSpecificOUs = discoverSpecificOUs;
        this.domainName = domainName;
        this.enableDiscovery = enableDiscovery;
        this.enableLogin = enableLogin;
        this.friendlyName = friendlyName;
        this.requireDuoAuthentication = requireDuoAuthentication;
        this.requireEmailAuthentication = requireEmailAuthentication;
        this.requireFido2Authentication = requireFido2Authentication;
        this.requireOATHAuthentication = requireOATHAuthentication;
        this.requireRadiusAuthentication = requireRadiusAuthentication;
        this.siteId = siteId;
        this.syncSecretId = syncSecretId;
        this.useAES256 = useAES256;
        this.useSecureLDAP = useSecureLDAP;
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