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
    public class AY_WorkflowSaveWorkflowProperties : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "saveWorkflowProperties";
    
    public string password1 = "";
    
    public string dateCreated = "";
    
    public string dateCreatedUser = "";
    
    public string dateLic = "";
    
    public string dateModified = "";
    
    public string dateModifiedUser = "";
    
    public string details = "";
    
    public string errorHandling = "";
    
    public string _name = "";
    
    public string workflowFolderId = "";
    
    public string workflowType = "";
    
    public string xomlStatus = "";
    
    public string tags = "";
    
    public string miniMapImage = "";
    
    public string canRead = "";
    
    public string canRun = "";
    
    public string canWrite = "";
    
    public string isOwner = "";
    
    public string permissionTypeEntityName = "";
    
    public string permissionTypeEntityNumber = "";
    
    public string permissionTypeId = "";
    
    public string allPermissions = "";
    
    public string revisionId = "";
    
    public string isSample = "";
    
    public string isSaveAsRevision = "";
    
    public string isScheduled = "";
    
    public string isSelfService = "";
    
    public string isAssignedToTrigger = "";
    
    public string _id = "";
    
    public string labelKey = "";
    
    public string label_p = "";
    
    public string isAvailable_p = "";
    
    public string visible_p = "";
    
    public string icon_p = "";
    
    public string color_p = "";
    
    public string _description = "";
    
    public string index_p = "";
    
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
_uriBuilderPath = "Server/Api/workflow/saveWorkflowProperties";
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
_postData = string.Format("{{ \"dateCreated\": \"{0}\",  \"dateCreatedUser\": \"{1}\",  \"dateLic\": \"{2}\",  \"dateModified\": \"{3}\",  \"dateModifiedUser\": \"{4}\",  \"details\": \"{5}\",  \"errorHandling\": {6},  \"name\": \"{7}\",  \"workflowFolderId\": \"{8}\",  \"workflowType\": \"{9}\",  \"xomlStatus\": \"{10}\",  \"tags\": {11},  \"miniMapImage\": \"{12}\",  \"permissions\": {{   \"canRead\": \"{13}\",    \"canRun\": \"{14}\",    \"canWrite\": \"{15}\",    \"isOwner\": \"{16}\",    \"permissionTypeEntityName\": \"{17}\",    \"permissionTypeEntityNumber\": \"{18}\",    \"permissionTypeId\": \"{19}\"   }},  \"allPermissions\": {20},  \"revisionId\": \"{21}\",  \"isSample\": \"{22}\",  \"isSaveAsRevision\": \"{23}\",  \"isScheduled\": \"{24}\",  \"isSelfService\": \"{25}\",  \"isAssignedToTrigger\": \"{26}\",  \"id\": \"{27}\",  \"labelKey\": \"{28}\",  \"label\": \"{29}\",  \"isAvailable\": \"{30}\",  \"visible\": \"{31}\",  \"icon\": \"{32}\",  \"color\": \"{33}\",  \"description\": \"{34}\",  \"index\": \"{35}\" }}",dateCreated,dateCreatedUser,dateLic,dateModified,dateModifiedUser,details,errorHandling,_name,workflowFolderId,workflowType,xomlStatus,tags,miniMapImage,canRead,canRun,canWrite,isOwner,permissionTypeEntityName,permissionTypeEntityNumber,permissionTypeId,allPermissions,revisionId,isSample,isSaveAsRevision,isScheduled,isSelfService,isAssignedToTrigger,_id,labelKey,label_p,isAvailable_p,visible_p,icon_p,color_p,_description,index_p);
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
    
    public AY_WorkflowSaveWorkflowProperties() {
    }
    
    public AY_WorkflowSaveWorkflowProperties(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string dateCreated, 
                string dateCreatedUser, 
                string dateLic, 
                string dateModified, 
                string dateModifiedUser, 
                string details, 
                string errorHandling, 
                string _name, 
                string workflowFolderId, 
                string workflowType, 
                string xomlStatus, 
                string tags, 
                string miniMapImage, 
                string canRead, 
                string canRun, 
                string canWrite, 
                string isOwner, 
                string permissionTypeEntityName, 
                string permissionTypeEntityNumber, 
                string permissionTypeId, 
                string allPermissions, 
                string revisionId, 
                string isSample, 
                string isSaveAsRevision, 
                string isScheduled, 
                string isSelfService, 
                string isAssignedToTrigger, 
                string _id, 
                string labelKey, 
                string label_p, 
                string isAvailable_p, 
                string visible_p, 
                string icon_p, 
                string color_p, 
                string _description, 
                string index_p) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.dateCreated = dateCreated;
        this.dateCreatedUser = dateCreatedUser;
        this.dateLic = dateLic;
        this.dateModified = dateModified;
        this.dateModifiedUser = dateModifiedUser;
        this.details = details;
        this.errorHandling = errorHandling;
        this._name = _name;
        this.workflowFolderId = workflowFolderId;
        this.workflowType = workflowType;
        this.xomlStatus = xomlStatus;
        this.tags = tags;
        this.miniMapImage = miniMapImage;
        this.canRead = canRead;
        this.canRun = canRun;
        this.canWrite = canWrite;
        this.isOwner = isOwner;
        this.permissionTypeEntityName = permissionTypeEntityName;
        this.permissionTypeEntityNumber = permissionTypeEntityNumber;
        this.permissionTypeId = permissionTypeId;
        this.allPermissions = allPermissions;
        this.revisionId = revisionId;
        this.isSample = isSample;
        this.isSaveAsRevision = isSaveAsRevision;
        this.isScheduled = isScheduled;
        this.isSelfService = isSelfService;
        this.isAssignedToTrigger = isAssignedToTrigger;
        this._id = _id;
        this.labelKey = labelKey;
        this.label_p = label_p;
        this.isAvailable_p = isAvailable_p;
        this.visible_p = visible_p;
        this.icon_p = icon_p;
        this.color_p = color_p;
        this._description = _description;
        this.index_p = index_p;
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