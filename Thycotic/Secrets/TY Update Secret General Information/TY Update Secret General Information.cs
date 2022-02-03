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
    public class TY_Update_Secret_General_Information : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "general";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string dirty = "";
    
    public string value = "";
    
    public string enableInheritSecretPolicy_dirty = "";
    
    public string enableInheritSecretPolicy_value = "";
    
    public string folder_dirty = "";
    
    public string folder_value = "";
    
    public string generateSshKeys = "";
    
    public string heartbeatEnabled_dirty = "";
    
    public string heartbeatEnabled_value = "";
    
    public string isOutOfSync_dirty = "";
    
    public string isOutOfSync_value = "";
    
    public string name_dirty = "";
    
    public string name_value = "";
    
    public string secretFields = "";
    
    public string secretPolicy_dirty = "";
    
    public string secretPolicy_value = "";
    
    public string site_dirty = "";
    
    public string site_value = "";
    
    public string template_dirty = "";
    
    public string template_value = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "PATCH";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = string.Format("SecretServer/api/v1/secrets/{0}/general",id_p);
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
_postData = string.Format("{{ \"data\": {{   \"active\": {{     \"dirty\": \"{0}\",      \"value\": \"{1}\"     }},    \"enableInheritSecretPolicy\": {{     \"dirty\": \"{2}\",      \"value\": \"{3}\"     }},    \"folder\": {{     \"dirty\": \"{4}\",      \"value\": \"{5}\"     }},    \"generateSshKeys\": \"{6}\",    \"heartbeatEnabled\": {{     \"dirty\": \"{7}\",      \"value\": \"{8}\"     }},    \"isOutOfSync\": {{     \"dirty\": \"{9}\",      \"value\": \"{10}\"     }},    \"name\": {{     \"dirty\": \"{11}\",      \"value\": \"{12}\"     }},    \"secretFields\": {13},    \"secretPolicy\": {{     \"dirty\": \"{14}\",      \"value\": \"{15}\"     }},    \"site\": {{     \"dirty\": \"{16}\",      \"value\": \"{17}\"     }},    \"template\": {{     \"dirty\": \"{18}\",      \"value\": \"{19}\"     }}   }} }}",dirty,value,enableInheritSecretPolicy_dirty,enableInheritSecretPolicy_value,folder_dirty,folder_value,generateSshKeys,heartbeatEnabled_dirty,heartbeatEnabled_value,isOutOfSync_dirty,isOutOfSync_value,name_dirty,name_value,secretFields,secretPolicy_dirty,secretPolicy_value,site_dirty,site_value,template_dirty,template_value);
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
    
    public TY_Update_Secret_General_Information() {
    }
    
    public TY_Update_Secret_General_Information(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string dirty, 
                string value, 
                string enableInheritSecretPolicy_dirty, 
                string enableInheritSecretPolicy_value, 
                string folder_dirty, 
                string folder_value, 
                string generateSshKeys, 
                string heartbeatEnabled_dirty, 
                string heartbeatEnabled_value, 
                string isOutOfSync_dirty, 
                string isOutOfSync_value, 
                string name_dirty, 
                string name_value, 
                string secretFields, 
                string secretPolicy_dirty, 
                string secretPolicy_value, 
                string site_dirty, 
                string site_value, 
                string template_dirty, 
                string template_value) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.dirty = dirty;
        this.value = value;
        this.enableInheritSecretPolicy_dirty = enableInheritSecretPolicy_dirty;
        this.enableInheritSecretPolicy_value = enableInheritSecretPolicy_value;
        this.folder_dirty = folder_dirty;
        this.folder_value = folder_value;
        this.generateSshKeys = generateSshKeys;
        this.heartbeatEnabled_dirty = heartbeatEnabled_dirty;
        this.heartbeatEnabled_value = heartbeatEnabled_value;
        this.isOutOfSync_dirty = isOutOfSync_dirty;
        this.isOutOfSync_value = isOutOfSync_value;
        this.name_dirty = name_dirty;
        this.name_value = name_value;
        this.secretFields = secretFields;
        this.secretPolicy_dirty = secretPolicy_dirty;
        this.secretPolicy_value = secretPolicy_value;
        this.site_dirty = site_dirty;
        this.site_value = site_value;
        this.template_dirty = template_dirty;
        this.template_value = template_value;
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