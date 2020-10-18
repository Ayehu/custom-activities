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
    public class ZM_Create_a_Recording_Registrant : IActivityAsync
    {


    
    public string Jsonkeypath = "registrants";
    
    public string apikey = "";
    
    public string password1 = "";
    
    public string meetingId = "";
    
    public string email = "";
    
    public string first_name = "";
    
    public string last_name = "";
    
    public string address = "";
    
    public string city = "";
    
    public string country = "";
    
    public string zip = "";
    
    public string state = "";
    
    public string phone = "";
    
    public string industry = "";
    
    public string org = "";
    
    public string job_title = "";
    
    public string purchasing_time_frame = "";
    
    public string role_in_purchase_process = "";
    
    public string no_of_employees = "";
    
    public string comments = "";
    
    public string custom_questions = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string endPoint = "https://api.zoom.us";
    
    private string httpMethod = "POST";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = string.Format("v2/meetings/{0}/recordings/registrants",meetingId);
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
_postData = string.Format("{{ \"email\": \"{0}\",  \"first_name\": \"{1}\",  \"last_name\": \"{2}\",  \"address\": \"{3}\",  \"city\": \"{4}\",  \"country\": \"{5}\",  \"zip\": \"{6}\",  \"state\": \"{7}\",  \"phone\": \"{8}\",  \"industry\": \"{9}\",  \"org\": \"{10}\",  \"job_title\": \"{11}\",  \"purchasing_time_frame\": \"{12}\",  \"role_in_purchase_process\": \"{13}\",  \"no_of_employees\": \"{14}\",  \"comments\": \"{15}\",  \"custom_questions\": {16} }}",email,first_name,last_name,address,city,country,zip,state,phone,industry,org,job_title,purchasing_time_frame,role_in_purchase_process,no_of_employees,comments,custom_questions);
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
    
    public ZM_Create_a_Recording_Registrant() {
    }
    
    public ZM_Create_a_Recording_Registrant(
                string Jsonkeypath, 
                string apikey, 
                string password1, 
                string meetingId, 
                string email, 
                string first_name, 
                string last_name, 
                string address, 
                string city, 
                string country, 
                string zip, 
                string state, 
                string phone, 
                string industry, 
                string org, 
                string job_title, 
                string purchasing_time_frame, 
                string role_in_purchase_process, 
                string no_of_employees, 
                string comments, 
                string custom_questions) {
        this.Jsonkeypath = Jsonkeypath;
        this.apikey = apikey;
        this.password1 = password1;
        this.meetingId = meetingId;
        this.email = email;
        this.first_name = first_name;
        this.last_name = last_name;
        this.address = address;
        this.city = city;
        this.country = country;
        this.zip = zip;
        this.state = state;
        this.phone = phone;
        this.industry = industry;
        this.org = org;
        this.job_title = job_title;
        this.purchasing_time_frame = purchasing_time_frame;
        this.role_in_purchase_process = role_in_purchase_process;
        this.no_of_employees = no_of_employees;
        this.comments = comments;
        this.custom_questions = custom_questions;
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