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
    public class CustomActivity_ZM_Update_Locked_Settings : IActivityAsync
    {


    
    public string Jsonkeypath = "lock_settings";
    
    public string apikey = "";
    
    public string password1 = "";
    
    public string accountId = "";
    
    public string host_video = "";
    
    public string participant_video = "";
    
    public string audio_type = "";
    
    public string join_before_host = "";
    
    public string enforce_login = "";
    
    public string enforce_login_with_domains = "";
    
    public string enforce_login_domains = "";
    
    public string not_store_meeting_topic = "";
    
    public string require_password_for_scheduling_new_meetings = "";
    
    public string require_password_for_instant_meetings = "";
    
    public string require_password_for_pmi_meetings = "";
    
    public string meeting_authentication = "";
    
    public string e2e_encryption = "";
    
    public string chat = "";
    
    public string private_chat = "";
    
    public string auto_saving_chat = "";
    
    public string entry_exit_chime = "";
    
    public string feedback = "";
    
    public string post_meeting_feedback = "";
    
    public string co_host = "";
    
    public string polling = "";
    
    public string attendee_on_hold = "";
    
    public string show_meeting_control_toolbar = "";
    
    public string allow_show_zoom_windows = "";
    
    public string annotation = "";
    
    public string whiteboard = "";
    
    public string remote_control = "";
    
    public string webinar_question_answer = "";
    
    public string anonymous_question_answer = "";
    
    public string breakout_room = "";
    
    public string closed_caption = "";
    
    public string far_end_camera_control = "";
    
    public string group_hd = "";
    
    public string virtual_background = "";
    
    public string alert_guest_join = "";
    
    public string auto_answer = "";
    
    public string sending_default_email_invites = "";
    
    public string use_html_format_email = "";
    
    public string dscp_marking = "";
    
    public string stereo_audio = "";
    
    public string original_audio = "";
    
    public string screen_sharing = "";
    
    public string cloud_recording_available_reminder = "";
    
    public string jbh_reminder = "";
    
    public string cancel_meeting_reminder = "";
    
    public string alternative_host_reminder = "";
    
    public string schedule_for_host_reminder = "";
    
    public string local_recording = "";
    
    public string cloud_recording = "";
    
    public string auto_recording = "";
    
    public string cloud_recording_download = "";
    
    public string account_user_access_recording = "";
    
    public string host_delete_cloud_recording = "";
    
    public string auto_delete_cmr = "";
    
    public string recording_authentication = "";
    
    public string third_party_audio = "";
    
    public string call_out = "";
    
    public string show_international_numbers_link = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string endPoint = "https://api.zoom.us";
    
    private string httpMethod = "PATCH";
    
    private string uriBuilderPath {
        get {
            return string.Format("v2/accounts/{0}/lock_settings",accountId);
        }
    }
    
    private string postData {
        get {
            return string.Format("{{   \"schedule_meeting\": {{     \"host_video\": \"{0}\",     \"participant_video\": \"{1}\",     \"audio_type\": \"{2}\",     \"join_before_host\": \"{3}\",     \"enforce_login\": \"{4}\",     \"enforce_login_with_domains\": \"{5}\",     \"enforce_login_domains\": \"{6}\",     \"not_store_meeting_topic\": \"{7}\",     \"require_password_for_scheduling_new_meetings\": \"{8}\",     \"require_password_for_instant_meetings\": \"{9}\",     \"require_password_for_pmi_meetings\": \"{10}\",     \"meeting_authentication\": \"{11}\"   }},   \"in_meeting\": {{     \"e2e_encryption\": \"{12}\",     \"chat\": \"{13}\",     \"private_chat\": \"{14}\",     \"auto_saving_chat\": \"{15}\",     \"entry_exit_chime\": \"{16}\",     \"feedback\": \"{17}\",     \"post_meeting_feedback\": \"{18}\",     \"co_host\": \"{19}\",     \"polling\": \"{20}\",     \"attendee_on_hold\": \"{21}\",     \"show_meeting_control_toolbar\": \"{22}\",     \"allow_show_zoom_windows\": \"{23}\",     \"annotation\": \"{24}\",     \"whiteboard\": \"{25}\",     \"remote_control\": \"{26}\",     \"webinar_question_answer\": \"{27}\",     \"anonymous_question_answer\": \"{28}\",     \"breakout_room\": \"{29}\",     \"closed_caption\": \"{30}\",     \"far_end_camera_control\": \"{31}\",     \"group_hd\": \"{32}\",     \"virtual_background\": \"{33}\",     \"alert_guest_join\": \"{34}\",     \"auto_answer\": \"{35}\",     \"sending_default_email_invites\": \"{36}\",     \"use_html_format_email\": \"{37}\",     \"dscp_marking\": \"{38}\",     \"stereo_audio\": \"{39}\",     \"original_audio\": \"{40}\",     \"screen_sharing\": \"{41}\"   }},   \"email_notification\": {{     \"cloud_recording_available_reminder\": \"{42}\",     \"jbh_reminder\": \"{43}\",     \"cancel_meeting_reminder\": \"{44}\",     \"alternative_host_reminder\": \"{45}\",     \"schedule_for_host_reminder\": \"{46}\"   }},   \"recording\": {{     \"local_recording\": \"{47}\",     \"cloud_recording\": \"{48}\",     \"auto_recording\": \"{49}\",     \"cloud_recording_download\": \"{50}\",     \"account_user_access_recording\": \"{51}\",     \"host_delete_cloud_recording\": \"{52}\",     \"auto_delete_cmr\": \"{53}\",     \"recording_authentication\": \"{54}\"   }},   \"telephony\": {{     \"third_party_audio\": \"{55}\"   }},   \"tsp\": {{     \"call_out\": \"{56}\",     \"show_international_numbers_link\": \"{57}\"   }} }}",host_video,participant_video,audio_type,join_before_host,enforce_login,enforce_login_with_domains,enforce_login_domains,not_store_meeting_topic,require_password_for_scheduling_new_meetings,require_password_for_instant_meetings,require_password_for_pmi_meetings,meeting_authentication,e2e_encryption,chat,private_chat,auto_saving_chat,entry_exit_chime,feedback,post_meeting_feedback,co_host,polling,attendee_on_hold,show_meeting_control_toolbar,allow_show_zoom_windows,annotation,whiteboard,remote_control,webinar_question_answer,anonymous_question_answer,breakout_room,closed_caption,far_end_camera_control,group_hd,virtual_background,alert_guest_join,auto_answer,sending_default_email_invites,use_html_format_email,dscp_marking,stereo_audio,original_audio,screen_sharing,cloud_recording_available_reminder,jbh_reminder,cancel_meeting_reminder,alternative_host_reminder,schedule_for_host_reminder,local_recording,cloud_recording,auto_recording,cloud_recording_download,account_user_access_recording,host_delete_cloud_recording,auto_delete_cmr,recording_authentication,third_party_audio,call_out,show_international_numbers_link);
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