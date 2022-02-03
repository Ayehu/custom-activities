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
    public class TY_Update_a_Workflow_Template : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string dirty = "";
    
    public string value = "";
    
    public string configurationJson_dirty = "";
    
    public string configurationJson_value = "";
    
    public string description_dirty = "";
    
    public string description_value = "";
    
    public string expirationMinutes_dirty = "";
    
    public string expirationMinutes_value = "";
    
    public string isCopy_dirty = "";
    
    public string isCopy_value = "";
    
    public string name_dirty = "";
    
    public string name_value = "";
    
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
_uriBuilderPath = string.Format("SecretServer/api/v1/workflows/templates/{0}",id_p);
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
_postData = string.Format("{{ \"active\": {{   \"dirty\": \"{0}\",    \"value\": \"{1}\"   }},  \"configurationJson\": {{   \"dirty\": \"{2}\",    \"value\": \"{3}\"   }},  \"description\": {{   \"dirty\": \"{4}\",    \"value\": \"{5}\"   }},  \"expirationMinutes\": {{   \"dirty\": \"{6}\",    \"value\": \"{7}\"   }},  \"isCopy\": {{   \"dirty\": \"{8}\",    \"value\": \"{9}\"   }},  \"name\": {{   \"dirty\": \"{10}\",    \"value\": \"{11}\"   }} }}",dirty,value,configurationJson_dirty,configurationJson_value,description_dirty,description_value,expirationMinutes_dirty,expirationMinutes_value,isCopy_dirty,isCopy_value,name_dirty,name_value);
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
    
    public TY_Update_a_Workflow_Template() {
    }
    
    public TY_Update_a_Workflow_Template(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string dirty, 
                string value, 
                string configurationJson_dirty, 
                string configurationJson_value, 
                string description_dirty, 
                string description_value, 
                string expirationMinutes_dirty, 
                string expirationMinutes_value, 
                string isCopy_dirty, 
                string isCopy_value, 
                string name_dirty, 
                string name_value) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.dirty = dirty;
        this.value = value;
        this.configurationJson_dirty = configurationJson_dirty;
        this.configurationJson_value = configurationJson_value;
        this.description_dirty = description_dirty;
        this.description_value = description_value;
        this.expirationMinutes_dirty = expirationMinutes_dirty;
        this.expirationMinutes_value = expirationMinutes_value;
        this.isCopy_dirty = isCopy_dirty;
        this.isCopy_value = isCopy_value;
        this.name_dirty = name_dirty;
        this.name_value = name_value;
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