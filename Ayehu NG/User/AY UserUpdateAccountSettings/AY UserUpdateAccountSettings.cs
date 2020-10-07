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
    public class CustomActivity_AY_UserUpdateAccountSettings : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "UpdateAccountSettings";
    
    public string password1 = "";
    
    public string accountSettings = "";
    
    public string userId = "";
    
    public string userName = "";
    
    public string image = "";
    
    public string languageId = "";
    
    public string displaySystemGroup = "";
    
    public string backgroundColor = "";
    
    public string opensWorkflowAuditTrail = "";
    
    public string displayActivityDesignerWelcomeMessage = "";
    
    public string defaultTab = "";
    
    public string userActivityLogColumns__ = "";
    
    public string Name_p = "";
    
    public string DbName = "";
    
    public string Label = "";
    
    public string Visibility = "";
    
    public string OrderIndex = "";
    
    public string SortIndex = "";
    
    public string SortDirection = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "Server/Api/users/UpdateAccountSettings";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"userId\": \"{0}\",  \"userName\": \"{1}\",  \"image\": \"{2}\",  \"languageId\": \"{3}\",  \"displaySystemGroup\": \"{4}\",  \"backgroundColor\": \"{5}\",  \"opensWorkflowAuditTrail\": \"{6}\",  \"displayActivityDesignerWelcomeMessage\": \"{7}\",  \"defaultTab\": \"{8}\",  \"userActivityLogColumns\": [    {{     \"Name\": \"{9}\",      \"DbName\": \"{10}\",      \"Label\": \"{11}\",      \"Visibility\": \"{12}\",      \"OrderIndex\": \"{13}\",      \"SortIndex\": \"{14}\",      \"SortDirection\": \"{15}\"     }}  ] }}",userId,userName,image,languageId,displaySystemGroup,backgroundColor,opensWorkflowAuditTrail,displayActivityDesignerWelcomeMessage,defaultTab,Name_p,DbName,Label,Visibility,OrderIndex,SortIndex,SortDirection);
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> headers {
        get {
            return new Dictionary<string, string>() {{"authorization","Bearer " + password1}};
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