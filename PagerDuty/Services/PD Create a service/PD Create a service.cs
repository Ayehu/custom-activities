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
    public class PD_Create_a_service : IActivityAsync
    {


    
    public string Jsonkeypath = "services";
    
    public string password1 = "";
    
    public string type_p = "";
    
    public string name_p = "";
    
    public string description_p = "";
    
    public string auto_resolve_timeout = "";
    
    public string acknowledgement_timeout = "";
    
    public string status = "";
    
    public string support_hours_type = "";
    
    public string time_zone = "";
    
    public string start_time = "";
    
    public string end_time = "";
    
    public string scheduled_actions = "";
    
    public string alert_creation = "";
    
    public string alert_grouping = "";
    
    public string alert_grouping_timeout = "";
    
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
_uriBuilderPath = "/services";
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
_postData = string.Format("{{ \"service\": {{   \"type\": \"{0}\",    \"name\": \"{1}\",    \"description\": \"{2}\",    \"auto_resolve_timeout\": \"{3}\",    \"acknowledgement_timeout\": \"{4}\",    \"status\": \"{5}\",    \"support_hours\": {{     \"type\": \"{6}\",      \"time_zone\": \"{7}\",      \"start_time\": \"{8}\",      \"end_time\": \"{9}\"     }},    \"scheduled_actions\": {10},    \"alert_creation\": \"{11}\",    \"alert_grouping\": \"{12}\",    \"alert_grouping_timeout\": \"{13}\"   }} }}",type_p,name_p,description_p,auto_resolve_timeout,acknowledgement_timeout,status,support_hours_type,time_zone,start_time,end_time,scheduled_actions,alert_creation,alert_grouping,alert_grouping_timeout);
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
_headers = new Dictionary<string, string>() { {"Authorization","Token token = " + password1} };
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
    
    public PD_Create_a_service() {
    }
    
    public PD_Create_a_service(
                string Jsonkeypath, 
                string password1, 
                string type_p, 
                string name_p, 
                string description_p, 
                string auto_resolve_timeout, 
                string acknowledgement_timeout, 
                string status, 
                string support_hours_type, 
                string time_zone, 
                string start_time, 
                string end_time, 
                string scheduled_actions, 
                string alert_creation, 
                string alert_grouping, 
                string alert_grouping_timeout) {
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.type_p = type_p;
        this.name_p = name_p;
        this.description_p = description_p;
        this.auto_resolve_timeout = auto_resolve_timeout;
        this.acknowledgement_timeout = acknowledgement_timeout;
        this.status = status;
        this.support_hours_type = support_hours_type;
        this.time_zone = time_zone;
        this.start_time = start_time;
        this.end_time = end_time;
        this.scheduled_actions = scheduled_actions;
        this.alert_creation = alert_creation;
        this.alert_grouping = alert_grouping;
        this.alert_grouping_timeout = alert_grouping_timeout;
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