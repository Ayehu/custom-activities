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
    public class CustomActivity_ZM_Add_Meeting_Registrant : IActivityAsync
    {


    
    public string Jsonkeypath = "registrants";
    
    public string apikey = "";
    
    public string password1 = "";
    
    public string meetingId = "";
    
    public string occurrence_ids = "";
    
    public string email = "";
    
    public string first_name = "";
    
    public string last_name = "";
    
    public string address = "";
    
    public string city = "";
    
    public string country = "";
    
    public string zip = "";
    
    public string state = "";
    
    public string phone = "";
    
    public string industry = "";
    
    public string org = "";
    
    public string job_title = "";
    
    public string purchasing_time_frame = "";
    
    public string role_in_purchase_process = "";
    
    public string no_of_employees = "";
    
    public string comments = "";
    
    public string custom_questions__ = "";
    
    public string title = "";
    
    public string value = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string endPoint = "https://api.zoom.us";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return string.Format("v2/meetings/{0}/registrants",meetingId);
        }
    }
    
    private string postData {
        get {
            return string.Format("{{   \"email\": \"{0}\",   \"first_name\": \"{1}\",   \"last_name\": \"{2}\",   \"address\": \"{3}\",   \"city\": \"{4}\",   \"country\": \"{5}\",   \"zip\": \"{6}\",   \"state\": \"{7}\",   \"phone\": \"{8}\",   \"industry\": \"{9}\",   \"org\": \"{10}\",   \"job_title\": \"{11}\",   \"purchasing_time_frame\": \"{12}\",   \"role_in_purchase_process\": \"{13}\",   \"no_of_employees\": \"{14}\",   \"comments\": \"{15}\",   \"custom_questions\": [     {{       \"title\": \"{16}\",       \"value\": \"{17}\"     }}   ] }}",email,first_name,last_name,address,city,country,zip,state,phone,industry,org,job_title,purchasing_time_frame,role_in_purchase_process,no_of_employees,comments,title,value);
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