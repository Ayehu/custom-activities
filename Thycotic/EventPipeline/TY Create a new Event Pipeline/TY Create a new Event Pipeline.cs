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
    public class CustomActivity_TY_Create_a_new_Event_Pipeline : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "event-pipeline";
    
    public string password1 = "";
    
    public string dirty = "";
    
    public string value = "";
    
    public string eventPipelineDescription_dirty = "";
    
    public string eventPipelineDescription_value = "";
    
    public string eventPipelineName_dirty = "";
    
    public string eventPipelineName_value = "";
    
    public string filters_dirty = "";
    
    public string filters_value__ = "";
    
    public string eventPipelineFilterId_dirty = "";
    
    public string eventPipelineFilterId_value = "";
    
    public string eventPipelineFilterMapId_dirty = "";
    
    public string eventPipelineFilterMapId_value = "";
    
    public string eventPipelineFilterName_dirty = "";
    
    public string eventPipelineFilterName_value = "";
    
    public string settings_dirty = "";
    
    public string settings_value__ = "";
    
    public string settingName_dirty = "";
    
    public string settingName_value = "";
    
    public string settingValue_dirty = "";
    
    public string settingValue_value = "";
    
    public string sortOrder_dirty = "";
    
    public string sortOrder_value = "";
    
    public string tasks_dirty = "";
    
    public string tasks_value__ = "";
    
    public string eventPipelineTaskId_dirty = "";
    
    public string eventPipelineTaskId_value = "";
    
    public string eventPipelineTaskMapId_dirty = "";
    
    public string eventPipelineTaskMapId_value = "";
    
    public string eventPipelineTaskName_dirty = "";
    
    public string eventPipelineTaskName_value = "";
    
    public string triggers_dirty = "";
    
    public string triggers_value__ = "";
    
    public string eventActionId_dirty = "";
    
    public string eventActionId_value = "";
    
    public string eventPipelinePolicyId = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "SecretServer/api/v1/event-pipeline";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"data\": {{   \"active\": {{     \"dirty\": \"{0}\",      \"value\": \"{1}\"     }},    \"eventPipelineDescription\": {{     \"dirty\": \"{2}\",      \"value\": \"{3}\"     }},    \"eventPipelineName\": {{     \"dirty\": \"{4}\",      \"value\": \"{5}\"     }},    \"filters\": {{     \"dirty\": \"{6}\",      \"value\": [        {{         \"eventPipelineFilterId\": {{           \"dirty\": \"{7}\",            \"value\": \"{8}\"           }},          \"eventPipelineFilterMapId\": {{           \"dirty\": \"{9}\",            \"value\": \"{10}\"           }},          \"eventPipelineFilterName\": {{           \"dirty\": \"{11}\",            \"value\": \"{12}\"           }},          \"settings\": {{           \"dirty\": \"{13}\",            \"value\": [              {{               \"settingName\": {{                 \"dirty\": \"{14}\",                  \"value\": \"{15}\"                 }},                \"settingValue\": {{                 \"dirty\": \"{16}\",                  \"value\": \"{17}\"                 }}               }}            ]           }},          \"sortOrder\": {{           \"dirty\": \"{18}\",            \"value\": \"{19}\"           }}         }}      ]     }},    \"tasks\": {{     \"dirty\": \"{20}\",      \"value\": [        {{         \"eventPipelineTaskId\": {{           \"dirty\": \"{21}\",            \"value\": \"{22}\"           }},          \"eventPipelineTaskMapId\": {{           \"dirty\": \"{23}\",            \"value\": \"{24}\"           }},          \"eventPipelineTaskName\": {{           \"dirty\": \"{25}\",            \"value\": \"{26}\"           }},          \"settings\": {{           \"dirty\": \"{13}\",            \"value\": [              {{               \"settingName\": {{                 \"dirty\": \"{14}\",                  \"value\": \"{15}\"                 }},                \"settingValue\": {{                 \"dirty\": \"{16}\",                  \"value\": \"{17}\"                 }}               }}            ]           }},          \"sortOrder\": {{           \"dirty\": \"{18}\",            \"value\": \"{19}\"           }}         }}      ]     }},    \"triggers\": {{     \"dirty\": \"{27}\",      \"value\": [        {{         \"eventActionId\": {{           \"dirty\": \"{28}\",            \"value\": \"{29}\"           }}         }}      ]     }}   }},  \"eventPipelinePolicyId\": \"{30}\" }}",dirty,value,eventPipelineDescription_dirty,eventPipelineDescription_value,eventPipelineName_dirty,eventPipelineName_value,filters_dirty,eventPipelineFilterId_dirty,eventPipelineFilterId_value,eventPipelineFilterMapId_dirty,eventPipelineFilterMapId_value,eventPipelineFilterName_dirty,eventPipelineFilterName_value,settings_dirty,settingName_dirty,settingName_value,settingValue_dirty,settingValue_value,sortOrder_dirty,sortOrder_value,tasks_dirty,eventPipelineTaskId_dirty,eventPipelineTaskId_value,eventPipelineTaskMapId_dirty,eventPipelineTaskMapId_value,eventPipelineTaskName_dirty,eventPipelineTaskName_value,triggers_dirty,eventActionId_dirty,eventActionId_value,eventPipelinePolicyId);
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