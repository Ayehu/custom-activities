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
    public class AY_IncidentConfigurationUpdateIncidentMapping : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "updateIncidentMapping";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string description_p = "";
    
    public string isAnyTrigger = "";
    
    public string downValue = "";
    
    public string warningValue = "";
    
    public string upValue = "";
    
    public string createIncident = "";
    
    public string code = "";
    
    public string order = "";
    
    public string testSubject = "";
    
    public string testMessage = "";
    
    public string isValid = "";
    
    public string language = "";
    
    public string enabled = "";
    
    public string conditionId = "";
    
    public string languageId = "";
    
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
_uriBuilderPath = "Server/API/IncidentConfiguration/updateIncidentMapping";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"name\": \"{1}\",  \"description\": \"{2}\",  \"isAnyTrigger\": \"{3}\",  \"downValue\": \"{4}\",  \"warningValue\": \"{5}\",  \"upValue\": \"{6}\",  \"createIncident\": \"{7}\",  \"code\": \"{8}\",  \"order\": \"{9}\",  \"testSubject\": \"{10}\",  \"testMessage\": \"{11}\",  \"isValid\": \"{12}\",  \"language\": \"{13}\",  \"enabled\": \"{14}\",  \"conditionId\": \"{15}\",  \"languageId\": \"{16}\" }}",id_p,name_p,description_p,isAnyTrigger,downValue,warningValue,upValue,createIncident,code,order,testSubject,testMessage,isValid,language,enabled,conditionId,languageId);
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
    
    public AY_IncidentConfigurationUpdateIncidentMapping() {
    }
    
    public AY_IncidentConfigurationUpdateIncidentMapping(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string name_p, 
                string description_p, 
                string isAnyTrigger, 
                string downValue, 
                string warningValue, 
                string upValue, 
                string createIncident, 
                string code, 
                string order, 
                string testSubject, 
                string testMessage, 
                string isValid, 
                string language, 
                string enabled, 
                string conditionId, 
                string languageId) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.name_p = name_p;
        this.description_p = description_p;
        this.isAnyTrigger = isAnyTrigger;
        this.downValue = downValue;
        this.warningValue = warningValue;
        this.upValue = upValue;
        this.createIncident = createIncident;
        this.code = code;
        this.order = order;
        this.testSubject = testSubject;
        this.testMessage = testMessage;
        this.isValid = isValid;
        this.language = language;
        this.enabled = enabled;
        this.conditionId = conditionId;
        this.languageId = languageId;
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