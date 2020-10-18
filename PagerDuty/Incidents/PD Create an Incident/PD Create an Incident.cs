using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.PagerDuty
{
    public class PD_Create_an_Incident : IActivityAsync
    {


    
    public string Jsonkeypath = "incidents";
    
    public string password1 = "";
    
    public string From = "";
    
    public string type_p = "";
    
    public string title = "";
    
    public string id_p = "";
    
    public string service_type = "";
    
    public string priority_id = "";
    
    public string priority_type = "";
    
    public string urgency = "";
    
    public string body_type = "";
    
    public string details = "";
    
    public string incident_key = "";
    
    public string assignments = "";
    
    public string escalation_policy_id = "";
    
    public string escalation_policy_type = "";
    
    public string conference_number = "";
    
    public string conference_url = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string endPoint = "https://api.pagerduty.com";
    
    private string httpMethod = "POST";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = "/incidents";
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
_postData = string.Format("{{ \"incident\": {{   \"type\": \"{0}\",    \"title\": \"{1}\",    \"service\": {{     \"id\": \"{2}\",      \"type\": \"{3}\"     }},    \"priority\": {{     \"id\": \"{4}\",      \"type\": \"{5}\"     }},    \"urgency\": \"{6}\",    \"body\": {{     \"type\": \"{7}\",      \"details\": \"{8}\"     }},    \"incident_key\": \"{9}\",    \"assignments\": {10},    \"escalation_policy\": {{     \"id\": \"{11}\",      \"type\": \"{12}\"     }},    \"conference_bridge\": {{     \"conference_number\": \"{13}\",      \"conference_url\": \"{14}\"     }}   }} }}",type_p,title,id_p,service_type,priority_id,priority_type,urgency,body_type,details,incident_key,assignments,escalation_policy_id,escalation_policy_type,conference_number,conference_url);
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
_headers = new Dictionary<string, string>() { {"Authorization","Token token = " + password1},{"From",From} };
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
    
    public PD_Create_an_Incident() {
    }
    
    public PD_Create_an_Incident(
                string Jsonkeypath, 
                string password1, 
                string From, 
                string type_p, 
                string title, 
                string id_p, 
                string service_type, 
                string priority_id, 
                string priority_type, 
                string urgency, 
                string body_type, 
                string details, 
                string incident_key, 
                string assignments, 
                string escalation_policy_id, 
                string escalation_policy_type, 
                string conference_number, 
                string conference_url) {
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.From = From;
        this.type_p = type_p;
        this.title = title;
        this.id_p = id_p;
        this.service_type = service_type;
        this.priority_id = priority_id;
        this.priority_type = priority_type;
        this.urgency = urgency;
        this.body_type = body_type;
        this.details = details;
        this.incident_key = incident_key;
        this.assignments = assignments;
        this.escalation_policy_id = escalation_policy_id;
        this.escalation_policy_type = escalation_policy_type;
        this.conference_number = conference_number;
        this.conference_url = conference_url;
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