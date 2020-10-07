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
    public class CustomActivity_TY_Process_Pba_Historical_Import : IActivityAsync
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
    
    private string uriBuilderPath {
        get {
            return "SecretServer/api/v1/pba-history-import";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"endDate\": {{   \"date\": \"{0}\",    \"dateTime\": \"{1}\",    \"day\": \"{2}\",    \"dayOfWeek\": \"{3}\",    \"dayOfYear\": \"{4}\",    \"hour\": \"{5}\",    \"localDateTime\": \"{6}\",    \"millisecond\": \"{7}\",    \"minute\": \"{8}\",    \"month\": \"{9}\",    \"offset\": \"{10}\",    \"second\": \"{11}\",    \"ticks\": \"{12}\",    \"timeOfDay\": \"{13}\",    \"utcDateTime\": \"{14}\",    \"utcTicks\": \"{15}\",    \"year\": \"{16}\"   }},  \"processImport\": \"{17}\",  \"startDate\": {{   \"date\": \"{18}\",    \"dateTime\": \"{19}\",    \"day\": \"{20}\",    \"dayOfWeek\": \"{21}\",    \"dayOfYear\": \"{22}\",    \"hour\": \"{23}\",    \"localDateTime\": \"{24}\",    \"millisecond\": \"{25}\",    \"minute\": \"{26}\",    \"month\": \"{27}\",    \"offset\": \"{28}\",    \"second\": \"{29}\",    \"ticks\": \"{30}\",    \"timeOfDay\": \"{31}\",    \"utcDateTime\": \"{32}\",    \"utcTicks\": \"{33}\",    \"year\": \"{34}\"   }} }}",date,dateTime,day,dayOfWeek,dayOfYear,hour,localDateTime,millisecond,minute,month,offset,second,ticks,timeOfDay,utcDateTime,utcTicks,year,processImport,startDate_date,startDate_dateTime,startDate_day,startDate_dayOfWeek,startDate_dayOfYear,startDate_hour,startDate_localDateTime,startDate_millisecond,startDate_minute,startDate_month,startDate_offset,startDate_second,startDate_ticks,startDate_timeOfDay,startDate_utcDateTime,startDate_utcTicks,startDate_year);
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> headers {
        get {
            return new Dictionary<string, string>() {{"Authorization","Bearer " + password1}};
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