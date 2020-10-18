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
    public class AY_ActivityGetSuggestedActivities : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "getSuggestedActivities";
    
    public string password1 = "";
    
    public string name_p = "";
    
    public string displayName_p = "";
    
    public string category_p = "";
    
    public string subCategory_p = "";
    
    public string documantation = "";
    
    public string isFavorite_p = "";
    
    public string activityList_p = "";
    
    public string previousActivity_groupId = "";
    
    public string previousActivity_settings = "";
    
    public string previousActivity_activityLicenseType = "";
    
    public string previousActivity_id = "";
    
    public string previousActivity_labelKey = "";
    
    public string previousActivity_label = "";
    
    public string previousActivity_isAvailable = "";
    
    public string previousActivity_visible = "";
    
    public string previousActivity_icon = "";
    
    public string previousActivity_color = "";
    
    public string previousActivity_description = "";
    
    public string previousActivity_index = "";
    
    public string nextActivity_name = "";
    
    public string nextActivity_displayName = "";
    
    public string nextActivity_category = "";
    
    public string nextActivity_subCategory = "";
    
    public string nextActivity_documantation = "";
    
    public string nextActivity_isFavorite = "";
    
    public string nextActivity_groupId = "";
    
    public string nextActivity_settings = "";
    
    public string nextActivity_activityLicenseType = "";
    
    public string nextActivity_id = "";
    
    public string nextActivity_labelKey = "";
    
    public string nextActivity_label = "";
    
    public string nextActivity_isAvailable = "";
    
    public string nextActivity_visible = "";
    
    public string nextActivity_icon = "";
    
    public string nextActivity_color = "";
    
    public string nextActivity_description = "";
    
    public string nextActivity_index = "";
    
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
_uriBuilderPath = "Server/Api/activity/getSuggestedActivities";
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
_postData = string.Format("{{ \"previousActivity\": {{   \"name\": \"{0}\",    \"displayName\": \"{1}\",    \"category\": \"{2}\",    \"subCategory\": \"{3}\",    \"documantation\": \"{4}\",    \"isFavorite\": \"{5}\",    \"activityList\": {6},    \"groupId\": \"{7}\",    \"settings\": \"{8}\",    \"activityLicenseType\": \"{9}\",    \"id\": \"{10}\",    \"labelKey\": \"{11}\",    \"label\": \"{12}\",    \"isAvailable\": \"{13}\",    \"visible\": \"{14}\",    \"icon\": \"{15}\",    \"color\": \"{16}\",    \"description\": \"{17}\",    \"index\": \"{18}\"   }},  \"nextActivity\": {{   \"name\": \"{19}\",    \"displayName\": \"{20}\",    \"category\": \"{21}\",    \"subCategory\": \"{22}\",    \"documantation\": \"{23}\",    \"isFavorite\": \"{24}\",    \"activityList\": {6},    \"groupId\": \"{25}\",    \"settings\": \"{26}\",    \"activityLicenseType\": \"{27}\",    \"id\": \"{28}\",    \"labelKey\": \"{29}\",    \"label\": \"{30}\",    \"isAvailable\": \"{31}\",    \"visible\": \"{32}\",    \"icon\": \"{33}\",    \"color\": \"{34}\",    \"description\": \"{35}\",    \"index\": \"{36}\"   }} }}",name_p,displayName_p,category_p,subCategory_p,documantation,isFavorite_p,activityList_p,previousActivity_groupId,previousActivity_settings,previousActivity_activityLicenseType,previousActivity_id,previousActivity_labelKey,previousActivity_label,previousActivity_isAvailable,previousActivity_visible,previousActivity_icon,previousActivity_color,previousActivity_description,previousActivity_index,nextActivity_name,nextActivity_displayName,nextActivity_category,nextActivity_subCategory,nextActivity_documantation,nextActivity_isFavorite,nextActivity_groupId,nextActivity_settings,nextActivity_activityLicenseType,nextActivity_id,nextActivity_labelKey,nextActivity_label,nextActivity_isAvailable,nextActivity_visible,nextActivity_icon,nextActivity_color,nextActivity_description,nextActivity_index);
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
    
    public AY_ActivityGetSuggestedActivities() {
    }
    
    public AY_ActivityGetSuggestedActivities(
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
                string previousActivity_groupId, 
                string previousActivity_settings, 
                string previousActivity_activityLicenseType, 
                string previousActivity_id, 
                string previousActivity_labelKey, 
                string previousActivity_label, 
                string previousActivity_isAvailable, 
                string previousActivity_visible, 
                string previousActivity_icon, 
                string previousActivity_color, 
                string previousActivity_description, 
                string previousActivity_index, 
                string nextActivity_name, 
                string nextActivity_displayName, 
                string nextActivity_category, 
                string nextActivity_subCategory, 
                string nextActivity_documantation, 
                string nextActivity_isFavorite, 
                string nextActivity_groupId, 
                string nextActivity_settings, 
                string nextActivity_activityLicenseType, 
                string nextActivity_id, 
                string nextActivity_labelKey, 
                string nextActivity_label, 
                string nextActivity_isAvailable, 
                string nextActivity_visible, 
                string nextActivity_icon, 
                string nextActivity_color, 
                string nextActivity_description, 
                string nextActivity_index) {
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
        this.previousActivity_groupId = previousActivity_groupId;
        this.previousActivity_settings = previousActivity_settings;
        this.previousActivity_activityLicenseType = previousActivity_activityLicenseType;
        this.previousActivity_id = previousActivity_id;
        this.previousActivity_labelKey = previousActivity_labelKey;
        this.previousActivity_label = previousActivity_label;
        this.previousActivity_isAvailable = previousActivity_isAvailable;
        this.previousActivity_visible = previousActivity_visible;
        this.previousActivity_icon = previousActivity_icon;
        this.previousActivity_color = previousActivity_color;
        this.previousActivity_description = previousActivity_description;
        this.previousActivity_index = previousActivity_index;
        this.nextActivity_name = nextActivity_name;
        this.nextActivity_displayName = nextActivity_displayName;
        this.nextActivity_category = nextActivity_category;
        this.nextActivity_subCategory = nextActivity_subCategory;
        this.nextActivity_documantation = nextActivity_documantation;
        this.nextActivity_isFavorite = nextActivity_isFavorite;
        this.nextActivity_groupId = nextActivity_groupId;
        this.nextActivity_settings = nextActivity_settings;
        this.nextActivity_activityLicenseType = nextActivity_activityLicenseType;
        this.nextActivity_id = nextActivity_id;
        this.nextActivity_labelKey = nextActivity_labelKey;
        this.nextActivity_label = nextActivity_label;
        this.nextActivity_isAvailable = nextActivity_isAvailable;
        this.nextActivity_visible = nextActivity_visible;
        this.nextActivity_icon = nextActivity_icon;
        this.nextActivity_color = nextActivity_color;
        this.nextActivity_description = nextActivity_description;
        this.nextActivity_index = nextActivity_index;
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