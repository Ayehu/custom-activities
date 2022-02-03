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
    public class GH_Create_a_check_run : IActivityAsync
    {


    
    public string Jsonkeypath = "check-runs";
    
    public string Accept = "";
    
    public string password1 = "";
    
    public string Username = "";
    
    public string owner = "";
    
    public string repo = "";
    
    public string name_p = "";
    
    public string head_sha = "";
    
    public string details_url = "";
    
    public string external_id = "";
    
    public string status = "";
    
    public string started_at = "";
    
    public string conclusion = "";
    
    public string completed_at = "";
    
    public string title = "";
    
    public string summary = "";
    
    public string text = "";
    
    public string annotations = "";
    
    public string images = "";
    
    public string actions = "";
    
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
_uriBuilderPath = string.Format("/repos/{0}/{1}/check-runs",owner,repo);
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
_postData = string.Format("{{ \"name\": \"{0}\",  \"head_sha\": \"{1}\",  \"details_url\": \"{2}\",  \"external_id\": \"{3}\",  \"status\": \"{4}\",  \"started_at\": \"{5}\",  \"conclusion\": \"{6}\",  \"completed_at\": \"{7}\",  \"output\": {{   \"title\": \"{8}\",    \"summary\": \"{9}\",    \"text\": \"{10}\",    \"annotations\": {11},    \"images\": {12}   }},  \"actions\": {13} }}",name_p,head_sha,details_url,external_id,status,started_at,conclusion,completed_at,title,summary,text,annotations,images,actions);
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
    
    public GH_Create_a_check_run() {
    }
    
    public GH_Create_a_check_run(
                string Jsonkeypath, 
                string Accept, 
                string password1, 
                string Username, 
                string owner, 
                string repo, 
                string name_p, 
                string head_sha, 
                string details_url, 
                string external_id, 
                string status, 
                string started_at, 
                string conclusion, 
                string completed_at, 
                string title, 
                string summary, 
                string text, 
                string annotations, 
                string images, 
                string actions) {
        this.Jsonkeypath = Jsonkeypath;
        this.Accept = Accept;
        this.password1 = password1;
        this.Username = Username;
        this.owner = owner;
        this.repo = repo;
        this.name_p = name_p;
        this.head_sha = head_sha;
        this.details_url = details_url;
        this.external_id = external_id;
        this.status = status;
        this.started_at = started_at;
        this.conclusion = conclusion;
        this.completed_at = completed_at;
        this.title = title;
        this.summary = summary;
        this.text = text;
        this.annotations = annotations;
        this.images = images;
        this.actions = actions;
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