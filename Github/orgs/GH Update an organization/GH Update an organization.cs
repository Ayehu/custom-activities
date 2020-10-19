using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.Github
{
    public class GH_Update_an_organization : IActivityAsync
    {


    
    public string Jsonkeypath = "";
    
    public string Accept = "";
    
    public string password1 = "";
    
    public string Username = "";
    
    public string org = "";
    
    public string billing_email = "";
    
    public string company = "";
    
    public string email = "";
    
    public string twitter_username = "";
    
    public string location = "";
    
    public string name_p = "";
    
    public string description_p = "";
    
    public string has_organization_projects = "";
    
    public string has_repository_projects = "";
    
    public string default_repository_permission = "";
    
    public string members_can_create_repositories = "";
    
    public string members_can_create_internal_repositories = "";
    
    public string members_can_create_private_repositories = "";
    
    public string members_can_create_public_repositories = "";
    
    public string members_allowed_repository_creation_type = "";
    
    public string members_can_create_pages = "";
    
    public string blog = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string endPoint = "https://api.github.com";
    
    private string httpMethod = "PATCH";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = string.Format("/orgs/{0}",org);
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
_postData = string.Format("{{ \"billing_email\": \"{0}\",  \"company\": \"{1}\",  \"email\": \"{2}\",  \"twitter_username\": \"{3}\",  \"location\": \"{4}\",  \"name\": \"{5}\",  \"description\": \"{6}\",  \"has_organization_projects\": \"{7}\",  \"has_repository_projects\": \"{8}\",  \"default_repository_permission\": \"{9}\",  \"members_can_create_repositories\": \"{10}\",  \"members_can_create_internal_repositories\": \"{11}\",  \"members_can_create_private_repositories\": \"{12}\",  \"members_can_create_public_repositories\": \"{13}\",  \"members_allowed_repository_creation_type\": \"{14}\",  \"members_can_create_pages\": \"{15}\",  \"blog\": \"{16}\" }}",billing_email,company,email,twitter_username,location,name_p,description_p,has_organization_projects,has_repository_projects,default_repository_permission,members_can_create_repositories,members_can_create_internal_repositories,members_can_create_private_repositories,members_can_create_public_repositories,members_allowed_repository_creation_type,members_can_create_pages,blog);
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
_headers = new Dictionary<string, string>() { {"User-Agent","" + Username},{"Accept",Accept},{"authorization","token " + password1} };
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
    
    public GH_Update_an_organization() {
    }
    
    public GH_Update_an_organization(
                string Jsonkeypath, 
                string Accept, 
                string password1, 
                string Username, 
                string org, 
                string billing_email, 
                string company, 
                string email, 
                string twitter_username, 
                string location, 
                string name_p, 
                string description_p, 
                string has_organization_projects, 
                string has_repository_projects, 
                string default_repository_permission, 
                string members_can_create_repositories, 
                string members_can_create_internal_repositories, 
                string members_can_create_private_repositories, 
                string members_can_create_public_repositories, 
                string members_allowed_repository_creation_type, 
                string members_can_create_pages, 
                string blog) {
        this.Jsonkeypath = Jsonkeypath;
        this.Accept = Accept;
        this.password1 = password1;
        this.Username = Username;
        this.org = org;
        this.billing_email = billing_email;
        this.company = company;
        this.email = email;
        this.twitter_username = twitter_username;
        this.location = location;
        this.name_p = name_p;
        this.description_p = description_p;
        this.has_organization_projects = has_organization_projects;
        this.has_repository_projects = has_repository_projects;
        this.default_repository_permission = default_repository_permission;
        this.members_can_create_repositories = members_can_create_repositories;
        this.members_can_create_internal_repositories = members_can_create_internal_repositories;
        this.members_can_create_private_repositories = members_can_create_private_repositories;
        this.members_can_create_public_repositories = members_can_create_public_repositories;
        this.members_allowed_repository_creation_type = members_allowed_repository_creation_type;
        this.members_can_create_pages = members_can_create_pages;
        this.blog = blog;
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