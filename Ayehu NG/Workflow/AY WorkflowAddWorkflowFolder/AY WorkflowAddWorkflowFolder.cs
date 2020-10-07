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
    public class CustomActivity_AY_WorkflowAddWorkflowFolder : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "addWorkflowFolder";
    
    public string password1 = "";
    
    public string workflowsAmount = "";
    
    public string foldersAmount = "";
    
    public string parentId = "";
    
    public string workflowFolders__ = "";
    
    public string workflowFolders_workflowsAmount = "";
    
    public string workflowFolders_foldersAmount = "";
    
    public string workflowFolders_parentId = "";
    
    public string workflowList__ = "";
    
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
    
    public string workflowList_name = "";
    
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
    
    public string workflowList_id = "";
    
    public string labelKey = "";
    
    public string label = "";
    
    public string isAvailable = "";
    
    public string visible = "";
    
    public string icon = "";
    
    public string color = "";
    
    public string workflowList_description = "";
    
    public string index = "";
    
    public string workflowFolders_id = "";
    
    public string workflowFolders_labelKey = "";
    
    public string workflowFolders_label = "";
    
    public string workflowFolders_isAvailable = "";
    
    public string workflowFolders_visible = "";
    
    public string workflowFolders_icon = "";
    
    public string workflowFolders_color = "";
    
    public string workflowFolders_description = "";
    
    public string workflowFolders_index = "";
    
    public string workflowList_dateCreated = "";
    
    public string workflowList_dateCreatedUser = "";
    
    public string workflowList_dateLic = "";
    
    public string workflowList_dateModified = "";
    
    public string workflowList_dateModifiedUser = "";
    
    public string workflowList_details = "";
    
    public string errorHandling_id = "";
    
    public string errorHandling_name = "";
    
    public string errorHandling_description = "";
    
    public string errorHandling_applyForAllWorkflows = "";
    
    public string errorHandling_usedInWorkflows = "";
    
    public string workflowList_workflowFolderId = "";
    
    public string workflowList_workflowType = "";
    
    public string workflowList_xomlStatus = "";
    
    public string workflowList_miniMapImage = "";
    
    public string permissions_canRead = "";
    
    public string permissions_canRun = "";
    
    public string permissions_canWrite = "";
    
    public string permissions_isOwner = "";
    
    public string permissions_permissionTypeEntityName = "";
    
    public string permissions_permissionTypeEntityNumber = "";
    
    public string permissions_permissionTypeId = "";
    
    public string workflowList_revisionId = "";
    
    public string workflowList_isSample = "";
    
    public string workflowList_isSaveAsRevision = "";
    
    public string workflowList_isScheduled = "";
    
    public string workflowList_isSelfService = "";
    
    public string workflowList_isAssignedToTrigger = "";
    
    public string workflowList_labelKey = "";
    
    public string workflowList_label = "";
    
    public string workflowList_isAvailable = "";
    
    public string workflowList_visible = "";
    
    public string workflowList_icon = "";
    
    public string workflowList_color = "";
    
    public string workflowList_index = "";
    
    public string _id = "";
    
    public string _labelKey = "";
    
    public string _label = "";
    
    public string _isAvailable = "";
    
    public string _visible = "";
    
    public string _icon = "";
    
    public string _color = "";
    
    public string _description = "";
    
    public string _index = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "Server/Api/workflow/addWorkflowFolder";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"workflowsAmount\": \"{0}\",  \"foldersAmount\": \"{1}\",  \"parentId\": \"{2}\",  \"workflowFolders\": [    {{     \"workflowsAmount\": \"{3}\",      \"foldersAmount\": \"{4}\",      \"parentId\": \"{5}\",      \"workflowFolders\": [        {{         \"workflowsAmount\": \"{3}\",          \"foldersAmount\": \"{4}\",          \"parentId\": \"{5}\",          \"workflowList\": [            {{             \"dateCreated\": \"{6}\",              \"dateCreatedUser\": \"{7}\",              \"dateLic\": \"{8}\",              \"dateModified\": \"{9}\",              \"dateModifiedUser\": \"{10}\",              \"details\": \"{11}\",              \"errorHandling\": [                {{                 \"id\": \"{12}\",                  \"name\": \"{13}\",                  \"description\": \"{14}\",                  \"applyForAllWorkflows\": \"{15}\",                  \"usedInWorkflows\": \"{16}\"                 }}              ],              \"name\": \"{17}\",              \"workflowFolderId\": \"{18}\",              \"workflowType\": \"{19}\",              \"xomlStatus\": \"{20}\",              \"tags\": [                {{                 \"description\": \"{21}\",                  \"id\": \"{22}\",                  \"name\": \"{23}\"                 }}              ],              \"miniMapImage\": \"{24}\",              \"permissions\": {{               \"canRead\": \"{25}\",                \"canRun\": \"{26}\",                \"canWrite\": \"{27}\",                \"isOwner\": \"{28}\",                \"permissionTypeEntityName\": \"{29}\",                \"permissionTypeEntityNumber\": \"{30}\",                \"permissionTypeId\": \"{31}\"               }},              \"allPermissions\": [                {{                 \"canRead\": \"{32}\",                  \"canRun\": \"{33}\",                  \"canWrite\": \"{34}\",                  \"isOwner\": \"{35}\",                  \"permissionTypeEntityName\": \"{36}\",                  \"permissionTypeEntityNumber\": \"{37}\",                  \"permissionTypeId\": \"{38}\"                 }}              ],              \"revisionId\": \"{39}\",              \"isSample\": \"{40}\",              \"isSaveAsRevision\": \"{41}\",              \"isScheduled\": \"{42}\",              \"isSelfService\": \"{43}\",              \"isAssignedToTrigger\": \"{44}\",              \"id\": \"{45}\",              \"labelKey\": \"{46}\",              \"label\": \"{47}\",              \"isAvailable\": \"{48}\",              \"visible\": \"{49}\",              \"icon\": \"{50}\",              \"color\": \"{51}\",              \"description\": \"{52}\",              \"index\": \"{53}\"             }}          ],          \"id\": \"{54}\",          \"labelKey\": \"{55}\",          \"label\": \"{56}\",          \"isAvailable\": \"{57}\",          \"visible\": \"{58}\",          \"icon\": \"{59}\",          \"color\": \"{60}\",          \"description\": \"{61}\",          \"index\": \"{62}\"         }}      ],      \"workflowList\": [        {{         \"dateCreated\": \"{63}\",          \"dateCreatedUser\": \"{64}\",          \"dateLic\": \"{65}\",          \"dateModified\": \"{66}\",          \"dateModifiedUser\": \"{67}\",          \"details\": \"{68}\",          \"errorHandling\": [            {{             \"id\": \"{69}\",              \"name\": \"{70}\",              \"description\": \"{71}\",              \"applyForAllWorkflows\": \"{72}\",              \"usedInWorkflows\": \"{73}\"             }}          ],          \"name\": \"{17}\",          \"workflowFolderId\": \"{74}\",          \"workflowType\": \"{75}\",          \"xomlStatus\": \"{76}\",          \"tags\": [            {{             \"description\": \"{21}\",              \"id\": \"{22}\",              \"name\": \"{23}\"             }}          ],          \"miniMapImage\": \"{77}\",          \"permissions\": {{           \"canRead\": \"{78}\",            \"canRun\": \"{79}\",            \"canWrite\": \"{80}\",            \"isOwner\": \"{81}\",            \"permissionTypeEntityName\": \"{82}\",            \"permissionTypeEntityNumber\": \"{83}\",            \"permissionTypeId\": \"{84}\"           }},          \"allPermissions\": [            {{             \"canRead\": \"{32}\",              \"canRun\": \"{33}\",              \"canWrite\": \"{34}\",              \"isOwner\": \"{35}\",              \"permissionTypeEntityName\": \"{36}\",              \"permissionTypeEntityNumber\": \"{37}\",              \"permissionTypeId\": \"{38}\"             }}          ],          \"revisionId\": \"{85}\",          \"isSample\": \"{86}\",          \"isSaveAsRevision\": \"{87}\",          \"isScheduled\": \"{88}\",          \"isSelfService\": \"{89}\",          \"isAssignedToTrigger\": \"{90}\",          \"id\": \"{45}\",          \"labelKey\": \"{91}\",          \"label\": \"{92}\",          \"isAvailable\": \"{93}\",          \"visible\": \"{94}\",          \"icon\": \"{95}\",          \"color\": \"{96}\",          \"description\": \"{52}\",          \"index\": \"{97}\"         }}      ],      \"id\": \"{54}\",      \"labelKey\": \"{55}\",      \"label\": \"{56}\",      \"isAvailable\": \"{57}\",      \"visible\": \"{58}\",      \"icon\": \"{59}\",      \"color\": \"{60}\",      \"description\": \"{61}\",      \"index\": \"{62}\"     }}  ],  \"workflowList\": [    {{     \"dateCreated\": \"{63}\",      \"dateCreatedUser\": \"{64}\",      \"dateLic\": \"{65}\",      \"dateModified\": \"{66}\",      \"dateModifiedUser\": \"{67}\",      \"details\": \"{68}\",      \"errorHandling\": [        {{         \"id\": \"{69}\",          \"name\": \"{70}\",          \"description\": \"{71}\",          \"applyForAllWorkflows\": \"{72}\",          \"usedInWorkflows\": \"{73}\"         }}      ],      \"name\": \"{17}\",      \"workflowFolderId\": \"{74}\",      \"workflowType\": \"{75}\",      \"xomlStatus\": \"{76}\",      \"tags\": [        {{         \"description\": \"{21}\",          \"id\": \"{22}\",          \"name\": \"{23}\"         }}      ],      \"miniMapImage\": \"{77}\",      \"permissions\": {{       \"canRead\": \"{78}\",        \"canRun\": \"{79}\",        \"canWrite\": \"{80}\",        \"isOwner\": \"{81}\",        \"permissionTypeEntityName\": \"{82}\",        \"permissionTypeEntityNumber\": \"{83}\",        \"permissionTypeId\": \"{84}\"       }},      \"allPermissions\": [        {{         \"canRead\": \"{32}\",          \"canRun\": \"{33}\",          \"canWrite\": \"{34}\",          \"isOwner\": \"{35}\",          \"permissionTypeEntityName\": \"{36}\",          \"permissionTypeEntityNumber\": \"{37}\",          \"permissionTypeId\": \"{38}\"         }}      ],      \"revisionId\": \"{85}\",      \"isSample\": \"{86}\",      \"isSaveAsRevision\": \"{87}\",      \"isScheduled\": \"{88}\",      \"isSelfService\": \"{89}\",      \"isAssignedToTrigger\": \"{90}\",      \"id\": \"{45}\",      \"labelKey\": \"{91}\",      \"label\": \"{92}\",      \"isAvailable\": \"{93}\",      \"visible\": \"{94}\",      \"icon\": \"{95}\",      \"color\": \"{96}\",      \"description\": \"{52}\",      \"index\": \"{97}\"     }}  ],  \"id\": \"{98}\",  \"labelKey\": \"{99}\",  \"label\": \"{100}\",  \"isAvailable\": \"{101}\",  \"visible\": \"{102}\",  \"icon\": \"{103}\",  \"color\": \"{104}\",  \"description\": \"{105}\",  \"index\": \"{106}\" }}",workflowsAmount,foldersAmount,parentId,workflowFolders_workflowsAmount,workflowFolders_foldersAmount,workflowFolders_parentId,dateCreated,dateCreatedUser,dateLic,dateModified,dateModifiedUser,details,id_p,name_p,description,applyForAllWorkflows,usedInWorkflows,workflowList_name,workflowFolderId,workflowType,xomlStatus,tags_description,tags_id,tags_name,miniMapImage,canRead,canRun,canWrite,isOwner,permissionTypeEntityName,permissionTypeEntityNumber,permissionTypeId,allPermissions_canRead,allPermissions_canRun,allPermissions_canWrite,allPermissions_isOwner,allPermissions_permissionTypeEntityName,allPermissions_permissionTypeEntityNumber,allPermissions_permissionTypeId,revisionId,isSample,isSaveAsRevision,isScheduled,isSelfService,isAssignedToTrigger,workflowList_id,labelKey,label,isAvailable,visible,icon,color,workflowList_description,index,workflowFolders_id,workflowFolders_labelKey,workflowFolders_label,workflowFolders_isAvailable,workflowFolders_visible,workflowFolders_icon,workflowFolders_color,workflowFolders_description,workflowFolders_index,workflowList_dateCreated,workflowList_dateCreatedUser,workflowList_dateLic,workflowList_dateModified,workflowList_dateModifiedUser,workflowList_details,errorHandling_id,errorHandling_name,errorHandling_description,errorHandling_applyForAllWorkflows,errorHandling_usedInWorkflows,workflowList_workflowFolderId,workflowList_workflowType,workflowList_xomlStatus,workflowList_miniMapImage,permissions_canRead,permissions_canRun,permissions_canWrite,permissions_isOwner,permissions_permissionTypeEntityName,permissions_permissionTypeEntityNumber,permissions_permissionTypeId,workflowList_revisionId,workflowList_isSample,workflowList_isSaveAsRevision,workflowList_isScheduled,workflowList_isSelfService,workflowList_isAssignedToTrigger,workflowList_labelKey,workflowList_label,workflowList_isAvailable,workflowList_visible,workflowList_icon,workflowList_color,workflowList_index,_id,_labelKey,_label,_isAvailable,_visible,_icon,_color,_description,_index);
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