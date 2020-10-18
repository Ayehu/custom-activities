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
    public class AY_WorkflowAddWorkflowFolder : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "addWorkflowFolder";
    
    public string password1 = "";
    
    public string workflowsAmount = "";
    
    public string foldersAmount = "";
    
    public string parentId = "";
    
    public string workflowFolders = "";
    
    public string workflowList = "";
    
    public string _id = "";
    
    public string _labelKey = "";
    
    public string _label = "";
    
    public string _isAvailable = "";
    
    public string _visible = "";
    
    public string _icon = "";
    
    public string _color = "";
    
    public string _description = "";
    
    public string _index = "";
    
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
_uriBuilderPath = "Server/Api/workflow/addWorkflowFolder";
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
_postData = string.Format("{{ \"workflowsAmount\": \"{0}\",  \"foldersAmount\": \"{1}\",  \"parentId\": \"{2}\",  \"workflowFolders\": {3},  \"workflowList\": {4},  \"id\": \"{5}\",  \"labelKey\": \"{6}\",  \"label\": \"{7}\",  \"isAvailable\": \"{8}\",  \"visible\": \"{9}\",  \"icon\": \"{10}\",  \"color\": \"{11}\",  \"description\": \"{12}\",  \"index\": \"{13}\" }}",workflowsAmount,foldersAmount,parentId,workflowFolders,workflowList,_id,_labelKey,_label,_isAvailable,_visible,_icon,_color,_description,_index);
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
    
    public AY_WorkflowAddWorkflowFolder() {
    }
    
    public AY_WorkflowAddWorkflowFolder(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string workflowsAmount, 
                string foldersAmount, 
                string parentId, 
                string workflowFolders, 
                string workflowList, 
                string _id, 
                string _labelKey, 
                string _label, 
                string _isAvailable, 
                string _visible, 
                string _icon, 
                string _color, 
                string _description, 
                string _index) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.workflowsAmount = workflowsAmount;
        this.foldersAmount = foldersAmount;
        this.parentId = parentId;
        this.workflowFolders = workflowFolders;
        this.workflowList = workflowList;
        this._id = _id;
        this._labelKey = _labelKey;
        this._label = _label;
        this._isAvailable = _isAvailable;
        this._visible = _visible;
        this._icon = _icon;
        this._color = _color;
        this._description = _description;
        this._index = _index;
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