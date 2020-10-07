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
    public class CustomActivity_AY_FrameworkUploadMultipleFile : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "uploadMultipleFile";
    
    public string password1 = "";
    
    public string lstFile = "";
    
    public string id_p = "";
    
    public string fileId = "";
    
    public string fileName = "";
    
    public string fileType = "";
    
    public string fileData = "";
    
    public string fileDataType = "";
    
    public string fileMetaData = "";
    
    public string dateCreated = "";
    
    public string userCreatedBy = "";
    
    public string code = "";
    
    public string description = "";
    
    public string extraData = "";
    
    public string errorsList__ = "";
    
    public string errorsList_code = "";
    
    public string errorsList_description = "";
    
    public string errorsList_extraData = "";
    
    public string errorType = "";
    
    public string errorsList_errorType = "";
    
    public string errorMessageDetails_errorType = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "Server/Api/Framework/uploadMultipleFile";
        }
    }
    
    private string postData {
        get {
            return string.Format("[  {{   \"id\": \"{0}\",    \"fileId\": \"{1}\",    \"fileName\": \"{2}\",    \"fileType\": \"{3}\",    \"fileData\": \"{4}\",    \"fileDataType\": \"{5}\",    \"fileMetaData\": \"{6}\",    \"dateCreated\": \"{7}\",    \"userCreatedBy\": \"{8}\",    \"errorMessageDetails\": {{     \"code\": \"{9}\",      \"description\": \"{10}\",      \"extraData\": \"{11}\",      \"errorsList\": [        {{         \"code\": \"{12}\",          \"description\": \"{13}\",          \"extraData\": \"{14}\",          \"errorsList\": [            {{             \"code\": \"{12}\",              \"description\": \"{13}\",              \"extraData\": \"{14}\",              \"errorType\": \"{15}\"             }}          ],          \"errorType\": \"{16}\"         }}      ],      \"errorType\": \"{17}\"     }}   }}]",id_p,fileId,fileName,fileType,fileData,fileDataType,fileMetaData,dateCreated,userCreatedBy,code,description,extraData,errorsList_code,errorsList_description,errorsList_extraData,errorType,errorsList_errorType,errorMessageDetails_errorType);
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