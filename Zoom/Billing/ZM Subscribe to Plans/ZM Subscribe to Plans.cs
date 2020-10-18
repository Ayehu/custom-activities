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
    public class ZM_Subscribe_to_Plans : IActivityAsync
    {


    
    public string Jsonkeypath = "plans";
    
    public string apikey = "";
    
    public string password1 = "";
    
    public string accountId = "";
    
    public string first_name = "";
    
    public string last_name = "";
    
    public string email = "";
    
    public string phone_number = "";
    
    public string address = "";
    
    public string apt = "";
    
    public string city = "";
    
    public string state = "";
    
    public string zip = "";
    
    public string country = "";
    
    public string type_p = "";
    
    public string hosts = "";
    
    public string plan_zoom_rooms_type = "";
    
    public string plan_zoom_rooms_hosts = "";
    
    public string plan_room_connector_type = "";
    
    public string plan_room_connector_hosts = "";
    
    public string plan_large_meeting = "";
    
    public string plan_webinar = "";
    
    public string plan_recording = "";
    
    public string plan_audio_type = "";
    
    public string tollfree_countries = "";
    
    public string premium_countries = "";
    
    public string callout_countries = "";
    
    public string ddi_numbers = "";
    
    public string plan_base_type = "";
    
    public string plan_base_callout_countries = "";
    
    public string plan_calling = "";
    
    public string plan_number = "";
    
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
_uriBuilderPath = string.Format("v2/accounts/{0}/plans",accountId);
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
_postData = string.Format("{{ \"contact\": {{   \"first_name\": \"{0}\",    \"last_name\": \"{1}\",    \"email\": \"{2}\",    \"phone_number\": \"{3}\",    \"address\": \"{4}\",    \"apt\": \"{5}\",    \"city\": \"{6}\",    \"state\": \"{7}\",    \"zip\": \"{8}\",    \"country\": \"{9}\"   }},  \"plan_base\": {{   \"type\": \"{10}\",    \"hosts\": \"{11}\"   }},  \"plan_zoom_rooms\": {{   \"type\": \"{12}\",    \"hosts\": \"{13}\"   }},  \"plan_room_connector\": {{   \"type\": \"{14}\",    \"hosts\": \"{15}\"   }},  \"plan_large_meeting\": {16},  \"plan_webinar\": {17},  \"plan_recording\": \"{18}\",  \"plan_audio\": {{   \"type\": \"{19}\",    \"tollfree_countries\": \"{20}\",    \"premium_countries\": \"{21}\",    \"callout_countries\": \"{22}\",    \"ddi_numbers\": \"{23}\"   }},  \"plan_phone\": {{   \"plan_base\": {{     \"type\": \"{24}\",      \"callout_countries\": \"{25}\"     }},    \"plan_calling\": {26},    \"plan_number\": {27}   }} }}",first_name,last_name,email,phone_number,address,apt,city,state,zip,country,type_p,hosts,plan_zoom_rooms_type,plan_zoom_rooms_hosts,plan_room_connector_type,plan_room_connector_hosts,plan_large_meeting,plan_webinar,plan_recording,plan_audio_type,tollfree_countries,premium_countries,callout_countries,ddi_numbers,plan_base_type,plan_base_callout_countries,plan_calling,plan_number);
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
    
    public ZM_Subscribe_to_Plans() {
    }
    
    public ZM_Subscribe_to_Plans(
                string Jsonkeypath, 
                string apikey, 
                string password1, 
                string accountId, 
                string first_name, 
                string last_name, 
                string email, 
                string phone_number, 
                string address, 
                string apt, 
                string city, 
                string state, 
                string zip, 
                string country, 
                string type_p, 
                string hosts, 
                string plan_zoom_rooms_type, 
                string plan_zoom_rooms_hosts, 
                string plan_room_connector_type, 
                string plan_room_connector_hosts, 
                string plan_large_meeting, 
                string plan_webinar, 
                string plan_recording, 
                string plan_audio_type, 
                string tollfree_countries, 
                string premium_countries, 
                string callout_countries, 
                string ddi_numbers, 
                string plan_base_type, 
                string plan_base_callout_countries, 
                string plan_calling, 
                string plan_number) {
        this.Jsonkeypath = Jsonkeypath;
        this.apikey = apikey;
        this.password1 = password1;
        this.accountId = accountId;
        this.first_name = first_name;
        this.last_name = last_name;
        this.email = email;
        this.phone_number = phone_number;
        this.address = address;
        this.apt = apt;
        this.city = city;
        this.state = state;
        this.zip = zip;
        this.country = country;
        this.type_p = type_p;
        this.hosts = hosts;
        this.plan_zoom_rooms_type = plan_zoom_rooms_type;
        this.plan_zoom_rooms_hosts = plan_zoom_rooms_hosts;
        this.plan_room_connector_type = plan_room_connector_type;
        this.plan_room_connector_hosts = plan_room_connector_hosts;
        this.plan_large_meeting = plan_large_meeting;
        this.plan_webinar = plan_webinar;
        this.plan_recording = plan_recording;
        this.plan_audio_type = plan_audio_type;
        this.tollfree_countries = tollfree_countries;
        this.premium_countries = premium_countries;
        this.callout_countries = callout_countries;
        this.ddi_numbers = ddi_numbers;
        this.plan_base_type = plan_base_type;
        this.plan_base_callout_countries = plan_base_callout_countries;
        this.plan_calling = plan_calling;
        this.plan_number = plan_number;
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