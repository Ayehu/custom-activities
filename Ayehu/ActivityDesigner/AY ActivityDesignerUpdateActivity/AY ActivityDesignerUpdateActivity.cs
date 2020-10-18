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
    public class AY_ActivityDesignerUpdateActivity : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "updateActivity";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string label_p = "";
    
    public string groupId = "";
    
    public string description_p = "";
    
    public string assemblyName = "";
    
    public string settings_p = "";
    
    public string isVisible = "";
    
    public string language = "";
    
    public string color_p = "";
    
    public string icon_p = "";
    
    public string helpHtml_p = "";
    
    public string codeBehind = "";
    
    public string referencedAssembliesList = "";
    
    public string version = "";
    
    public string activityGroupModuleType = "";
    
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
_uriBuilderPath = "Server/Api/ActivityDesigner/updateActivity";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"name\": \"{1}\",  \"label\": \"{2}\",  \"groupId\": \"{3}\",  \"description\": \"{4}\",  \"assemblyName\": \"{5}\",  \"settings\": \"{6}\",  \"isVisible\": \"{7}\",  \"language\": \"{8}\",  \"color\": \"{9}\",  \"icon\": \"{10}\",  \"helpHtml\": \"{11}\",  \"codeBehind\": \"{12}\",  \"referencedAssembliesList\": {13},  \"version\": \"{14}\",  \"activityGroupModuleType\": \"{15}\" }}",id_p,name_p,label_p,groupId,description_p,assemblyName,settings_p,isVisible,language,color_p,icon_p,helpHtml_p,codeBehind,referencedAssembliesList,version,activityGroupModuleType);
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
    
    public AY_ActivityDesignerUpdateActivity() {
    }
    
    public AY_ActivityDesignerUpdateActivity(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string name_p, 
                string label_p, 
                string groupId, 
                string description_p, 
                string assemblyName, 
                string settings_p, 
                string isVisible, 
                string language, 
                string color_p, 
                string icon_p, 
                string helpHtml_p, 
                string codeBehind, 
                string referencedAssembliesList, 
                string version, 
                string activityGroupModuleType) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.name_p = name_p;
        this.label_p = label_p;
        this.groupId = groupId;
        this.description_p = description_p;
        this.assemblyName = assemblyName;
        this.settings_p = settings_p;
        this.isVisible = isVisible;
        this.language = language;
        this.color_p = color_p;
        this.icon_p = icon_p;
        this.helpHtml_p = helpHtml_p;
        this.codeBehind = codeBehind;
        this.referencedAssembliesList = referencedAssembliesList;
        this.version = version;
        this.activityGroupModuleType = activityGroupModuleType;
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