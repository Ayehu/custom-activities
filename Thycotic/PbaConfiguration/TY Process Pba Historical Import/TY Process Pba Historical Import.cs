using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.Thycotic
{
    public class TY_Process_Pba_Historical_Import : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "pba-history-import";
    
    public string password1 = "";
    
    public string date = "";
    
    public string dateTime = "";
    
    public string day = "";
    
    public string dayOfWeek = "";
    
    public string dayOfYear = "";
    
    public string hour = "";
    
    public string localDateTime = "";
    
    public string millisecond = "";
    
    public string minute = "";
    
    public string month = "";
    
    public string offset = "";
    
    public string second = "";
    
    public string ticks = "";
    
    public string timeOfDay = "";
    
    public string utcDateTime = "";
    
    public string utcTicks = "";
    
    public string year = "";
    
    public string processImport = "";
    
    public string startDate_date = "";
    
    public string startDate_dateTime = "";
    
    public string startDate_day = "";
    
    public string startDate_dayOfWeek = "";
    
    public string startDate_dayOfYear = "";
    
    public string startDate_hour = "";
    
    public string startDate_localDateTime = "";
    
    public string startDate_millisecond = "";
    
    public string startDate_minute = "";
    
    public string startDate_month = "";
    
    public string startDate_offset = "";
    
    public string startDate_second = "";
    
    public string startDate_ticks = "";
    
    public string startDate_timeOfDay = "";
    
    public string startDate_utcDateTime = "";
    
    public string startDate_utcTicks = "";
    
    public string startDate_year = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = "SecretServer/api/v1/pba-history-import";
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
_postData = string.Format("{{ \"endDate\": {{   \"date\": \"{0}\",    \"dateTime\": \"{1}\",    \"day\": \"{2}\",    \"dayOfWeek\": \"{3}\",    \"dayOfYear\": \"{4}\",    \"hour\": \"{5}\",    \"localDateTime\": \"{6}\",    \"millisecond\": \"{7}\",    \"minute\": \"{8}\",    \"month\": \"{9}\",    \"offset\": \"{10}\",    \"second\": \"{11}\",    \"ticks\": \"{12}\",    \"timeOfDay\": \"{13}\",    \"utcDateTime\": \"{14}\",    \"utcTicks\": \"{15}\",    \"year\": \"{16}\"   }},  \"processImport\": \"{17}\",  \"startDate\": {{   \"date\": \"{18}\",    \"dateTime\": \"{19}\",    \"day\": \"{20}\",    \"dayOfWeek\": \"{21}\",    \"dayOfYear\": \"{22}\",    \"hour\": \"{23}\",    \"localDateTime\": \"{24}\",    \"millisecond\": \"{25}\",    \"minute\": \"{26}\",    \"month\": \"{27}\",    \"offset\": \"{28}\",    \"second\": \"{29}\",    \"ticks\": \"{30}\",    \"timeOfDay\": \"{31}\",    \"utcDateTime\": \"{32}\",    \"utcTicks\": \"{33}\",    \"year\": \"{34}\"   }} }}",date,dateTime,day,dayOfWeek,dayOfYear,hour,localDateTime,millisecond,minute,month,offset,second,ticks,timeOfDay,utcDateTime,utcTicks,year,processImport,startDate_date,startDate_dateTime,startDate_day,startDate_dayOfWeek,startDate_dayOfYear,startDate_hour,startDate_localDateTime,startDate_millisecond,startDate_minute,startDate_month,startDate_offset,startDate_second,startDate_ticks,startDate_timeOfDay,startDate_utcDateTime,startDate_utcTicks,startDate_year);
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
_headers = new Dictionary<string, string>() { {"Authorization","Bearer " + password1} };
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
    
    public TY_Process_Pba_Historical_Import() {
    }
    
    public TY_Process_Pba_Historical_Import(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string date, 
                string dateTime, 
                string day, 
                string dayOfWeek, 
                string dayOfYear, 
                string hour, 
                string localDateTime, 
                string millisecond, 
                string minute, 
                string month, 
                string offset, 
                string second, 
                string ticks, 
                string timeOfDay, 
                string utcDateTime, 
                string utcTicks, 
                string year, 
                string processImport, 
                string startDate_date, 
                string startDate_dateTime, 
                string startDate_day, 
                string startDate_dayOfWeek, 
                string startDate_dayOfYear, 
                string startDate_hour, 
                string startDate_localDateTime, 
                string startDate_millisecond, 
                string startDate_minute, 
                string startDate_month, 
                string startDate_offset, 
                string startDate_second, 
                string startDate_ticks, 
                string startDate_timeOfDay, 
                string startDate_utcDateTime, 
                string startDate_utcTicks, 
                string startDate_year) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.date = date;
        this.dateTime = dateTime;
        this.day = day;
        this.dayOfWeek = dayOfWeek;
        this.dayOfYear = dayOfYear;
        this.hour = hour;
        this.localDateTime = localDateTime;
        this.millisecond = millisecond;
        this.minute = minute;
        this.month = month;
        this.offset = offset;
        this.second = second;
        this.ticks = ticks;
        this.timeOfDay = timeOfDay;
        this.utcDateTime = utcDateTime;
        this.utcTicks = utcTicks;
        this.year = year;
        this.processImport = processImport;
        this.startDate_date = startDate_date;
        this.startDate_dateTime = startDate_dateTime;
        this.startDate_day = startDate_day;
        this.startDate_dayOfWeek = startDate_dayOfWeek;
        this.startDate_dayOfYear = startDate_dayOfYear;
        this.startDate_hour = startDate_hour;
        this.startDate_localDateTime = startDate_localDateTime;
        this.startDate_millisecond = startDate_millisecond;
        this.startDate_minute = startDate_minute;
        this.startDate_month = startDate_month;
        this.startDate_offset = startDate_offset;
        this.startDate_second = startDate_second;
        this.startDate_ticks = startDate_ticks;
        this.startDate_timeOfDay = startDate_timeOfDay;
        this.startDate_utcDateTime = startDate_utcDateTime;
        this.startDate_utcTicks = startDate_utcTicks;
        this.startDate_year = startDate_year;
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