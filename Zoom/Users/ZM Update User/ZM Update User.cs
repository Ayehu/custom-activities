using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.Zoom
{
    public class ZM_Update_User : IActivityAsync
    {


    
    public string Jsonkeypath = "";
    
    public string apikey = "";
    
    public string password1 = "";
    
    public string userId = "";
    
    public string first_name = "";
    
    public string last_name = "";
    
    public string type_p = "";
    
    public string pmi = "";
    
    public string use_pmi = "";
    
    public string timezone = "";
    
    public string language = "";
    
    public string dept = "";
    
    public string vanity_name = "";
    
    public string host_key = "";
    
    public string cms_user_id = "";
    
    public string job_title = "";
    
    public string company = "";
    
    public string location = "";
    
    public string phone_number = "";
    
    public string phone_country = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string endPoint = "https://api.zoom.us";
    
    private string httpMethod = "PATCH";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = string.Format("v2/users/{0}",userId);
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
_postData = string.Format("{{ \"first_name\": \"{0}\",  \"last_name\": \"{1}\",  \"type\": \"{2}\",  \"pmi\": \"{3}\",  \"use_pmi\": \"{4}\",  \"timezone\": \"{5}\",  \"language\": \"{6}\",  \"dept\": \"{7}\",  \"vanity_name\": \"{8}\",  \"host_key\": \"{9}\",  \"cms_user_id\": \"{10}\",  \"job_title\": \"{11}\",  \"company\": \"{12}\",  \"location\": \"{13}\",  \"phone_number\": \"{14}\",  \"phone_country\": \"{15}\" }}",first_name,last_name,type_p,pmi,use_pmi,timezone,language,dept,vanity_name,host_key,cms_user_id,job_title,company,location,phone_number,phone_country);
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
_headers = new Dictionary<string, string>() { {"authorization","Bearer " + AyehuHelper.JWTToken(apikey,password1,"HS256","JWT", 120)} };
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
    
    public ZM_Update_User() {
    }
    
    public ZM_Update_User(
                string Jsonkeypath, 
                string apikey, 
                string password1, 
                string userId, 
                string first_name, 
                string last_name, 
                string type_p, 
                string pmi, 
                string use_pmi, 
                string timezone, 
                string language, 
                string dept, 
                string vanity_name, 
                string host_key, 
                string cms_user_id, 
                string job_title, 
                string company, 
                string location, 
                string phone_number, 
                string phone_country) {
        this.Jsonkeypath = Jsonkeypath;
        this.apikey = apikey;
        this.password1 = password1;
        this.userId = userId;
        this.first_name = first_name;
        this.last_name = last_name;
        this.type_p = type_p;
        this.pmi = pmi;
        this.use_pmi = use_pmi;
        this.timezone = timezone;
        this.language = language;
        this.dept = dept;
        this.vanity_name = vanity_name;
        this.host_key = host_key;
        this.cms_user_id = cms_user_id;
        this.job_title = job_title;
        this.company = company;
        this.location = location;
        this.phone_number = phone_number;
        this.phone_country = phone_country;
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