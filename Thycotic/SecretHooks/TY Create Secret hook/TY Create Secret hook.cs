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
    public class CustomActivity_TY_Create_Secret_hook : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "hook";
    
    public string password1 = "";
    
    public string secretId = "";
    
    public string arguments = "";
    
    public string database = "";
    
    public string description = "";
    
    public string eventActionId = "";
    
    public string failureMessage = "";
    
    public string name_p = "";
    
    public string parameters__ = "";
    
    public string parameterName = "";
    
    public string parameterType = "";
    
    public string parameterValue = "";
    
    public string port = "";
    
    public string prePostOption = "";
    
    public string privilegedSecretId = "";
    
    public string scriptId = "";
    
    public string data_secretId = "";
    
    public string serverKeyDigest = "";
    
    public string serverName = "";
    
    public string sshKeySecretId = "";
    
    public string stopOnFailure = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return string.Format("SecretServer/api/v1/secret-detail/{0}/hook",secretId);
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"data\": {{   \"arguments\": \"{0}\",    \"database\": \"{1}\",    \"description\": \"{2}\",    \"eventActionId\": \"{3}\",    \"failureMessage\": \"{4}\",    \"name\": \"{5}\",    \"parameters\": [      {{       \"parameterName\": \"{6}\",        \"parameterType\": \"{7}\",        \"parameterValue\": \"{8}\"       }}    ],    \"port\": \"{9}\",    \"prePostOption\": \"{10}\",    \"privilegedSecretId\": \"{11}\",    \"scriptId\": \"{12}\",    \"secretId\": \"{13}\",    \"serverKeyDigest\": \"{14}\",    \"serverName\": \"{15}\",    \"sshKeySecretId\": \"{16}\",    \"stopOnFailure\": \"{17}\"   }} }}",arguments,database,description,eventActionId,failureMessage,name_p,parameterName,parameterType,parameterValue,port,prePostOption,privilegedSecretId,scriptId,data_secretId,serverKeyDigest,serverName,sshKeySecretId,stopOnFailure);
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