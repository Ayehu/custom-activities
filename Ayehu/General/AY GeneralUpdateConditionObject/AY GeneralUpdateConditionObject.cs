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
    public class AY_GeneralUpdateConditionObject : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "UpdateConditionObject";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string messageObjectType = "";
    
    public string value = "";
    
    public string description_p = "";
    
    public string enabled = "";
    
    public string monitored = "";
    
    public string monitort = "";
    
    public string corlt = "";
    
    public string mType = "";
    
    public string Ctype = "";
    
    public string rObject = "";
    
    public string objecttime = "";
    
    public string report = "";
    
    public string objectCount = "";
    
    public string oLevel = "";
    
    public string name_p = "";
    
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
_uriBuilderPath = "Server/Api/General/UpdateConditionObject";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"messageObjectType\": \"{1}\",  \"value\": \"{2}\",  \"description\": \"{3}\",  \"enabled\": \"{4}\",  \"monitored\": \"{5}\",  \"monitort\": \"{6}\",  \"corlt\": \"{7}\",  \"mType\": \"{8}\",  \"Ctype\": \"{9}\",  \"rObject\": \"{10}\",  \"objecttime\": \"{11}\",  \"report\": \"{12}\",  \"objectCount\": \"{13}\",  \"oLevel\": \"{14}\",  \"name\": \"{15}\" }}",id_p,messageObjectType,value,description_p,enabled,monitored,monitort,corlt,mType,Ctype,rObject,objecttime,report,objectCount,oLevel,name_p);
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
    
    public AY_GeneralUpdateConditionObject() {
    }
    
    public AY_GeneralUpdateConditionObject(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string messageObjectType, 
                string value, 
                string description_p, 
                string enabled, 
                string monitored, 
                string monitort, 
                string corlt, 
                string mType, 
                string Ctype, 
                string rObject, 
                string objecttime, 
                string report, 
                string objectCount, 
                string oLevel, 
                string name_p) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.messageObjectType = messageObjectType;
        this.value = value;
        this.description_p = description_p;
        this.enabled = enabled;
        this.monitored = monitored;
        this.monitort = monitort;
        this.corlt = corlt;
        this.mType = mType;
        this.Ctype = Ctype;
        this.rObject = rObject;
        this.objecttime = objecttime;
        this.report = report;
        this.objectCount = objectCount;
        this.oLevel = oLevel;
        this.name_p = name_p;
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