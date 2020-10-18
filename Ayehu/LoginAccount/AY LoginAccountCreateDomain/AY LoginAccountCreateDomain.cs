using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.Ayehu
{
    public class AY_LoginAccountCreateDomain : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "createDomain";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string server = "";
    
    public string user = "";
    
    public string password = "";
    
    public string dateCreated = "";
    
    public string dateModified = "";
    
    public string userCreatedBy = "";
    
    public string userModifiedBy = "";
    
    public string port = "";
    
    public string deleted = "";
    
    public string cloudTenantId = "";
    
    public string cloudTenantName = "";
    
    public string clientId = "";
    
    public string activeDirectorySourceType = "";
    
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
_uriBuilderPath = "Server/Api/loginAccount/createDomain";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"name\": \"{1}\",  \"server\": \"{2}\",  \"user\": \"{3}\",  \"password\": \"{4}\",  \"dateCreated\": \"{5}\",  \"dateModified\": \"{6}\",  \"userCreatedBy\": \"{7}\",  \"userModifiedBy\": \"{8}\",  \"port\": \"{9}\",  \"deleted\": \"{10}\",  \"cloudTenantId\": \"{11}\",  \"cloudTenantName\": \"{12}\",  \"clientId\": \"{13}\",  \"activeDirectorySourceType\": \"{14}\" }}",id_p,name_p,server,user,password,dateCreated,dateModified,userCreatedBy,userModifiedBy,port,deleted,cloudTenantId,cloudTenantName,clientId,activeDirectorySourceType);
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
_headers = new Dictionary<string, string>() { {"authorization","Bearer " + password1} };
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
    
    public AY_LoginAccountCreateDomain() {
    }
    
    public AY_LoginAccountCreateDomain(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string name_p, 
                string server, 
                string user, 
                string password, 
                string dateCreated, 
                string dateModified, 
                string userCreatedBy, 
                string userModifiedBy, 
                string port, 
                string deleted, 
                string cloudTenantId, 
                string cloudTenantName, 
                string clientId, 
                string activeDirectorySourceType) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.name_p = name_p;
        this.server = server;
        this.user = user;
        this.password = password;
        this.dateCreated = dateCreated;
        this.dateModified = dateModified;
        this.userCreatedBy = userCreatedBy;
        this.userModifiedBy = userModifiedBy;
        this.port = port;
        this.deleted = deleted;
        this.cloudTenantId = cloudTenantId;
        this.cloudTenantName = cloudTenantName;
        this.clientId = clientId;
        this.activeDirectorySourceType = activeDirectorySourceType;
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