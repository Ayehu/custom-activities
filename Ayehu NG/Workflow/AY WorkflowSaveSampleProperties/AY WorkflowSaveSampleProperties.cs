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
    public class CustomActivity_AY_WorkflowSaveSampleProperties : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "saveSampleProperties";
    
    public string password1 = "";
    
    public string dateCreated = "";
    
    public string dateCreatedUser = "";
    
    public string dateLic = "";
    
    public string dateModified = "";
    
    public string dateModifiedUser = "";
    
    public string details = "";
    
    public string errorHandling__ = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string description = "";
    
    public string applyForAllWorkflows = "";
    
    public string usedInWorkflows = "";
    
    public string _name = "";
    
    public string workflowFolderId = "";
    
    public string workflowType = "";
    
    public string xomlStatus = "";
    
    public string tags__ = "";
    
    public string tags_description = "";
    
    public string tags_id = "";
    
    public string tags_name = "";
    
    public string miniMapImage = "";
    
    public string canRead = "";
    
    public string canRun = "";
    
    public string canWrite = "";
    
    public string isOwner = "";
    
    public string permissionTypeEntityName = "";
    
    public string permissionTypeEntityNumber = "";
    
    public string permissionTypeId = "";
    
    public string allPermissions__ = "";
    
    public string allPermissions_canRead = "";
    
    public string allPermissions_canRun = "";
    
    public string allPermissions_canWrite = "";
    
    public string allPermissions_isOwner = "";
    
    public string allPermissions_permissionTypeEntityName = "";
    
    public string allPermissions_permissionTypeEntityNumber = "";
    
    public string allPermissions_permissionTypeId = "";
    
    public string revisionId = "";
    
    public string isSample = "";
    
    public string isSaveAsRevision = "";
    
    public string isScheduled = "";
    
    public string isSelfService = "";
    
    public string isAssignedToTrigger = "";
    
    public string _id = "";
    
    public string labelKey = "";
    
    public string label = "";
    
    public string isAvailable = "";
    
    public string visible = "";
    
    public string icon = "";
    
    public string color = "";
    
    public string _description = "";
    
    public string index = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "PUT";
    
    private string uriBuilderPath {
        get {
            return "Server/Api/workflow/saveSampleProperties";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"dateCreated\": \"{0}\",  \"dateCreatedUser\": \"{1}\",  \"dateLic\": \"{2}\",  \"dateModified\": \"{3}\",  \"dateModifiedUser\": \"{4}\",  \"details\": \"{5}\",  \"errorHandling\": [    {{     \"id\": \"{6}\",      \"name\": \"{7}\",      \"description\": \"{8}\",      \"applyForAllWorkflows\": \"{9}\",      \"usedInWorkflows\": \"{10}\"     }}  ],  \"name\": \"{11}\",  \"workflowFolderId\": \"{12}\",  \"workflowType\": \"{13}\",  \"xomlStatus\": \"{14}\",  \"tags\": [    {{     \"description\": \"{15}\",      \"id\": \"{16}\",      \"name\": \"{17}\"     }}  ],  \"miniMapImage\": \"{18}\",  \"permissions\": {{   \"canRead\": \"{19}\",    \"canRun\": \"{20}\",    \"canWrite\": \"{21}\",    \"isOwner\": \"{22}\",    \"permissionTypeEntityName\": \"{23}\",    \"permissionTypeEntityNumber\": \"{24}\",    \"permissionTypeId\": \"{25}\"   }},  \"allPermissions\": [    {{     \"canRead\": \"{26}\",      \"canRun\": \"{27}\",      \"canWrite\": \"{28}\",      \"isOwner\": \"{29}\",      \"permissionTypeEntityName\": \"{30}\",      \"permissionTypeEntityNumber\": \"{31}\",      \"permissionTypeId\": \"{32}\"     }}  ],  \"revisionId\": \"{33}\",  \"isSample\": \"{34}\",  \"isSaveAsRevision\": \"{35}\",  \"isScheduled\": \"{36}\",  \"isSelfService\": \"{37}\",  \"isAssignedToTrigger\": \"{38}\",  \"id\": \"{39}\",  \"labelKey\": \"{40}\",  \"label\": \"{41}\",  \"isAvailable\": \"{42}\",  \"visible\": \"{43}\",  \"icon\": \"{44}\",  \"color\": \"{45}\",  \"description\": \"{46}\",  \"index\": \"{47}\" }}",dateCreated,dateCreatedUser,dateLic,dateModified,dateModifiedUser,details,id_p,name_p,description,applyForAllWorkflows,usedInWorkflows,_name,workflowFolderId,workflowType,xomlStatus,tags_description,tags_id,tags_name,miniMapImage,canRead,canRun,canWrite,isOwner,permissionTypeEntityName,permissionTypeEntityNumber,permissionTypeId,allPermissions_canRead,allPermissions_canRun,allPermissions_canWrite,allPermissions_isOwner,allPermissions_permissionTypeEntityName,allPermissions_permissionTypeEntityNumber,allPermissions_permissionTypeId,revisionId,isSample,isSaveAsRevision,isScheduled,isSelfService,isAssignedToTrigger,_id,labelKey,label,isAvailable,visible,icon,color,_description,index);
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