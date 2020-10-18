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
    public class AY_FrameworkUploadMultipleFile : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "uploadMultipleFile";
    
    public string password1 = "";
    
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
    
    public string description_p = "";
    
    public string extraData = "";
    
    public string errorsList = "";
    
    public string errorMessageDetails_errorType = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = "Server/Api/Framework/uploadMultipleFile";
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
_postData = string.Format("[  {{   \"id\": \"{0}\",    \"fileId\": \"{1}\",    \"fileName\": \"{2}\",    \"fileType\": \"{3}\",    \"fileData\": \"{4}\",    \"fileDataType\": \"{5}\",    \"fileMetaData\": \"{6}\",    \"dateCreated\": \"{7}\",    \"userCreatedBy\": \"{8}\",    \"errorMessageDetails\": {{     \"code\": \"{9}\",      \"description\": \"{10}\",      \"extraData\": \"{11}\",      \"errorsList\": {12},      \"errorType\": \"{13}\"     }}   }}]",id_p,fileId,fileName,fileType,fileData,fileDataType,fileMetaData,dateCreated,userCreatedBy,code,description_p,extraData,errorsList,errorMessageDetails_errorType);
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
    
    public AY_FrameworkUploadMultipleFile() {
    }
    
    public AY_FrameworkUploadMultipleFile(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string fileId, 
                string fileName, 
                string fileType, 
                string fileData, 
                string fileDataType, 
                string fileMetaData, 
                string dateCreated, 
                string userCreatedBy, 
                string code, 
                string description_p, 
                string extraData, 
                string errorsList, 
                string errorMessageDetails_errorType) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.fileId = fileId;
        this.fileName = fileName;
        this.fileType = fileType;
        this.fileData = fileData;
        this.fileDataType = fileDataType;
        this.fileMetaData = fileMetaData;
        this.dateCreated = dateCreated;
        this.userCreatedBy = userCreatedBy;
        this.code = code;
        this.description_p = description_p;
        this.extraData = extraData;
        this.errorsList = errorsList;
        this.errorMessageDetails_errorType = errorMessageDetails_errorType;
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