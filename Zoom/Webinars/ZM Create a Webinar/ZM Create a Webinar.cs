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
    public class CustomActivity_ZM_Create_a_Webinar : IActivityAsync
    {


    
    public string Jsonkeypath = "webinars";
    
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
    
    public string panelists_video = "";
    
    public string practice_session = "";
    
    public string hd_video = "";
    
    public string approval_type = "";
    
    public string registration_type = "";
    
    public string audio = "";
    
    public string auto_recording = "";
    
    public string enforce_login = "";
    
    public string enforce_login_domains = "";
    
    public string alternative_hosts = "";
    
    public string close_registration = "";
    
    public string show_share_button = "";
    
    public string allow_multiple_devices = "";
    
    public string on_demand = "";
    
    public string global_dial_in_countries__ = "";
    
    public string contact_name = "";
    
    public string contact_email = "";
    
    public string registrants_restrict_number = "";
    
    public string post_webinar_survey = "";
    
    public string survey_url = "";
    
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
            return string.Format("v2/users/{0}/webinars",userId);
        }
    }
    
    private string postData {
        get {
            return string.Format("{{   \"topic\": \"{0}\",   \"type\": \"{1}\",   \"start_time\": \"{2}\",   \"duration\": \"{3}\",   \"timezone\": \"{4}\",   \"password\": \"{5}\",   \"agenda\": \"{6}\",   \"tracking_fields\": [     {{       \"field\": \"{7}\",       \"value\": \"{8}\"     }}   ],   \"recurrence\": {{     \"type\": \"{9}\",     \"repeat_interval\": \"{10}\",     \"weekly_days\": \"{11}\",     \"monthly_day\": \"{12}\",     \"monthly_week\": \"{13}\",     \"monthly_week_day\": \"{14}\",     \"end_times\": \"{15}\",     \"end_date_time\": \"{16}\"   }},   \"settings\": {{     \"host_video\": \"{17}\",     \"panelists_video\": \"{18}\",     \"practice_session\": \"{19}\",     \"hd_video\": \"{20}\",     \"approval_type\": \"{21}\",     \"registration_type\": \"{22}\",     \"audio\": \"{23}\",     \"auto_recording\": \"{24}\",     \"enforce_login\": \"{25}\",     \"enforce_login_domains\": \"{26}\",     \"alternative_hosts\": \"{27}\",     \"close_registration\": \"{28}\",     \"show_share_button\": \"{29}\",     \"allow_multiple_devices\": \"{30}\",     \"on_demand\": \"{31}\",     \"contact_name\": \"{32}\",     \"contact_email\": \"{33}\",     \"registrants_restrict_number\": \"{34}\",     \"post_webinar_survey\": \"{35}\",     \"survey_url\": \"{36}\",     \"registrants_email_notification\": \"{37}\",     \"meeting_authentication\": \"{38}\",     \"authentication_option\": \"{39}\",     \"authentication_domains\": \"{40}\"   }} }}",topic,type,start_time,duration,timezone,password,agenda,field,value,recurrence_type,repeat_interval,weekly_days,monthly_day,monthly_week,monthly_week_day,end_times,end_date_time,host_video,panelists_video,practice_session,hd_video,approval_type,registration_type,audio,auto_recording,enforce_login,enforce_login_domains,alternative_hosts,close_registration,show_share_button,allow_multiple_devices,on_demand,contact_name,contact_email,registrants_restrict_number,post_webinar_survey,survey_url,registrants_email_notification,meeting_authentication,authentication_option,authentication_domains);
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