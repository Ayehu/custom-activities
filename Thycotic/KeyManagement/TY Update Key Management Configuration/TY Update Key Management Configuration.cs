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
    public class TY_Update_Key_Management_Configuration : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "key-management";
    
    public string password1 = "";
    
    public string awsKmsAccessKeyId = "";
    
    public string awsKmsKeyArn = "";
    
    public string awsKmsKeyId = "";
    
    public string awsKmsSecretAccessKey = "";
    
    public string azureKeyVaultBaseUrl = "";
    
    public string azureKeyVaultKeyName = "";
    
    public string azureKeyVaultKeyVersion = "";
    
    public string azureKeyVaultPrincipalId = "";
    
    public string azureKeyVaultPrincipalSecret = "";
    
    public string keyManagementTypeId = "";
    
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
_uriBuilderPath = "SecretServer/api/v1/key-management";
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
_postData = string.Format("{{ \"awsKmsAccessKeyId\": \"{0}\",  \"awsKmsKeyArn\": \"{1}\",  \"awsKmsKeyId\": \"{2}\",  \"awsKmsSecretAccessKey\": \"{3}\",  \"azureKeyVaultBaseUrl\": \"{4}\",  \"azureKeyVaultKeyName\": \"{5}\",  \"azureKeyVaultKeyVersion\": \"{6}\",  \"azureKeyVaultPrincipalId\": \"{7}\",  \"azureKeyVaultPrincipalSecret\": \"{8}\",  \"keyManagementTypeId\": \"{9}\" }}",awsKmsAccessKeyId,awsKmsKeyArn,awsKmsKeyId,awsKmsSecretAccessKey,azureKeyVaultBaseUrl,azureKeyVaultKeyName,azureKeyVaultKeyVersion,azureKeyVaultPrincipalId,azureKeyVaultPrincipalSecret,keyManagementTypeId);
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
    
    public TY_Update_Key_Management_Configuration() {
    }
    
    public TY_Update_Key_Management_Configuration(string endPoint, string Jsonkeypath, string password1, string awsKmsAccessKeyId, string awsKmsKeyArn, string awsKmsKeyId, string awsKmsSecretAccessKey, string azureKeyVaultBaseUrl, string azureKeyVaultKeyName, string azureKeyVaultKeyVersion, string azureKeyVaultPrincipalId, string azureKeyVaultPrincipalSecret, string keyManagementTypeId) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.awsKmsAccessKeyId = awsKmsAccessKeyId;
        this.awsKmsKeyArn = awsKmsKeyArn;
        this.awsKmsKeyId = awsKmsKeyId;
        this.awsKmsSecretAccessKey = awsKmsSecretAccessKey;
        this.azureKeyVaultBaseUrl = azureKeyVaultBaseUrl;
        this.azureKeyVaultKeyName = azureKeyVaultKeyName;
        this.azureKeyVaultKeyVersion = azureKeyVaultKeyVersion;
        this.azureKeyVaultPrincipalId = azureKeyVaultPrincipalId;
        this.azureKeyVaultPrincipalSecret = azureKeyVaultPrincipalSecret;
        this.keyManagementTypeId = keyManagementTypeId;
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