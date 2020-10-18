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
    public class AY_ActivityAddActivityToFavorite : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "addActivityToFavorite";
    
    public string password1 = "";
    
    public string name_p = "";
    
    public string displayName_p = "";
    
    public string category_p = "";
    
    public string subCategory_p = "";
    
    public string documantation = "";
    
    public string isFavorite_p = "";
    
    public string activityList_p = "";
    
    public string _groupId = "";
    
    public string _settings = "";
    
    public string _activityLicenseType = "";
    
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
_uriBuilderPath = "Server/Api/activity/addActivityToFavorite";
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
_postData = string.Format("{{ \"name\": \"{0}\",  \"displayName\": \"{1}\",  \"category\": \"{2}\",  \"subCategory\": \"{3}\",  \"documantation\": \"{4}\",  \"isFavorite\": \"{5}\",  \"activityList\": {6},  \"groupId\": \"{7}\",  \"settings\": \"{8}\",  \"activityLicenseType\": \"{9}\",  \"id\": \"{10}\",  \"labelKey\": \"{11}\",  \"label\": \"{12}\",  \"isAvailable\": \"{13}\",  \"visible\": \"{14}\",  \"icon\": \"{15}\",  \"color\": \"{16}\",  \"description\": \"{17}\",  \"index\": \"{18}\" }}",name_p,displayName_p,category_p,subCategory_p,documantation,isFavorite_p,activityList_p,_groupId,_settings,_activityLicenseType,_id,_labelKey,_label,_isAvailable,_visible,_icon,_color,_description,_index);
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
    
    public AY_ActivityAddActivityToFavorite() {
    }
    
    public AY_ActivityAddActivityToFavorite(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string name_p, 
                string displayName_p, 
                string category_p, 
                string subCategory_p, 
                string documantation, 
                string isFavorite_p, 
                string activityList_p, 
                string _groupId, 
                string _settings, 
                string _activityLicenseType, 
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
        this.name_p = name_p;
        this.displayName_p = displayName_p;
        this.category_p = category_p;
        this.subCategory_p = subCategory_p;
        this.documantation = documantation;
        this.isFavorite_p = isFavorite_p;
        this.activityList_p = activityList_p;
        this._groupId = _groupId;
        this._settings = _settings;
        this._activityLicenseType = _activityLicenseType;
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