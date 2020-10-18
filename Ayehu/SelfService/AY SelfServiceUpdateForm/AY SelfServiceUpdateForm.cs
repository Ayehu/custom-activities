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
    public class AY_SelfServiceUpdateForm : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "updateForm";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string tags = "";
    
    public string _description = "";
    
    public string workflowId = "";
    
    public string enabled = "";
    
    public string deleted = "";
    
    public string structure = "";
    
    public string permissions = "";
    
    public string jsonStructure = "";
    
    public string formControls = "";
    
    public string folderId = "";
    
    public string createUserId = "";
    
    public string lastModfieidUserId = "";
    
    public string createDate = "";
    
    public string modifiedDate = "";
    
    public string enableConfirm = "";
    
    public string parentPath = "";
    
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
_uriBuilderPath = "Server/Api/selfService/updateForm";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"name\": \"{1}\",  \"tags\": {2},  \"description\": \"{3}\",  \"workflowId\": \"{4}\",  \"enabled\": \"{5}\",  \"deleted\": \"{6}\",  \"structure\": \"{7}\",  \"permissions\": {8},  \"jsonStructure\": \"{9}\",  \"formControls\": {10},  \"folderId\": \"{11}\",  \"createUserId\": \"{12}\",  \"lastModfieidUserId\": \"{13}\",  \"createDate\": \"{14}\",  \"modifiedDate\": \"{15}\",  \"enableConfirm\": \"{16}\",  \"parentPath\": \"{17}\" }}",id_p,name_p,tags,_description,workflowId,enabled,deleted,structure,permissions,jsonStructure,formControls,folderId,createUserId,lastModfieidUserId,createDate,modifiedDate,enableConfirm,parentPath);
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
    
    public AY_SelfServiceUpdateForm() {
    }
    
    public AY_SelfServiceUpdateForm(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string name_p, 
                string tags, 
                string _description, 
                string workflowId, 
                string enabled, 
                string deleted, 
                string structure, 
                string permissions, 
                string jsonStructure, 
                string formControls, 
                string folderId, 
                string createUserId, 
                string lastModfieidUserId, 
                string createDate, 
                string modifiedDate, 
                string enableConfirm, 
                string parentPath) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.name_p = name_p;
        this.tags = tags;
        this._description = _description;
        this.workflowId = workflowId;
        this.enabled = enabled;
        this.deleted = deleted;
        this.structure = structure;
        this.permissions = permissions;
        this.jsonStructure = jsonStructure;
        this.formControls = formControls;
        this.folderId = folderId;
        this.createUserId = createUserId;
        this.lastModfieidUserId = lastModfieidUserId;
        this.createDate = createDate;
        this.modifiedDate = modifiedDate;
        this.enableConfirm = enableConfirm;
        this.parentPath = parentPath;
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