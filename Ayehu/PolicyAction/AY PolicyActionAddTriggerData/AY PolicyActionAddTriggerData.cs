using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.Ayehu
{
    public class AY_PolicyActionAddTriggerData : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "addTriggerData";
    
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
    
    public string policyConditions = "";
    
    public string numberOfConditions = "";
    
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
_uriBuilderPath = "Server/Api/policyAction/addTriggerData";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"order\": \"{1}\",  \"name\": \"{2}\",  \"policyDescription\": \"{3}\",  \"enabled\": \"{4}\",  \"terminating\": \"{5}\",  \"days\": \"{6}\",  \"trimmingConstrains\": \"{7}\",  \"trimmingConstrainsName\": \"{8}\",  \"logs\": \"{9}\",  \"startTime\": \"{10}\",  \"endTime\": \"{11}\",  \"createTime\": \"{12}\",  \"policyConditions\": {13},  \"numberOfConditions\": \"{14}\" }}",id_p,order,name_p,policyDescription,enabled,terminating,days,trimmingConstrains,trimmingConstrainsName,logs,startTime,endTime,createTime,policyConditions,numberOfConditions);
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
_headers = new Dictionary<string, string>() { {"authorization","Bearer " + password1} };
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
    
    public AY_PolicyActionAddTriggerData() {
    }
    
    public AY_PolicyActionAddTriggerData(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string order, 
                string name_p, 
                string policyDescription, 
                string enabled, 
                string terminating, 
                string days, 
                string trimmingConstrains, 
                string trimmingConstrainsName, 
                string logs, 
                string startTime, 
                string endTime, 
                string createTime, 
                string policyConditions, 
                string numberOfConditions) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.order = order;
        this.name_p = name_p;
        this.policyDescription = policyDescription;
        this.enabled = enabled;
        this.terminating = terminating;
        this.days = days;
        this.trimmingConstrains = trimmingConstrains;
        this.trimmingConstrainsName = trimmingConstrainsName;
        this.logs = logs;
        this.startTime = startTime;
        this.endTime = endTime;
        this.createTime = createTime;
        this.policyConditions = policyConditions;
        this.numberOfConditions = numberOfConditions;
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