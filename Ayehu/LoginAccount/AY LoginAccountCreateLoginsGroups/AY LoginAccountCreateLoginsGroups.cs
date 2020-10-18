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
    public class AY_LoginAccountCreateLoginsGroups : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "createLoginsGroups";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string userGroupDescription = "";
    
    public string site = "";
    
    public string activeDirectoryId = "";
    
    public string owners = "";
    
    public string groupMembers = "";
    
    public string ownersString = "";
    
    public string totalRecords = "";
    
    public string roleId = "";
    
    public string roleName = "";
    
    public string rolePriority = "";
    
    public string userGroupType = "";
    
    public string domainId = "";
    
    public string domainName = "";
    
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
_uriBuilderPath = "Server/Api/loginAccount/createLoginsGroups";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"name\": \"{1}\",  \"userGroupDescription\": \"{2}\",  \"site\": \"{3}\",  \"activeDirectoryId\": \"{4}\",  \"owners\": {5},  \"groupMembers\": {6},  \"ownersString\": \"{7}\",  \"totalRecords\": \"{8}\",  \"roleId\": \"{9}\",  \"roleName\": \"{10}\",  \"rolePriority\": \"{11}\",  \"userGroupType\": \"{12}\",  \"domainId\": \"{13}\",  \"domainName\": \"{14}\" }}",id_p,name_p,userGroupDescription,site,activeDirectoryId,owners,groupMembers,ownersString,totalRecords,roleId,roleName,rolePriority,userGroupType,domainId,domainName);
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
    
    public AY_LoginAccountCreateLoginsGroups() {
    }
    
    public AY_LoginAccountCreateLoginsGroups(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string name_p, 
                string userGroupDescription, 
                string site, 
                string activeDirectoryId, 
                string owners, 
                string groupMembers, 
                string ownersString, 
                string totalRecords, 
                string roleId, 
                string roleName, 
                string rolePriority, 
                string userGroupType, 
                string domainId, 
                string domainName) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.name_p = name_p;
        this.userGroupDescription = userGroupDescription;
        this.site = site;
        this.activeDirectoryId = activeDirectoryId;
        this.owners = owners;
        this.groupMembers = groupMembers;
        this.ownersString = ownersString;
        this.totalRecords = totalRecords;
        this.roleId = roleId;
        this.roleName = roleName;
        this.rolePriority = rolePriority;
        this.userGroupType = userGroupType;
        this.domainId = domainId;
        this.domainName = domainName;
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