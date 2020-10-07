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
    public class CustomActivity_TY_Update_Pba_Configuration : IActivityAsync
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
    
    private string uriBuilderPath {
        get {
            return "SecretServer/api/v1/pba-configuration";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"data\": {{   \"challengeEnabled\": {{     \"dirty\": \"{0}\",      \"value\": \"{1}\"     }},    \"challengeLockoutIntegratedEnabled\": {{     \"dirty\": \"{2}\",      \"value\": \"{3}\"     }},    \"challengeLockoutSamlEnabled\": {{     \"dirty\": \"{4}\",      \"value\": \"{5}\"     }},    \"enabled\": {{     \"dirty\": \"{6}\",      \"value\": \"{7}\"     }},    \"encryptionEnabled\": {{     \"dirty\": \"{8}\",      \"value\": \"{9}\"     }},    \"eventDataUploadInterval\": {{     \"dirty\": \"{10}\",      \"value\": \"{11}\"     }},    \"eventDataUploadSizeThreshold\": {{     \"dirty\": \"{12}\",      \"value\": \"{13}\"     }},    \"externalPbaUrl\": {{     \"dirty\": \"{14}\",      \"value\": \"{15}\"     }},    \"fileUploadEnabled\": {{     \"dirty\": \"{16}\",      \"value\": \"{17}\"     }},    \"metadataInterval\": {{     \"dirty\": \"{18}\",      \"value\": \"{19}\"     }},    \"pbaIntegrationKey\": {{     \"dirty\": \"{20}\",      \"value\": \"{21}\"     }},    \"respectOwnerEditorRequireApprovalEnabled\": {{     \"dirty\": \"{22}\",      \"value\": \"{23}\"     }},    \"retentionDays\": {{     \"dirty\": \"{24}\",      \"value\": \"{25}\"     }},    \"siteId\": {{     \"dirty\": \"{26}\",      \"value\": \"{27}\"     }},    \"storageDirectoryPath\": {{     \"dirty\": \"{28}\",      \"value\": \"{29}\"     }}   }} }}",dirty,value,challengeLockoutIntegratedEnabled_dirty,challengeLockoutIntegratedEnabled_value,challengeLockoutSamlEnabled_dirty,challengeLockoutSamlEnabled_value,enabled_dirty,enabled_value,encryptionEnabled_dirty,encryptionEnabled_value,eventDataUploadInterval_dirty,eventDataUploadInterval_value,eventDataUploadSizeThreshold_dirty,eventDataUploadSizeThreshold_value,externalPbaUrl_dirty,externalPbaUrl_value,fileUploadEnabled_dirty,fileUploadEnabled_value,metadataInterval_dirty,metadataInterval_value,pbaIntegrationKey_dirty,pbaIntegrationKey_value,respectOwnerEditorRequireApprovalEnabled_dirty,respectOwnerEditorRequireApprovalEnabled_value,retentionDays_dirty,retentionDays_value,siteId_dirty,siteId_value,storageDirectoryPath_dirty,storageDirectoryPath_value);
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