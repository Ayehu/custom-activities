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
    public class TY_ServiceCreateEventPipelinePolicy : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "event-pipeline-policy";
    
    public string password1 = "";
    
    public string dirty = "";
    
    public string value = "";
    
    public string eventPipelinePolicyDescription_dirty = "";
    
    public string eventPipelinePolicyDescription_value = "";
    
    public string eventPipelinePolicyName_dirty = "";
    
    public string eventPipelinePolicyName_value = "";
    
    public string externalInstanceId = "";
    
    public string pipelines_dirty = "";
    
    public string pipelines_value = "";
    
    public string reuseExistingPipelines = "";
    
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
_uriBuilderPath = "SecretServer/api/v1/event-pipeline-policy";
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
_postData = string.Format("{{ \"data\": {{   \"active\": {{     \"dirty\": \"{0}\",      \"value\": \"{1}\"     }},    \"eventPipelinePolicyDescription\": {{     \"dirty\": \"{2}\",      \"value\": \"{3}\"     }},    \"eventPipelinePolicyName\": {{     \"dirty\": \"{4}\",      \"value\": \"{5}\"     }},    \"externalInstanceId\": \"{6}\",    \"pipelines\": {{     \"dirty\": \"{7}\",      \"value\": {8}     }},    \"reuseExistingPipelines\": \"{9}\"   }} }}",dirty,value,eventPipelinePolicyDescription_dirty,eventPipelinePolicyDescription_value,eventPipelinePolicyName_dirty,eventPipelinePolicyName_value,externalInstanceId,pipelines_dirty,pipelines_value,reuseExistingPipelines);
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
    
    public TY_ServiceCreateEventPipelinePolicy() {
    }
    
    public TY_ServiceCreateEventPipelinePolicy(string endPoint, string Jsonkeypath, string password1, string dirty, string value, string eventPipelinePolicyDescription_dirty, string eventPipelinePolicyDescription_value, string eventPipelinePolicyName_dirty, string eventPipelinePolicyName_value, string externalInstanceId, string pipelines_dirty, string pipelines_value, string reuseExistingPipelines) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.dirty = dirty;
        this.value = value;
        this.eventPipelinePolicyDescription_dirty = eventPipelinePolicyDescription_dirty;
        this.eventPipelinePolicyDescription_value = eventPipelinePolicyDescription_value;
        this.eventPipelinePolicyName_dirty = eventPipelinePolicyName_dirty;
        this.eventPipelinePolicyName_value = eventPipelinePolicyName_value;
        this.externalInstanceId = externalInstanceId;
        this.pipelines_dirty = pipelines_dirty;
        this.pipelines_value = pipelines_value;
        this.reuseExistingPipelines = reuseExistingPipelines;
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