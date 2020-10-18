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
    public class AY_PolicyActionAddScheduleData : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "addScheduleData";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string description_p = "";
    
    public string moduleID = "";
    
    public string workflowId = "";
    
    public string workflowName = "";
    
    public string startDate = "";
    
    public string endDate = "";
    
    public string actionData = "";
    
    public string ScheduleType = "";
    
    public string BetweenFrom = "";
    
    public string BetweenTo = "";
    
    public string RunAt = "";
    
    public string Every = "";
    
    public string Date = "";
    
    public string nextRunDate = "";
    
    public string lastRunDate = "";
    
    public string deleteAfterLastRun = "";
    
    public string taskRunTimeLimit = "";
    
    public string skipTask = "";
    
    public string status = "";
    
    public string enabled = "";
    
    public string eventNumber = "";
    
    public string logit = "";
    
    public string creationDate = "";
    
    public string lastSaved = "";
    
    public string lastModifyById = "";
    
    public string savedBy = "";
    
    public string scheduleStatement = "";
    
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
_uriBuilderPath = "Server/Api/policyAction/addScheduleData";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"name\": \"{1}\",  \"description\": \"{2}\",  \"moduleID\": \"{3}\",  \"workflowId\": \"{4}\",  \"workflowName\": \"{5}\",  \"startDate\": \"{6}\",  \"endDate\": \"{7}\",  \"actionData\": \"{8}\",  \"actionDataObj\": {{   \"ScheduleType\": \"{9}\",    \"BetweenFrom\": \"{10}\",    \"BetweenTo\": \"{11}\",    \"RunAt\": \"{12}\",    \"Every\": \"{13}\",    \"Date\": \"{14}\"   }},  \"nextRunDate\": \"{15}\",  \"lastRunDate\": \"{16}\",  \"deleteAfterLastRun\": \"{17}\",  \"taskRunTimeLimit\": \"{18}\",  \"skipTask\": \"{19}\",  \"status\": \"{20}\",  \"enabled\": \"{21}\",  \"eventNumber\": \"{22}\",  \"logit\": \"{23}\",  \"creationDate\": \"{24}\",  \"lastSaved\": \"{25}\",  \"lastModifyById\": \"{26}\",  \"savedBy\": \"{27}\",  \"scheduleStatement\": \"{28}\" }}",id_p,name_p,description_p,moduleID,workflowId,workflowName,startDate,endDate,actionData,ScheduleType,BetweenFrom,BetweenTo,RunAt,Every,Date,nextRunDate,lastRunDate,deleteAfterLastRun,taskRunTimeLimit,skipTask,status,enabled,eventNumber,logit,creationDate,lastSaved,lastModifyById,savedBy,scheduleStatement);
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
    
    public AY_PolicyActionAddScheduleData() {
    }
    
    public AY_PolicyActionAddScheduleData(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string name_p, 
                string description_p, 
                string moduleID, 
                string workflowId, 
                string workflowName, 
                string startDate, 
                string endDate, 
                string actionData, 
                string ScheduleType, 
                string BetweenFrom, 
                string BetweenTo, 
                string RunAt, 
                string Every, 
                string Date, 
                string nextRunDate, 
                string lastRunDate, 
                string deleteAfterLastRun, 
                string taskRunTimeLimit, 
                string skipTask, 
                string status, 
                string enabled, 
                string eventNumber, 
                string logit, 
                string creationDate, 
                string lastSaved, 
                string lastModifyById, 
                string savedBy, 
                string scheduleStatement) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.name_p = name_p;
        this.description_p = description_p;
        this.moduleID = moduleID;
        this.workflowId = workflowId;
        this.workflowName = workflowName;
        this.startDate = startDate;
        this.endDate = endDate;
        this.actionData = actionData;
        this.ScheduleType = ScheduleType;
        this.BetweenFrom = BetweenFrom;
        this.BetweenTo = BetweenTo;
        this.RunAt = RunAt;
        this.Every = Every;
        this.Date = Date;
        this.nextRunDate = nextRunDate;
        this.lastRunDate = lastRunDate;
        this.deleteAfterLastRun = deleteAfterLastRun;
        this.taskRunTimeLimit = taskRunTimeLimit;
        this.skipTask = skipTask;
        this.status = status;
        this.enabled = enabled;
        this.eventNumber = eventNumber;
        this.logit = logit;
        this.creationDate = creationDate;
        this.lastSaved = lastSaved;
        this.lastModifyById = lastModifyById;
        this.savedBy = savedBy;
        this.scheduleStatement = scheduleStatement;
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