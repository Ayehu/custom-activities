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
    public class CustomActivity_TY_Update_Secret : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string accessRequestWorkflowMapId = "";
    
    public string active = "";
    
    public string autoChangeEnabled = "";
    
    public string autoChangeNextPassword = "";
    
    public string checkOutChangePasswordEnabled = "";
    
    public string checkOutEnabled = "";
    
    public string checkOutIntervalMinutes = "";
    
    public string comment = "";
    
    public string doubleLockPassword = "";
    
    public string enableInheritPermissions = "";
    
    public string enableInheritSecretPolicy = "";
    
    public string folderId = "";
    
    public string forceCheckIn = "";
    
    public string _id = "";
    
    public string includeInactive = "";
    
    public string items__ = "";
    
    public string fieldDescription = "";
    
    public string fieldId = "";
    
    public string fieldName = "";
    
    public string fileAttachmentId = "";
    
    public string filename = "";
    
    public string isFile = "";
    
    public string isNotes = "";
    
    public string isPassword = "";
    
    public string itemId = "";
    
    public string itemValue = "";
    
    public string slug = "";
    
    public string launcherConnectAsSecretId = "";
    
    public string name_p = "";
    
    public string newPassword = "";
    
    public string passwordTypeWebScriptId = "";
    
    public string proxyEnabled = "";
    
    public string requiresComment = "";
    
    public string secretPolicyId = "";
    
    public string sessionRecordingEnabled = "";
    
    public string siteId = "";
    
    public string generatePassphrase = "";
    
    public string generateSshKeys = "";
    
    public string ticketNumber = "";
    
    public string ticketSystemId = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "PUT";
    
    private string uriBuilderPath {
        get {
            return string.Format("SecretServer/api/v1/secrets/{0}",id_p);
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"accessRequestWorkflowMapId\": \"{0}\",  \"active\": \"{1}\",  \"autoChangeEnabled\": \"{2}\",  \"autoChangeNextPassword\": \"{3}\",  \"checkOutChangePasswordEnabled\": \"{4}\",  \"checkOutEnabled\": \"{5}\",  \"checkOutIntervalMinutes\": \"{6}\",  \"comment\": \"{7}\",  \"doubleLockPassword\": \"{8}\",  \"enableInheritPermissions\": \"{9}\",  \"enableInheritSecretPolicy\": \"{10}\",  \"folderId\": \"{11}\",  \"forceCheckIn\": \"{12}\",  \"id\": \"{13}\",  \"includeInactive\": \"{14}\",  \"items\": [    {{     \"fieldDescription\": \"{15}\",      \"fieldId\": \"{16}\",      \"fieldName\": \"{17}\",      \"fileAttachmentId\": \"{18}\",      \"filename\": \"{19}\",      \"isFile\": \"{20}\",      \"isNotes\": \"{21}\",      \"isPassword\": \"{22}\",      \"itemId\": \"{23}\",      \"itemValue\": \"{24}\",      \"slug\": \"{25}\"     }}  ],  \"launcherConnectAsSecretId\": \"{26}\",  \"name\": \"{27}\",  \"newPassword\": \"{28}\",  \"passwordTypeWebScriptId\": \"{29}\",  \"proxyEnabled\": \"{30}\",  \"requiresComment\": \"{31}\",  \"secretPolicyId\": \"{32}\",  \"sessionRecordingEnabled\": \"{33}\",  \"siteId\": \"{34}\",  \"sshKeyArgs\": {{   \"generatePassphrase\": \"{35}\",    \"generateSshKeys\": \"{36}\"   }},  \"ticketNumber\": \"{37}\",  \"ticketSystemId\": \"{38}\" }}",accessRequestWorkflowMapId,active,autoChangeEnabled,autoChangeNextPassword,checkOutChangePasswordEnabled,checkOutEnabled,checkOutIntervalMinutes,comment,doubleLockPassword,enableInheritPermissions,enableInheritSecretPolicy,folderId,forceCheckIn,_id,includeInactive,fieldDescription,fieldId,fieldName,fileAttachmentId,filename,isFile,isNotes,isPassword,itemId,itemValue,slug,launcherConnectAsSecretId,name_p,newPassword,passwordTypeWebScriptId,proxyEnabled,requiresComment,secretPolicyId,sessionRecordingEnabled,siteId,generatePassphrase,generateSshKeys,ticketNumber,ticketSystemId);
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