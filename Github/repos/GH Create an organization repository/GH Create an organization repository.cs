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
    public class GH_Create_an_organization_repository : IActivityAsync
    {


    
    public string Jsonkeypath = "repos";
    
    public string Accept = "";
    
    public string password1 = "";
    
    public string Username = "";
    
    public string org = "";
    
    public string name_p = "";
    
    public string description_p = "";
    
    public string homepage = "";
    
    public string @private = "";
    
    public string visibility = "";
    
    public string has_issues = "";
    
    public string has_projects = "";
    
    public string has_wiki = "";
    
    public string is_template = "";
    
    public string team_id = "";
    
    public string auto_init = "";
    
    public string gitignore_template = "";
    
    public string license_template = "";
    
    public string allow_squash_merge = "";
    
    public string allow_merge_commit = "";
    
    public string allow_rebase_merge = "";
    
    public string delete_branch_on_merge = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string endPoint = "https://api.github.com";
    
    private string httpMethod = "POST";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = string.Format("/orgs/{0}/repos",org);
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
_postData = string.Format("{{ \"name\": \"{0}\",  \"description\": \"{1}\",  \"homepage\": \"{2}\",  \"private\": \"{3}\",  \"visibility\": \"{4}\",  \"has_issues\": \"{5}\",  \"has_projects\": \"{6}\",  \"has_wiki\": \"{7}\",  \"is_template\": \"{8}\",  \"team_id\": \"{9}\",  \"auto_init\": \"{10}\",  \"gitignore_template\": \"{11}\",  \"license_template\": \"{12}\",  \"allow_squash_merge\": \"{13}\",  \"allow_merge_commit\": \"{14}\",  \"allow_rebase_merge\": \"{15}\",  \"delete_branch_on_merge\": \"{16}\" }}",name_p,description_p,homepage,private,visibility,has_issues,has_projects,has_wiki,is_template,team_id,auto_init,gitignore_template,license_template,allow_squash_merge,allow_merge_commit,allow_rebase_merge,delete_branch_on_merge);
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
    
    public GH_Create_an_organization_repository() {
    }
    
    public GH_Create_an_organization_repository(
                string Jsonkeypath, 
                string Accept, 
                string password1, 
                string Username, 
                string org, 
                string name_p, 
                string description_p, 
                string homepage, 
                string @private, 
                string visibility, 
                string has_issues, 
                string has_projects, 
                string has_wiki, 
                string is_template, 
                string team_id, 
                string auto_init, 
                string gitignore_template, 
                string license_template, 
                string allow_squash_merge, 
                string allow_merge_commit, 
                string allow_rebase_merge, 
                string delete_branch_on_merge) {
        this.Jsonkeypath = Jsonkeypath;
        this.Accept = Accept;
        this.password1 = password1;
        this.Username = Username;
        this.org = org;
        this.name_p = name_p;
        this.description_p = description_p;
        this.homepage = homepage;
        this.private = private;
        this.visibility = visibility;
        this.has_issues = has_issues;
        this.has_projects = has_projects;
        this.has_wiki = has_wiki;
        this.is_template = is_template;
        this.team_id = team_id;
        this.auto_init = auto_init;
        this.gitignore_template = gitignore_template;
        this.license_template = license_template;
        this.allow_squash_merge = allow_squash_merge;
        this.allow_merge_commit = allow_merge_commit;
        this.allow_rebase_merge = allow_rebase_merge;
        this.delete_branch_on_merge = delete_branch_on_merge;
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