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
    public class CustomActivity_TY_Update_Secret_Hook : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string password1 = "";
    
    public string secretHookId = "";
    
    public string secretId = "";
    
    public string dirty = "";
    
    public string value = "";
    
    public string database_dirty = "";
    
    public string database_value = "";
    
    public string description_dirty = "";
    
    public string description_value = "";
    
    public string eventActionId_dirty = "";
    
    public string eventActionId_value = "";
    
    public string failureMessage_dirty = "";
    
    public string failureMessage_value = "";
    
    public string name_dirty = "";
    
    public string name_value = "";
    
    public string parameters__ = "";
    
    public string parameterName = "";
    
    public string parameterType = "";
    
    public string parameterValue = "";
    
    public string port_dirty = "";
    
    public string port_value = "";
    
    public string prePostOption_dirty = "";
    
    public string prePostOption_value = "";
    
    public string privilegedSecretId_dirty = "";
    
    public string privilegedSecretId_value = "";
    
    public string scriptId_dirty = "";
    
    public string scriptId_value = "";
    
    public string scriptTypeId_dirty = "";
    
    public string scriptTypeId_value = "";
    
    public string serverKeyDigest_dirty = "";
    
    public string serverKeyDigest_value = "";
    
    public string serverName_dirty = "";
    
    public string serverName_value = "";
    
    public string sortOrder_dirty = "";
    
    public string sortOrder_value = "";
    
    public string sshKeySecretId_dirty = "";
    
    public string sshKeySecretId_value = "";
    
    public string status_dirty = "";
    
    public string status_value = "";
    
    public string stopOnFailure_dirty = "";
    
    public string stopOnFailure_value = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "PUT";
    
    private string uriBuilderPath {
        get {
            return string.Format("SecretServer/api/v1/secret-detail/{1}/hook/{0}",secretHookId,secretId);
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"data\": {{   \"arguments\": {{     \"dirty\": \"{0}\",      \"value\": \"{1}\"     }},    \"database\": {{     \"dirty\": \"{2}\",      \"value\": \"{3}\"     }},    \"description\": {{     \"dirty\": \"{4}\",      \"value\": \"{5}\"     }},    \"eventActionId\": {{     \"dirty\": \"{6}\",      \"value\": \"{7}\"     }},    \"failureMessage\": {{     \"dirty\": \"{8}\",      \"value\": \"{9}\"     }},    \"name\": {{     \"dirty\": \"{10}\",      \"value\": \"{11}\"     }},    \"parameters\": [      {{       \"parameterName\": \"{12}\",        \"parameterType\": \"{13}\",        \"parameterValue\": \"{14}\"       }}    ],    \"port\": {{     \"dirty\": \"{15}\",      \"value\": \"{16}\"     }},    \"prePostOption\": {{     \"dirty\": \"{17}\",      \"value\": \"{18}\"     }},    \"privilegedSecretId\": {{     \"dirty\": \"{19}\",      \"value\": \"{20}\"     }},    \"scriptId\": {{     \"dirty\": \"{21}\",      \"value\": \"{22}\"     }},    \"scriptTypeId\": {{     \"dirty\": \"{23}\",      \"value\": \"{24}\"     }},    \"serverKeyDigest\": {{     \"dirty\": \"{25}\",      \"value\": \"{26}\"     }},    \"serverName\": {{     \"dirty\": \"{27}\",      \"value\": \"{28}\"     }},    \"sortOrder\": {{     \"dirty\": \"{29}\",      \"value\": \"{30}\"     }},    \"sshKeySecretId\": {{     \"dirty\": \"{31}\",      \"value\": \"{32}\"     }},    \"status\": {{     \"dirty\": \"{33}\",      \"value\": \"{34}\"     }},    \"stopOnFailure\": {{     \"dirty\": \"{35}\",      \"value\": \"{36}\"     }}   }} }}",dirty,value,database_dirty,database_value,description_dirty,description_value,eventActionId_dirty,eventActionId_value,failureMessage_dirty,failureMessage_value,name_dirty,name_value,parameterName,parameterType,parameterValue,port_dirty,port_value,prePostOption_dirty,prePostOption_value,privilegedSecretId_dirty,privilegedSecretId_value,scriptId_dirty,scriptId_value,scriptTypeId_dirty,scriptTypeId_value,serverKeyDigest_dirty,serverKeyDigest_value,serverName_dirty,serverName_value,sortOrder_dirty,sortOrder_value,sshKeySecretId_dirty,sshKeySecretId_value,status_dirty,status_value,stopOnFailure_dirty,stopOnFailure_value);
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