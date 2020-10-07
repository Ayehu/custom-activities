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
    public class CustomActivity_TY_Create_Secret : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "secrets";
    
    public string password1 = "";
    
    public string autoChangeEnabled = "";
    
    public string checkOutChangePasswordEnabled = "";
    
    public string checkOutEnabled = "";
    
    public string checkOutIntervalMinutes = "";
    
    public string enableInheritPermissions = "";
    
    public string enableInheritSecretPolicy = "";
    
    public string folderId = "";
    
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
    
    public string passwordTypeWebScriptId = "";
    
    public string proxyEnabled = "";
    
    public string requiresComment = "";
    
    public string secretPolicyId = "";
    
    public string secretTemplateId = "";
    
    public string sessionRecordingEnabled = "";
    
    public string siteId = "";
    
    public string generatePassphrase = "";
    
    public string generateSshKeys = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "SecretServer/api/v1/secrets";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"autoChangeEnabled\": \"{0}\",  \"checkOutChangePasswordEnabled\": \"{1}\",  \"checkOutEnabled\": \"{2}\",  \"checkOutIntervalMinutes\": \"{3}\",  \"enableInheritPermissions\": \"{4}\",  \"enableInheritSecretPolicy\": \"{5}\",  \"folderId\": \"{6}\",  \"items\": [    {{     \"fieldDescription\": \"{7}\",      \"fieldId\": \"{8}\",      \"fieldName\": \"{9}\",      \"fileAttachmentId\": \"{10}\",      \"filename\": \"{11}\",      \"isFile\": \"{12}\",      \"isNotes\": \"{13}\",      \"isPassword\": \"{14}\",      \"itemId\": \"{15}\",      \"itemValue\": \"{16}\",      \"slug\": \"{17}\"     }}  ],  \"launcherConnectAsSecretId\": \"{18}\",  \"name\": \"{19}\",  \"passwordTypeWebScriptId\": \"{20}\",  \"proxyEnabled\": \"{21}\",  \"requiresComment\": \"{22}\",  \"secretPolicyId\": \"{23}\",  \"secretTemplateId\": \"{24}\",  \"sessionRecordingEnabled\": \"{25}\",  \"siteId\": \"{26}\",  \"sshKeyArgs\": {{   \"generatePassphrase\": \"{27}\",    \"generateSshKeys\": \"{28}\"   }} }}",autoChangeEnabled,checkOutChangePasswordEnabled,checkOutEnabled,checkOutIntervalMinutes,enableInheritPermissions,enableInheritSecretPolicy,folderId,fieldDescription,fieldId,fieldName,fileAttachmentId,filename,isFile,isNotes,isPassword,itemId,itemValue,slug,launcherConnectAsSecretId,name_p,passwordTypeWebScriptId,proxyEnabled,requiresComment,secretPolicyId,secretTemplateId,sessionRecordingEnabled,siteId,generatePassphrase,generateSshKeys);
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