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
    public class CustomActivity_AY_PolicyActionUpdateTriggerData : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "updateTriggerData";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string order = "";
    
    public string name_p = "";
    
    public string policyDescription = "";
    
    public string enabled = "";
    
    public string terminating = "";
    
    public string days = "";
    
    public string trimmingConstrains = "";
    
    public string trimmingConstrainsName = "";
    
    public string logs = "";
    
    public string startTime = "";
    
    public string endTime = "";
    
    public string createTime = "";
    
    public string policyConditions__ = "";
    
    public string policyConditions_id = "";
    
    public string policyTriggerNumber = "";
    
    public string policyConditions_order = "";
    
    public string condition = "";
    
    public string workflowId = "";
    
    public string timeFrame = "";
    
    public string terminate = "";
    
    public string conditionName = "";
    
    public string workflowName = "";
    
    public string workflowRecoveryName = "";
    
    public string timeFrameName = "";
    
    public string logFolderNames = "";
    
    public string logFolders__ = "";
    
    public string workflowR = "";
    
    public string numberOfConditions = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "Server/Api/policyAction/updateTriggerData";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"id\": \"{0}\",  \"order\": \"{1}\",  \"name\": \"{2}\",  \"policyDescription\": \"{3}\",  \"enabled\": \"{4}\",  \"terminating\": \"{5}\",  \"days\": \"{6}\",  \"trimmingConstrains\": \"{7}\",  \"trimmingConstrainsName\": \"{8}\",  \"logs\": \"{9}\",  \"startTime\": \"{10}\",  \"endTime\": \"{11}\",  \"createTime\": \"{12}\",  \"policyConditions\": [    {{     \"id\": \"{13}\",      \"policyTriggerNumber\": \"{14}\",      \"order\": \"{15}\",      \"condition\": \"{16}\",      \"workflowId\": \"{17}\",      \"timeFrame\": \"{18}\",      \"terminate\": \"{19}\",      \"conditionName\": \"{20}\",      \"workflowName\": \"{21}\",      \"workflowRecoveryName\": \"{22}\",      \"timeFrameName\": \"{23}\",      \"logFolderNames\": \"{24}\",      \"workflowR\": \"{25}\"     }}  ],  \"numberOfConditions\": \"{26}\" }}",id_p,order,name_p,policyDescription,enabled,terminating,days,trimmingConstrains,trimmingConstrainsName,logs,startTime,endTime,createTime,policyConditions_id,policyTriggerNumber,policyConditions_order,condition,workflowId,timeFrame,terminate,conditionName,workflowName,workflowRecoveryName,timeFrameName,logFolderNames,workflowR,numberOfConditions);
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