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
    public class TY_Update_Pba_Configuration : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "pba-configuration";
    
    public string password1 = "";
    
    public string dirty = "";
    
    public string value = "";
    
    public string challengeLockoutIntegratedEnabled_dirty = "";
    
    public string challengeLockoutIntegratedEnabled_value = "";
    
    public string challengeLockoutSamlEnabled_dirty = "";
    
    public string challengeLockoutSamlEnabled_value = "";
    
    public string enabled_dirty = "";
    
    public string enabled_value = "";
    
    public string encryptionEnabled_dirty = "";
    
    public string encryptionEnabled_value = "";
    
    public string eventDataUploadInterval_dirty = "";
    
    public string eventDataUploadInterval_value = "";
    
    public string eventDataUploadSizeThreshold_dirty = "";
    
    public string eventDataUploadSizeThreshold_value = "";
    
    public string externalPbaUrl_dirty = "";
    
    public string externalPbaUrl_value = "";
    
    public string fileUploadEnabled_dirty = "";
    
    public string fileUploadEnabled_value = "";
    
    public string metadataInterval_dirty = "";
    
    public string metadataInterval_value = "";
    
    public string pbaIntegrationKey_dirty = "";
    
    public string pbaIntegrationKey_value = "";
    
    public string respectOwnerEditorRequireApprovalEnabled_dirty = "";
    
    public string respectOwnerEditorRequireApprovalEnabled_value = "";
    
    public string retentionDays_dirty = "";
    
    public string retentionDays_value = "";
    
    public string siteId_dirty = "";
    
    public string siteId_value = "";
    
    public string storageDirectoryPath_dirty = "";
    
    public string storageDirectoryPath_value = "";
    
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
_uriBuilderPath = "SecretServer/api/v1/pba-configuration";
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
_postData = string.Format("{{ \"data\": {{   \"challengeEnabled\": {{     \"dirty\": \"{0}\",      \"value\": \"{1}\"     }},    \"challengeLockoutIntegratedEnabled\": {{     \"dirty\": \"{2}\",      \"value\": \"{3}\"     }},    \"challengeLockoutSamlEnabled\": {{     \"dirty\": \"{4}\",      \"value\": \"{5}\"     }},    \"enabled\": {{     \"dirty\": \"{6}\",      \"value\": \"{7}\"     }},    \"encryptionEnabled\": {{     \"dirty\": \"{8}\",      \"value\": \"{9}\"     }},    \"eventDataUploadInterval\": {{     \"dirty\": \"{10}\",      \"value\": \"{11}\"     }},    \"eventDataUploadSizeThreshold\": {{     \"dirty\": \"{12}\",      \"value\": \"{13}\"     }},    \"externalPbaUrl\": {{     \"dirty\": \"{14}\",      \"value\": \"{15}\"     }},    \"fileUploadEnabled\": {{     \"dirty\": \"{16}\",      \"value\": \"{17}\"     }},    \"metadataInterval\": {{     \"dirty\": \"{18}\",      \"value\": \"{19}\"     }},    \"pbaIntegrationKey\": {{     \"dirty\": \"{20}\",      \"value\": \"{21}\"     }},    \"respectOwnerEditorRequireApprovalEnabled\": {{     \"dirty\": \"{22}\",      \"value\": \"{23}\"     }},    \"retentionDays\": {{     \"dirty\": \"{24}\",      \"value\": \"{25}\"     }},    \"siteId\": {{     \"dirty\": \"{26}\",      \"value\": \"{27}\"     }},    \"storageDirectoryPath\": {{     \"dirty\": \"{28}\",      \"value\": \"{29}\"     }}   }} }}",dirty,value,challengeLockoutIntegratedEnabled_dirty,challengeLockoutIntegratedEnabled_value,challengeLockoutSamlEnabled_dirty,challengeLockoutSamlEnabled_value,enabled_dirty,enabled_value,encryptionEnabled_dirty,encryptionEnabled_value,eventDataUploadInterval_dirty,eventDataUploadInterval_value,eventDataUploadSizeThreshold_dirty,eventDataUploadSizeThreshold_value,externalPbaUrl_dirty,externalPbaUrl_value,fileUploadEnabled_dirty,fileUploadEnabled_value,metadataInterval_dirty,metadataInterval_value,pbaIntegrationKey_dirty,pbaIntegrationKey_value,respectOwnerEditorRequireApprovalEnabled_dirty,respectOwnerEditorRequireApprovalEnabled_value,retentionDays_dirty,retentionDays_value,siteId_dirty,siteId_value,storageDirectoryPath_dirty,storageDirectoryPath_value);
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
    
    public TY_Update_Pba_Configuration() {
    }
    
    public TY_Update_Pba_Configuration(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string dirty, 
                string value, 
                string challengeLockoutIntegratedEnabled_dirty, 
                string challengeLockoutIntegratedEnabled_value, 
                string challengeLockoutSamlEnabled_dirty, 
                string challengeLockoutSamlEnabled_value, 
                string enabled_dirty, 
                string enabled_value, 
                string encryptionEnabled_dirty, 
                string encryptionEnabled_value, 
                string eventDataUploadInterval_dirty, 
                string eventDataUploadInterval_value, 
                string eventDataUploadSizeThreshold_dirty, 
                string eventDataUploadSizeThreshold_value, 
                string externalPbaUrl_dirty, 
                string externalPbaUrl_value, 
                string fileUploadEnabled_dirty, 
                string fileUploadEnabled_value, 
                string metadataInterval_dirty, 
                string metadataInterval_value, 
                string pbaIntegrationKey_dirty, 
                string pbaIntegrationKey_value, 
                string respectOwnerEditorRequireApprovalEnabled_dirty, 
                string respectOwnerEditorRequireApprovalEnabled_value, 
                string retentionDays_dirty, 
                string retentionDays_value, 
                string siteId_dirty, 
                string siteId_value, 
                string storageDirectoryPath_dirty, 
                string storageDirectoryPath_value) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.dirty = dirty;
        this.value = value;
        this.challengeLockoutIntegratedEnabled_dirty = challengeLockoutIntegratedEnabled_dirty;
        this.challengeLockoutIntegratedEnabled_value = challengeLockoutIntegratedEnabled_value;
        this.challengeLockoutSamlEnabled_dirty = challengeLockoutSamlEnabled_dirty;
        this.challengeLockoutSamlEnabled_value = challengeLockoutSamlEnabled_value;
        this.enabled_dirty = enabled_dirty;
        this.enabled_value = enabled_value;
        this.encryptionEnabled_dirty = encryptionEnabled_dirty;
        this.encryptionEnabled_value = encryptionEnabled_value;
        this.eventDataUploadInterval_dirty = eventDataUploadInterval_dirty;
        this.eventDataUploadInterval_value = eventDataUploadInterval_value;
        this.eventDataUploadSizeThreshold_dirty = eventDataUploadSizeThreshold_dirty;
        this.eventDataUploadSizeThreshold_value = eventDataUploadSizeThreshold_value;
        this.externalPbaUrl_dirty = externalPbaUrl_dirty;
        this.externalPbaUrl_value = externalPbaUrl_value;
        this.fileUploadEnabled_dirty = fileUploadEnabled_dirty;
        this.fileUploadEnabled_value = fileUploadEnabled_value;
        this.metadataInterval_dirty = metadataInterval_dirty;
        this.metadataInterval_value = metadataInterval_value;
        this.pbaIntegrationKey_dirty = pbaIntegrationKey_dirty;
        this.pbaIntegrationKey_value = pbaIntegrationKey_value;
        this.respectOwnerEditorRequireApprovalEnabled_dirty = respectOwnerEditorRequireApprovalEnabled_dirty;
        this.respectOwnerEditorRequireApprovalEnabled_value = respectOwnerEditorRequireApprovalEnabled_value;
        this.retentionDays_dirty = retentionDays_dirty;
        this.retentionDays_value = retentionDays_value;
        this.siteId_dirty = siteId_dirty;
        this.siteId_value = siteId_value;
        this.storageDirectoryPath_dirty = storageDirectoryPath_dirty;
        this.storageDirectoryPath_value = storageDirectoryPath_value;
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