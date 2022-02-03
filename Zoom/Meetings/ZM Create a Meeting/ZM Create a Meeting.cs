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
    public class ZM_Create_a_Meeting : IActivityAsync
    {


    
    public string Jsonkeypath = "meetings";
    
    public string apikey = "";
    
    public string password1 = "";
    
    public string userId = "";
    
    public string topic = "";
    
    public string type_p = "";
    
    public string start_time = "";
    
    public string duration = "";
    
    public string timezone = "";
    
    public string password = "";
    
    public string agenda = "";
    
    public string tracking_fields = "";
    
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
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = string.Format("v2/users/{0}/meetings",userId);
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
_postData = string.Format("{{ \"topic\": \"{0}\",  \"type\": \"{1}\",  \"start_time\": \"{2}\",  \"duration\": \"{3}\",  \"timezone\": \"{4}\",  \"password\": \"{5}\",  \"agenda\": \"{6}\",  \"tracking_fields\": {7},  \"recurrence\": {{   \"type\": \"{8}\",    \"repeat_interval\": \"{9}\",    \"weekly_days\": \"{10}\",    \"monthly_day\": \"{11}\",    \"monthly_week\": \"{12}\",    \"monthly_week_day\": \"{13}\",    \"end_times\": \"{14}\",    \"end_date_time\": \"{15}\"   }},  \"settings\": {{   \"host_video\": \"{16}\",    \"participant_video\": \"{17}\",    \"cn_meeting\": \"{18}\",    \"in_meeting\": \"{19}\",    \"join_before_host\": \"{20}\",    \"mute_upon_entry\": \"{21}\",    \"watermark\": \"{22}\",    \"use_pmi\": \"{23}\",    \"approval_type\": \"{24}\",    \"registration_type\": \"{25}\",    \"audio\": \"{26}\",    \"auto_recording\": \"{27}\",    \"enforce_login\": \"{28}\",    \"enforce_login_domains\": \"{29}\",    \"alternative_hosts\": \"{30}\",    \"close_registration\": \"{31}\",    \"waiting_room\": \"{32}\",    \"contact_name\": \"{33}\",    \"contact_email\": \"{34}\",    \"registrants_email_notification\": \"{35}\",    \"meeting_authentication\": \"{36}\",    \"authentication_option\": \"{37}\",    \"authentication_domains\": \"{38}\"   }} }}",topic,type_p,start_time,duration,timezone,password,agenda,tracking_fields,recurrence_type,repeat_interval,weekly_days,monthly_day,monthly_week,monthly_week_day,end_times,end_date_time,host_video,participant_video,cn_meeting,in_meeting,join_before_host,mute_upon_entry,watermark,use_pmi,approval_type,registration_type,audio,auto_recording,enforce_login,enforce_login_domains,alternative_hosts,close_registration,waiting_room,contact_name,contact_email,registrants_email_notification,meeting_authentication,authentication_option,authentication_domains);
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
    
    public ZM_Create_a_Meeting() {
    }
    
    public ZM_Create_a_Meeting(
                string Jsonkeypath, 
                string apikey, 
                string password1, 
                string userId, 
                string topic, 
                string type_p, 
                string start_time, 
                string duration, 
                string timezone, 
                string password, 
                string agenda, 
                string tracking_fields, 
                string recurrence_type, 
                string repeat_interval, 
                string weekly_days, 
                string monthly_day, 
                string monthly_week, 
                string monthly_week_day, 
                string end_times, 
                string end_date_time, 
                string host_video, 
                string participant_video, 
                string cn_meeting, 
                string in_meeting, 
                string join_before_host, 
                string mute_upon_entry, 
                string watermark, 
                string use_pmi, 
                string approval_type, 
                string registration_type, 
                string audio, 
                string auto_recording, 
                string enforce_login, 
                string enforce_login_domains, 
                string alternative_hosts, 
                string close_registration, 
                string waiting_room, 
                string contact_name, 
                string contact_email, 
                string registrants_email_notification, 
                string meeting_authentication, 
                string authentication_option, 
                string authentication_domains) {
        this.Jsonkeypath = Jsonkeypath;
        this.apikey = apikey;
        this.password1 = password1;
        this.userId = userId;
        this.topic = topic;
        this.type_p = type_p;
        this.start_time = start_time;
        this.duration = duration;
        this.timezone = timezone;
        this.password = password;
        this.agenda = agenda;
        this.tracking_fields = tracking_fields;
        this.recurrence_type = recurrence_type;
        this.repeat_interval = repeat_interval;
        this.weekly_days = weekly_days;
        this.monthly_day = monthly_day;
        this.monthly_week = monthly_week;
        this.monthly_week_day = monthly_week_day;
        this.end_times = end_times;
        this.end_date_time = end_date_time;
        this.host_video = host_video;
        this.participant_video = participant_video;
        this.cn_meeting = cn_meeting;
        this.in_meeting = in_meeting;
        this.join_before_host = join_before_host;
        this.mute_upon_entry = mute_upon_entry;
        this.watermark = watermark;
        this.use_pmi = use_pmi;
        this.approval_type = approval_type;
        this.registration_type = registration_type;
        this.audio = audio;
        this.auto_recording = auto_recording;
        this.enforce_login = enforce_login;
        this.enforce_login_domains = enforce_login_domains;
        this.alternative_hosts = alternative_hosts;
        this.close_registration = close_registration;
        this.waiting_room = waiting_room;
        this.contact_name = contact_name;
        this.contact_email = contact_email;
        this.registrants_email_notification = registrants_email_notification;
        this.meeting_authentication = meeting_authentication;
        this.authentication_option = authentication_option;
        this.authentication_domains = authentication_domains;
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