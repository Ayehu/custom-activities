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
    public class GH_Update_a_repository : IActivityAsync
    {


    
    public string Jsonkeypath = "";
    
    public string Accept = "";
    
    public string password1 = "";
    
    public string Username = "";
    
    public string owner = "";
    
    public string repo = "";
    
    public string name_p = "";
    
    public string description_p = "";
    
    public string homepage = "";
    
    public string @private = "";
    
    public string visibility = "";
    
    public string has_issues = "";
    
    public string has_projects = "";
    
    public string has_wiki = "";
    
    public string is_template = "";
    
    public string default_branch = "";
    
    public string allow_squash_merge = "";
    
    public string allow_merge_commit = "";
    
    public string allow_rebase_merge = "";
    
    public string delete_branch_on_merge = "";
    
    public string archived = "";
    
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
_uriBuilderPath = string.Format("/repos/{0}/{1}",owner,repo);
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
_postData = string.Format("{{ \"name\": \"{0}\",  \"description\": \"{1}\",  \"homepage\": \"{2}\",  \"private\": \"{3}\",  \"visibility\": \"{4}\",  \"has_issues\": \"{5}\",  \"has_projects\": \"{6}\",  \"has_wiki\": \"{7}\",  \"is_template\": \"{8}\",  \"default_branch\": \"{9}\",  \"allow_squash_merge\": \"{10}\",  \"allow_merge_commit\": \"{11}\",  \"allow_rebase_merge\": \"{12}\",  \"delete_branch_on_merge\": \"{13}\",  \"archived\": \"{14}\" }}",name_p,description_p,homepage,private,visibility,has_issues,has_projects,has_wiki,is_template,default_branch,allow_squash_merge,allow_merge_commit,allow_rebase_merge,delete_branch_on_merge,archived);
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
    
    public GH_Update_a_repository() {
    }
    
    public GH_Update_a_repository(
                string Jsonkeypath, 
                string Accept, 
                string password1, 
                string Username, 
                string owner, 
                string repo, 
                string name_p, 
                string description_p, 
                string homepage, 
                string @private, 
                string visibility, 
                string has_issues, 
                string has_projects, 
                string has_wiki, 
                string is_template, 
                string default_branch, 
                string allow_squash_merge, 
                string allow_merge_commit, 
                string allow_rebase_merge, 
                string delete_branch_on_merge, 
                string archived) {
        this.Jsonkeypath = Jsonkeypath;
        this.Accept = Accept;
        this.password1 = password1;
        this.Username = Username;
        this.owner = owner;
        this.repo = repo;
        this.name_p = name_p;
        this.description_p = description_p;
        this.homepage = homepage;
        this.private = private;
        this.visibility = visibility;
        this.has_issues = has_issues;
        this.has_projects = has_projects;
        this.has_wiki = has_wiki;
        this.is_template = is_template;
        this.default_branch = default_branch;
        this.allow_squash_merge = allow_squash_merge;
        this.allow_merge_commit = allow_merge_commit;
        this.allow_rebase_merge = allow_rebase_merge;
        this.delete_branch_on_merge = delete_branch_on_merge;
        this.archived = archived;
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