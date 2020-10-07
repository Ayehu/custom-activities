using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.Sdk.ActivityCreation
{
    public class CustomActivity_AY_ActivityAddActivityToFavorite : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "addActivityToFavorite";
    
    public string password1 = "";
    
    public string activityToAdd = "";
    
    public string name_p = "";
    
    public string displayName = "";
    
    public string category = "";
    
    public string subCategory = "";
    
    public string documantation = "";
    
    public string isFavorite = "";
    
    public string activityList__ = "";
    
    public string activityList_name = "";
    
    public string activityList_displayName = "";
    
    public string activityList_category = "";
    
    public string activityList_subCategory = "";
    
    public string activityList_documantation = "";
    
    public string activityList_isFavorite = "";
    
    public string groupId = "";
    
    public string settings = "";
    
    public string activityLicenseType = "";
    
    public string id_p = "";
    
    public string labelKey = "";
    
    public string label = "";
    
    public string isAvailable = "";
    
    public string visible = "";
    
    public string icon = "";
    
    public string color = "";
    
    public string description = "";
    
    public string index = "";
    
    public string activityList_groupId = "";
    
    public string activityList_settings = "";
    
    public string activityList_activityLicenseType = "";
    
    public string activityList_id = "";
    
    public string activityList_labelKey = "";
    
    public string activityList_label = "";
    
    public string activityList_isAvailable = "";
    
    public string activityList_visible = "";
    
    public string activityList_icon = "";
    
    public string activityList_color = "";
    
    public string activityList_description = "";
    
    public string activityList_index = "";
    
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
    
    private string uriBuilderPath {
        get {
            return "Server/Api/activity/addActivityToFavorite";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"name\": \"{0}\",  \"displayName\": \"{1}\",  \"category\": \"{2}\",  \"subCategory\": \"{3}\",  \"documantation\": \"{4}\",  \"isFavorite\": \"{5}\",  \"activityList\": [    {{     \"name\": \"{6}\",      \"displayName\": \"{7}\",      \"category\": \"{8}\",      \"subCategory\": \"{9}\",      \"documantation\": \"{10}\",      \"isFavorite\": \"{11}\",      \"activityList\": [        {{         \"name\": \"{6}\",          \"displayName\": \"{7}\",          \"category\": \"{8}\",          \"subCategory\": \"{9}\",          \"documantation\": \"{10}\",          \"isFavorite\": \"{11}\",          \"groupId\": \"{12}\",          \"settings\": \"{13}\",          \"activityLicenseType\": \"{14}\",          \"id\": \"{15}\",          \"labelKey\": \"{16}\",          \"label\": \"{17}\",          \"isAvailable\": \"{18}\",          \"visible\": \"{19}\",          \"icon\": \"{20}\",          \"color\": \"{21}\",          \"description\": \"{22}\",          \"index\": \"{23}\"         }}      ],      \"groupId\": \"{24}\",      \"settings\": \"{25}\",      \"activityLicenseType\": \"{26}\",      \"id\": \"{27}\",      \"labelKey\": \"{28}\",      \"label\": \"{29}\",      \"isAvailable\": \"{30}\",      \"visible\": \"{31}\",      \"icon\": \"{32}\",      \"color\": \"{33}\",      \"description\": \"{34}\",      \"index\": \"{35}\"     }}  ],  \"groupId\": \"{36}\",  \"settings\": \"{37}\",  \"activityLicenseType\": \"{38}\",  \"id\": \"{39}\",  \"labelKey\": \"{40}\",  \"label\": \"{41}\",  \"isAvailable\": \"{42}\",  \"visible\": \"{43}\",  \"icon\": \"{44}\",  \"color\": \"{45}\",  \"description\": \"{46}\",  \"index\": \"{47}\" }}",name_p,displayName,category,subCategory,documantation,isFavorite,activityList_name,activityList_displayName,activityList_category,activityList_subCategory,activityList_documantation,activityList_isFavorite,groupId,settings,activityLicenseType,id_p,labelKey,label,isAvailable,visible,icon,color,description,index,activityList_groupId,activityList_settings,activityList_activityLicenseType,activityList_id,activityList_labelKey,activityList_label,activityList_isAvailable,activityList_visible,activityList_icon,activityList_color,activityList_description,activityList_index,_groupId,_settings,_activityLicenseType,_id,_labelKey,_label,_isAvailable,_visible,_icon,_color,_description,_index);
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> headers {
        get {
            return new Dictionary<string, string>() {{"authorization","Bearer " + password1}};
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> queryStringArray {
        get {
            return new Dictionary<string, string>() {};
        }
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
                    myHttpRequestMessage.Content = new StringContent(postData, Encoding.UTF8, "application/json");


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