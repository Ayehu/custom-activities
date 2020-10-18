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
    public class AY_IncidentConfigurationUpdateIncident : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "updateIncident";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string dateOpen = "";
    
    public string eventNumber = "";
    
    public string hostNumber = "";
    
    public string classNumber = "";
    
    public string information = "";
    
    public string severity = "";
    
    public string state1 = "";
    
    public string status1 = "";
    
    public string alertMethod = "";
    
    public string alertTimes = "";
    
    public string alertMinutes = "";
    
    public string alertSuccess = "";
    
    public string executeWorkflowForEveryUpdate = "";
    
    public string alertInitiated = "";
    
    public string alertInCount = "";
    
    public string lastUpdateDate = "";
    
    public string solutionRequest = "";
    
    public string updateDashboard = "";
    
    public string alertIfResponded = "";
    
    public string alertEventNumber = "";
    
    public string isProblem = "";
    
    public string alertAllReceptions = "";
    
    public string TTRAVG = "";
    
    public string currentAssignObject = "";
    
    public string currentAssignStatus = "";
    
    public string name_p = "";
    
    public string classification = "";
    
    public string objectType = "";
    
    public string alertInitiatedTime = "";
    
    public string lastTemplate = "";
    
    public string groupNumber = "";
    
    public string resetAfter = "";
    
    public string resetAfterMinutes = "";
    
    public string statusMessage = "";
    
    public string tagUsed = "";
    
    public string site = "";
    
    public string hash = "";
    
    public string conditionNumber = "";
    
    public string currentHistoryID = "";
    
    public string sourceModule = "";
    
    public string externalID = "";
    
    public string ticketID = "";
    
    public string incidentData = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "PUT";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = "Server/API/IncidentConfiguration/updateIncident";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"dateOpen\": \"{1}\",  \"eventNumber\": \"{2}\",  \"hostNumber\": \"{3}\",  \"classNumber\": \"{4}\",  \"information\": \"{5}\",  \"severity\": \"{6}\",  \"state1\": \"{7}\",  \"status1\": \"{8}\",  \"alertMethod\": \"{9}\",  \"alertTimes\": \"{10}\",  \"alertMinutes\": \"{11}\",  \"alertSuccess\": \"{12}\",  \"executeWorkflowForEveryUpdate\": \"{13}\",  \"alertInitiated\": \"{14}\",  \"alertInCount\": \"{15}\",  \"lastUpdateDate\": \"{16}\",  \"solutionRequest\": \"{17}\",  \"updateDashboard\": \"{18}\",  \"alertIfResponded\": \"{19}\",  \"alertEventNumber\": \"{20}\",  \"isProblem\": \"{21}\",  \"alertAllReceptions\": \"{22}\",  \"TTRAVG\": \"{23}\",  \"currentAssignObject\": \"{24}\",  \"currentAssignStatus\": \"{25}\",  \"name\": \"{26}\",  \"classification\": \"{27}\",  \"objectType\": \"{28}\",  \"alertInitiatedTime\": \"{29}\",  \"lastTemplate\": \"{30}\",  \"groupNumber\": \"{31}\",  \"resetAfter\": \"{32}\",  \"resetAfterMinutes\": \"{33}\",  \"statusMessage\": \"{34}\",  \"tagUsed\": \"{35}\",  \"site\": \"{36}\",  \"hash\": \"{37}\",  \"conditionNumber\": \"{38}\",  \"currentHistoryID\": \"{39}\",  \"sourceModule\": \"{40}\",  \"externalID\": \"{41}\",  \"ticketID\": \"{42}\",  \"incidentData\": \"{43}\" }}",id_p,dateOpen,eventNumber,hostNumber,classNumber,information,severity,state1,status1,alertMethod,alertTimes,alertMinutes,alertSuccess,executeWorkflowForEveryUpdate,alertInitiated,alertInCount,lastUpdateDate,solutionRequest,updateDashboard,alertIfResponded,alertEventNumber,isProblem,alertAllReceptions,TTRAVG,currentAssignObject,currentAssignStatus,name_p,classification,objectType,alertInitiatedTime,lastTemplate,groupNumber,resetAfter,resetAfterMinutes,statusMessage,tagUsed,site,hash,conditionNumber,currentHistoryID,sourceModule,externalID,ticketID,incidentData);
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
    
    public AY_IncidentConfigurationUpdateIncident() {
    }
    
    public AY_IncidentConfigurationUpdateIncident(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string dateOpen, 
                string eventNumber, 
                string hostNumber, 
                string classNumber, 
                string information, 
                string severity, 
                string state1, 
                string status1, 
                string alertMethod, 
                string alertTimes, 
                string alertMinutes, 
                string alertSuccess, 
                string executeWorkflowForEveryUpdate, 
                string alertInitiated, 
                string alertInCount, 
                string lastUpdateDate, 
                string solutionRequest, 
                string updateDashboard, 
                string alertIfResponded, 
                string alertEventNumber, 
                string isProblem, 
                string alertAllReceptions, 
                string TTRAVG, 
                string currentAssignObject, 
                string currentAssignStatus, 
                string name_p, 
                string classification, 
                string objectType, 
                string alertInitiatedTime, 
                string lastTemplate, 
                string groupNumber, 
                string resetAfter, 
                string resetAfterMinutes, 
                string statusMessage, 
                string tagUsed, 
                string site, 
                string hash, 
                string conditionNumber, 
                string currentHistoryID, 
                string sourceModule, 
                string externalID, 
                string ticketID, 
                string incidentData) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.dateOpen = dateOpen;
        this.eventNumber = eventNumber;
        this.hostNumber = hostNumber;
        this.classNumber = classNumber;
        this.information = information;
        this.severity = severity;
        this.state1 = state1;
        this.status1 = status1;
        this.alertMethod = alertMethod;
        this.alertTimes = alertTimes;
        this.alertMinutes = alertMinutes;
        this.alertSuccess = alertSuccess;
        this.executeWorkflowForEveryUpdate = executeWorkflowForEveryUpdate;
        this.alertInitiated = alertInitiated;
        this.alertInCount = alertInCount;
        this.lastUpdateDate = lastUpdateDate;
        this.solutionRequest = solutionRequest;
        this.updateDashboard = updateDashboard;
        this.alertIfResponded = alertIfResponded;
        this.alertEventNumber = alertEventNumber;
        this.isProblem = isProblem;
        this.alertAllReceptions = alertAllReceptions;
        this.TTRAVG = TTRAVG;
        this.currentAssignObject = currentAssignObject;
        this.currentAssignStatus = currentAssignStatus;
        this.name_p = name_p;
        this.classification = classification;
        this.objectType = objectType;
        this.alertInitiatedTime = alertInitiatedTime;
        this.lastTemplate = lastTemplate;
        this.groupNumber = groupNumber;
        this.resetAfter = resetAfter;
        this.resetAfterMinutes = resetAfterMinutes;
        this.statusMessage = statusMessage;
        this.tagUsed = tagUsed;
        this.site = site;
        this.hash = hash;
        this.conditionNumber = conditionNumber;
        this.currentHistoryID = currentHistoryID;
        this.sourceModule = sourceModule;
        this.externalID = externalID;
        this.ticketID = ticketID;
        this.incidentData = incidentData;
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