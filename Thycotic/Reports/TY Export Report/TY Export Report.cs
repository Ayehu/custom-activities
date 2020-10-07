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
    public class CustomActivity_TY_Export_Report : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "export";
    
    public string password1 = "";
    
    public string delimiter = "";
    
    public string domainId = "";
    
    public string password = "";
    
    public string twoFactor = "";
    
    public string username = "";
    
    public string encodeHtml = "";
    
    public string endRecordNumber = "";
    
    public string format = "";
    
    public string id_p = "";
    
    public string isAscending = "";
    
    public string name_p = "";
    
    public string orderByFieldOrdinal = "";
    
    public string pageNumber = "";
    
    public string parameters__ = "";
    
    public string parameters_name = "";
    
    public string value = "";
    
    public string recordsPerPage = "";
    
    public string startRecordNumber = "";
    
    public string timeZone = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "SecretServer/api/v1/reports/export";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"delimiter\": \"{0}\",  \"dualControlApproval\": {{   \"domainId\": \"{1}\",    \"password\": \"{2}\",    \"twoFactor\": \"{3}\",    \"username\": \"{4}\"   }},  \"encodeHtml\": \"{5}\",  \"endRecordNumber\": \"{6}\",  \"format\": \"{7}\",  \"id\": \"{8}\",  \"isAscending\": \"{9}\",  \"name\": \"{10}\",  \"orderByFieldOrdinal\": \"{11}\",  \"pageNumber\": \"{12}\",  \"parameters\": [    {{     \"name\": \"{13}\",      \"value\": \"{14}\"     }}  ],  \"recordsPerPage\": \"{15}\",  \"startRecordNumber\": \"{16}\",  \"timeZone\": \"{17}\" }}",delimiter,domainId,password,twoFactor,username,encodeHtml,endRecordNumber,format,id_p,isAscending,name_p,orderByFieldOrdinal,pageNumber,parameters_name,value,recordsPerPage,startRecordNumber,timeZone);
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