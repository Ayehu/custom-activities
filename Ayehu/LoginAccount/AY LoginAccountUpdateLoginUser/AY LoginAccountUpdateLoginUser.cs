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
    public class AY_LoginAccountUpdateLoginUser : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "updateUser";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string fName = "";
    
    public string lName = "";
    
    public string email = "";
    
    public string mobilePhoneNumber = "";
    
    public string roleId = "";
    
    public string roleName = "";
    
    public string password = "";
    
    public string activeDirectoryId = "";
    
    public string ayehuIm = "";
    
    public string employeeNumber = "";
    
    public string userGroups = "";
    
    public string _domainId = "";
    
    public string _domainName = "";
    
    public string isPasswordEncrypted = "";
    
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
_uriBuilderPath = "Server/Api/loginAccount/updateUser";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"name\": \"{1}\",  \"fName\": \"{2}\",  \"lName\": \"{3}\",  \"email\": \"{4}\",  \"mobilePhoneNumber\": \"{5}\",  \"roleId\": \"{6}\",  \"roleName\": \"{7}\",  \"password\": \"{8}\",  \"activeDirectoryId\": \"{9}\",  \"ayehuIm\": \"{10}\",  \"employeeNumber\": \"{11}\",  \"userGroups\": {12},  \"domainId\": \"{13}\",  \"domainName\": \"{14}\",  \"isPasswordEncrypted\": \"{15}\" }}",id_p,name_p,fName,lName,email,mobilePhoneNumber,roleId,roleName,password,activeDirectoryId,ayehuIm,employeeNumber,userGroups,_domainId,_domainName,isPasswordEncrypted);
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
    
    public AY_LoginAccountUpdateLoginUser() {
    }
    
    public AY_LoginAccountUpdateLoginUser(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string name_p, 
                string fName, 
                string lName, 
                string email, 
                string mobilePhoneNumber, 
                string roleId, 
                string roleName, 
                string password, 
                string activeDirectoryId, 
                string ayehuIm, 
                string employeeNumber, 
                string userGroups, 
                string _domainId, 
                string _domainName, 
                string isPasswordEncrypted) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.name_p = name_p;
        this.fName = fName;
        this.lName = lName;
        this.email = email;
        this.mobilePhoneNumber = mobilePhoneNumber;
        this.roleId = roleId;
        this.roleName = roleName;
        this.password = password;
        this.activeDirectoryId = activeDirectoryId;
        this.ayehuIm = ayehuIm;
        this.employeeNumber = employeeNumber;
        this.userGroups = userGroups;
        this._domainId = _domainId;
        this._domainName = _domainName;
        this.isPasswordEncrypted = isPasswordEncrypted;
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