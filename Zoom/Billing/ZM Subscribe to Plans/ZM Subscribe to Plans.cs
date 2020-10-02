using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.Sdk.ActivityCreation
{
    public class CustomActivity_ZM_Subscribe_to_Plans : IActivityAsync
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
    
    public string type = "";
    
    public string hosts = "";
    
    public string plan_zoom_rooms_type = "";
    
    public string plan_zoom_rooms_hosts = "";
    
    public string plan_room_connector_type = "";
    
    public string plan_room_connector_hosts = "";
    
    public string plan_large_meeting__ = "";
    
    public string plan_large_meeting_type = "";
    
    public string plan_large_meeting_hosts = "";
    
    public string plan_webinar__ = "";
    
    public string plan_webinar_type = "";
    
    public string plan_webinar_hosts = "";
    
    public string plan_recording = "";
    
    public string plan_audio_type = "";
    
    public string tollfree_countries = "";
    
    public string premium_countries = "";
    
    public string callout_countries = "";
    
    public string ddi_numbers = "";
    
    public string plan_base_type = "";
    
    public string plan_base_callout_countries = "";
    
    public string plan_calling__ = "";
    
    public string plan_calling_type = "";
    
    public string plan_calling_hosts = "";
    
    public string plan_number__ = "";
    
    public string plan_number_type = "";
    
    public string plan_number_hosts = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string endPoint = "https://api.zoom.us";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return string.Format("v2/accounts/{0}/plans",accountId);
        }
    }
    
    private string postData {
        get {
            return string.Format("{{   \"contact\": {{     \"first_name\": \"{0}\",     \"last_name\": \"{1}\",     \"email\": \"{2}\",     \"phone_number\": \"{3}\",     \"address\": \"{4}\",     \"apt\": \"{5}\",     \"city\": \"{6}\",     \"state\": \"{7}\",     \"zip\": \"{8}\",     \"country\": \"{9}\"   }},   \"plan_base\": {{     \"type\": \"{10}\",     \"hosts\": \"{11}\"   }},   \"plan_zoom_rooms\": {{     \"type\": \"{12}\",     \"hosts\": \"{13}\"   }},   \"plan_room_connector\": {{     \"type\": \"{14}\",     \"hosts\": \"{15}\"   }},   \"plan_large_meeting\": [     {{       \"type\": \"{16}\",       \"hosts\": \"{17}\"     }}   ],   \"plan_webinar\": [     {{       \"type\": \"{18}\",       \"hosts\": \"{19}\"     }}   ],   \"plan_recording\": \"{20}\",   \"plan_audio\": {{     \"type\": \"{21}\",     \"tollfree_countries\": \"{22}\",     \"premium_countries\": \"{23}\",     \"callout_countries\": \"{24}\",     \"ddi_numbers\": \"{25}\"   }},   \"plan_phone\": {{     \"plan_base\": {{       \"type\": \"{26}\",       \"callout_countries\": \"{27}\"     }},     \"plan_calling\": [       {{         \"type\": \"{28}\",         \"hosts\": \"{29}\"       }}     ],     \"plan_number\": [       {{         \"type\": \"{30}\",         \"hosts\": \"{31}\"       }}     ]   }} }}",first_name,last_name,email,phone_number,address,apt,city,state,zip,country,type,hosts,plan_zoom_rooms_type,plan_zoom_rooms_hosts,plan_room_connector_type,plan_room_connector_hosts,plan_large_meeting_type,plan_large_meeting_hosts,plan_webinar_type,plan_webinar_hosts,plan_recording,plan_audio_type,tollfree_countries,premium_countries,callout_countries,ddi_numbers,plan_base_type,plan_base_callout_countries,plan_calling_type,plan_calling_hosts,plan_number_type,plan_number_hosts);
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> headers {
        get {
            return new Dictionary<string, string>() {{"authorization","Bearer " + AyehuHelper.JWTToken(apikey,password1,"HS256","JWT", 120)}};
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> queryStringArray {
        get {
            return new Dictionary<string, string>() {};
        }
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
                    myHttpRequestMessage.Content = new StringContent(postData, Encoding.UTF8, "application/json");


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