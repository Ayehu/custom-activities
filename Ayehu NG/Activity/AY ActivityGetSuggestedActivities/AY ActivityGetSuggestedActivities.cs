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
    public class CustomActivity_AY_ActivityGetSuggestedActivities : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "getSuggestedActivities";
    
    public string password1 = "";
    
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
    
    private string uriBuilderPath {
        get {
            return "Server/Api/activity/getSuggestedActivities";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"previousActivity\": {{   \"name\": \"{0}\",    \"displayName\": \"{1}\",    \"category\": \"{2}\",    \"subCategory\": \"{3}\",    \"documantation\": \"{4}\",    \"isFavorite\": \"{5}\",    \"activityList\": [      {{       \"name\": \"{6}\",        \"displayName\": \"{7}\",        \"category\": \"{8}\",        \"subCategory\": \"{9}\",        \"documantation\": \"{10}\",        \"isFavorite\": \"{11}\",        \"activityList\": [          {{           \"name\": \"{6}\",            \"displayName\": \"{7}\",            \"category\": \"{8}\",            \"subCategory\": \"{9}\",            \"documantation\": \"{10}\",            \"isFavorite\": \"{11}\",            \"groupId\": \"{12}\",            \"settings\": \"{13}\",            \"activityLicenseType\": \"{14}\",            \"id\": \"{15}\",            \"labelKey\": \"{16}\",            \"label\": \"{17}\",            \"isAvailable\": \"{18}\",            \"visible\": \"{19}\",            \"icon\": \"{20}\",            \"color\": \"{21}\",            \"description\": \"{22}\",            \"index\": \"{23}\"           }}        ],        \"groupId\": \"{24}\",        \"settings\": \"{25}\",        \"activityLicenseType\": \"{26}\",        \"id\": \"{27}\",        \"labelKey\": \"{28}\",        \"label\": \"{29}\",        \"isAvailable\": \"{30}\",        \"visible\": \"{31}\",        \"icon\": \"{32}\",        \"color\": \"{33}\",        \"description\": \"{34}\",        \"index\": \"{35}\"       }}    ],    \"groupId\": \"{36}\",    \"settings\": \"{37}\",    \"activityLicenseType\": \"{38}\",    \"id\": \"{39}\",    \"labelKey\": \"{40}\",    \"label\": \"{41}\",    \"isAvailable\": \"{42}\",    \"visible\": \"{43}\",    \"icon\": \"{44}\",    \"color\": \"{45}\",    \"description\": \"{46}\",    \"index\": \"{47}\"   }},  \"nextActivity\": {{   \"name\": \"{48}\",    \"displayName\": \"{49}\",    \"category\": \"{50}\",    \"subCategory\": \"{51}\",    \"documantation\": \"{52}\",    \"isFavorite\": \"{53}\",    \"activityList\": [      {{       \"name\": \"{6}\",        \"displayName\": \"{7}\",        \"category\": \"{8}\",        \"subCategory\": \"{9}\",        \"documantation\": \"{10}\",        \"isFavorite\": \"{11}\",        \"activityList\": [          {{           \"name\": \"{6}\",            \"displayName\": \"{7}\",            \"category\": \"{8}\",            \"subCategory\": \"{9}\",            \"documantation\": \"{10}\",            \"isFavorite\": \"{11}\",            \"groupId\": \"{24}\",            \"settings\": \"{25}\",            \"activityLicenseType\": \"{26}\",            \"id\": \"{27}\",            \"labelKey\": \"{28}\",            \"label\": \"{29}\",            \"isAvailable\": \"{30}\",            \"visible\": \"{31}\",            \"icon\": \"{32}\",            \"color\": \"{33}\",            \"description\": \"{34}\",            \"index\": \"{35}\"           }}        ],        \"groupId\": \"{24}\",        \"settings\": \"{25}\",        \"activityLicenseType\": \"{26}\",        \"id\": \"{27}\",        \"labelKey\": \"{28}\",        \"label\": \"{29}\",        \"isAvailable\": \"{30}\",        \"visible\": \"{31}\",        \"icon\": \"{32}\",        \"color\": \"{33}\",        \"description\": \"{34}\",        \"index\": \"{35}\"       }}    ],    \"groupId\": \"{54}\",    \"settings\": \"{55}\",    \"activityLicenseType\": \"{56}\",    \"id\": \"{57}\",    \"labelKey\": \"{58}\",    \"label\": \"{59}\",    \"isAvailable\": \"{60}\",    \"visible\": \"{61}\",    \"icon\": \"{62}\",    \"color\": \"{63}\",    \"description\": \"{64}\",    \"index\": \"{65}\"   }} }}",name_p,displayName,category,subCategory,documantation,isFavorite,activityList_name,activityList_displayName,activityList_category,activityList_subCategory,activityList_documantation,activityList_isFavorite,groupId,settings,activityLicenseType,id_p,labelKey,label,isAvailable,visible,icon,color,description,index,activityList_groupId,activityList_settings,activityList_activityLicenseType,activityList_id,activityList_labelKey,activityList_label,activityList_isAvailable,activityList_visible,activityList_icon,activityList_color,activityList_description,activityList_index,previousActivity_groupId,previousActivity_settings,previousActivity_activityLicenseType,previousActivity_id,previousActivity_labelKey,previousActivity_label,previousActivity_isAvailable,previousActivity_visible,previousActivity_icon,previousActivity_color,previousActivity_description,previousActivity_index,nextActivity_name,nextActivity_displayName,nextActivity_category,nextActivity_subCategory,nextActivity_documantation,nextActivity_isFavorite,nextActivity_groupId,nextActivity_settings,nextActivity_activityLicenseType,nextActivity_id,nextActivity_labelKey,nextActivity_label,nextActivity_isAvailable,nextActivity_visible,nextActivity_icon,nextActivity_color,nextActivity_description,nextActivity_index);
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