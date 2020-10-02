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
    public class CustomActivity_ZM_Create_a_Meeting : IActivityAsync
    {


    
    public string Jsonkeypath = "meetings";
    
    public string apikey = "";
    
    public string password1 = "";
    
    public string userId = "";
    
    public string topic = "";
    
    public string type = "";
    
    public string start_time = "";
    
    public string duration = "";
    
    public string timezone = "";
    
    public string password = "";
    
    public string agenda = "";
    
    public string tracking_fields__ = "";
    
    public string field = "";
    
    public string value = "";
    
    public string recurrence_type = "";
    
    public string repeat_interval = "";
    
    public string weekly_days = "";
    
    public string monthly_day = "";
    
    public string monthly_week = "";
    
    public string monthly_week_day = "";
    
    public string end_times = "";
    
    public string end_date_time = "";
    
    public string host_video = "";
    
    public string participant_video = "";
    
    public string cn_meeting = "";
    
    public string in_meeting = "";
    
    public string join_before_host = "";
    
    public string mute_upon_entry = "";
    
    public string watermark = "";
    
    public string use_pmi = "";
    
    public string approval_type = "";
    
    public string registration_type = "";
    
    public string audio = "";
    
    public string auto_recording = "";
    
    public string enforce_login = "";
    
    public string enforce_login_domains = "";
    
    public string alternative_hosts = "";
    
    public string close_registration = "";
    
    public string waiting_room = "";
    
    public string global_dial_in_countries__ = "";
    
    public string contact_name = "";
    
    public string contact_email = "";
    
    public string registrants_email_notification = "";
    
    public string meeting_authentication = "";
    
    public string authentication_option = "";
    
    public string authentication_domains = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string endPoint = "https://api.zoom.us";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return string.Format("v2/users/{0}/meetings",userId);
        }
    }
    
    private string postData {
        get {
            return string.Format("{{   \"topic\": \"{0}\",   \"type\": \"{1}\",   \"start_time\": \"{2}\",   \"duration\": \"{3}\",   \"timezone\": \"{4}\",   \"password\": \"{5}\",   \"agenda\": \"{6}\",   \"tracking_fields\": [     {{       \"field\": \"{7}\",       \"value\": \"{8}\"     }}   ],   \"recurrence\": {{     \"type\": \"{9}\",     \"repeat_interval\": \"{10}\",     \"weekly_days\": \"{11}\",     \"monthly_day\": \"{12}\",     \"monthly_week\": \"{13}\",     \"monthly_week_day\": \"{14}\",     \"end_times\": \"{15}\",     \"end_date_time\": \"{16}\"   }},   \"settings\": {{     \"host_video\": \"{17}\",     \"participant_video\": \"{18}\",     \"cn_meeting\": \"{19}\",     \"in_meeting\": \"{20}\",     \"join_before_host\": \"{21}\",     \"mute_upon_entry\": \"{22}\",     \"watermark\": \"{23}\",     \"use_pmi\": \"{24}\",     \"approval_type\": \"{25}\",     \"registration_type\": \"{26}\",     \"audio\": \"{27}\",     \"auto_recording\": \"{28}\",     \"enforce_login\": \"{29}\",     \"enforce_login_domains\": \"{30}\",     \"alternative_hosts\": \"{31}\",     \"close_registration\": \"{32}\",     \"waiting_room\": \"{33}\",     \"contact_name\": \"{34}\",     \"contact_email\": \"{35}\",     \"registrants_email_notification\": \"{36}\",     \"meeting_authentication\": \"{37}\",     \"authentication_option\": \"{38}\",     \"authentication_domains\": \"{39}\"   }} }}",topic,type,start_time,duration,timezone,password,agenda,field,value,recurrence_type,repeat_interval,weekly_days,monthly_day,monthly_week,monthly_week_day,end_times,end_date_time,host_video,participant_video,cn_meeting,in_meeting,join_before_host,mute_upon_entry,watermark,use_pmi,approval_type,registration_type,audio,auto_recording,enforce_login,enforce_login_domains,alternative_hosts,close_registration,waiting_room,contact_name,contact_email,registrants_email_notification,meeting_authentication,authentication_option,authentication_domains);
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