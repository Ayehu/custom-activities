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
    public class CustomActivity_TY_Create_Secret_Dependency : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "secret-dependencies";
    
    public string password1 = "";
    
    public string active = "";
    
    public string conditionDependencyId = "";
    
    public string conditionMode = "";
    
    public string changerScriptId = "";
    
    public string dependencyScanItemFields__ = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string parentName = "";
    
    public string value = "";
    
    public string scriptName = "";
    
    public string secretDependencyChangerId = "";
    
    public string secretDependencyTemplateId = "";
    
    public string description = "";
    
    public string groupId = "";
    
    public string machineName = "";
    
    public string privilegedAccountSecretId = "";
    
    public string runScript_machineName = "";
    
    public string odbcConnectionArguments__ = "";
    
    public string odbcConnectionArguments_name = "";
    
    public string odbcConnectionArguments_value = "";
    
    public string scriptArguments__ = "";
    
    public string scriptArguments_name = "";
    
    public string type = "";
    
    public string scriptArguments_value = "";
    
    public string scriptId = "";
    
    public string runScript_scriptName = "";
    
    public string serviceName = "";
    
    public string secretId = "";
    
    public string secretName = "";
    
    public string _serviceName = "";
    
    public string settings__ = "";
    
    public string changerSettingValue = "";
    
    public string setting_active = "";
    
    public string canEdit = "";
    
    public string canEditValue = "";
    
    public string childSettings__ = "";
    
    public string childSettings_active = "";
    
    public string childSettings_canEdit = "";
    
    public string childSettings_canEditValue = "";
    
    public string defaultValue = "";
    
    public string displayName = "";
    
    public string childSettings_id = "";
    
    public string isVisibile = "";
    
    public string parentSettingId = "";
    
    public string regexValidation = "";
    
    public string settingName = "";
    
    public string settingSectionId = "";
    
    public string settingType = "";
    
    public string subSettingSectionId = "";
    
    public string childSettings_defaultValue = "";
    
    public string childSettings_displayName = "";
    
    public string childSettings_isVisibile = "";
    
    public string childSettings_parentSettingId = "";
    
    public string childSettings_regexValidation = "";
    
    public string childSettings_settingName = "";
    
    public string childSettings_settingSectionId = "";
    
    public string childSettings_settingType = "";
    
    public string childSettings_subSettingSectionId = "";
    
    public string setting_defaultValue = "";
    
    public string setting_displayName = "";
    
    public string setting_id = "";
    
    public string setting_isVisibile = "";
    
    public string setting_parentSettingId = "";
    
    public string setting_regexValidation = "";
    
    public string setting_settingName = "";
    
    public string setting_settingSectionId = "";
    
    public string setting_settingType = "";
    
    public string setting_subSettingSectionId = "";
    
    public string settingId = "";
    
    public string settings_settingName = "";
    
    public string settingValue = "";
    
    public string sortOrder = "";
    
    public string sshKeySecretId = "";
    
    public string typeId = "";
    
    public string typeName = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "SecretServer/api/v1/secret-dependencies";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"active\": \"{0}\",  \"conditionDependencyId\": \"{1}\",  \"conditionMode\": \"{2}\",  \"dependencyTemplate\": {{   \"changerScriptId\": \"{3}\",    \"dependencyScanItemFields\": [      {{       \"id\": \"{4}\",        \"name\": \"{5}\",        \"parentName\": \"{6}\",        \"value\": \"{7}\"       }}    ],    \"scriptName\": \"{8}\",    \"secretDependencyChangerId\": \"{9}\",    \"secretDependencyTemplateId\": \"{10}\"   }},  \"description\": \"{11}\",  \"groupId\": \"{12}\",  \"machineName\": \"{13}\",  \"privilegedAccountSecretId\": \"{14}\",  \"runScript\": {{   \"machineName\": \"{15}\",    \"odbcConnectionArguments\": [      {{       \"name\": \"{16}\",        \"value\": \"{17}\"       }}    ],    \"scriptArguments\": [      {{       \"name\": \"{18}\",        \"type\": \"{19}\",        \"value\": \"{20}\"       }}    ],    \"scriptId\": \"{21}\",    \"scriptName\": \"{22}\",    \"serviceName\": \"{23}\"   }},  \"secretId\": \"{24}\",  \"secretName\": \"{25}\",  \"serviceName\": \"{26}\",  \"settings\": [    {{     \"changerSettingValue\": \"{27}\",      \"setting\": {{       \"active\": \"{28}\",        \"canEdit\": \"{29}\",        \"canEditValue\": \"{30}\",        \"childSettings\": [          {{           \"active\": \"{31}\",            \"canEdit\": \"{32}\",            \"canEditValue\": \"{33}\",            \"childSettings\": [              {{               \"active\": \"{31}\",                \"canEdit\": \"{32}\",                \"canEditValue\": \"{33}\",                \"defaultValue\": \"{34}\",                \"displayName\": \"{35}\",                \"id\": \"{36}\",                \"isVisibile\": \"{37}\",                \"parentSettingId\": \"{38}\",                \"regexValidation\": \"{39}\",                \"settingName\": \"{40}\",                \"settingSectionId\": \"{41}\",                \"settingType\": \"{42}\",                \"subSettingSectionId\": \"{43}\"               }}            ],            \"defaultValue\": \"{44}\",            \"displayName\": \"{45}\",            \"id\": \"{36}\",            \"isVisibile\": \"{46}\",            \"parentSettingId\": \"{47}\",            \"regexValidation\": \"{48}\",            \"settingName\": \"{49}\",            \"settingSectionId\": \"{50}\",            \"settingType\": \"{51}\",            \"subSettingSectionId\": \"{52}\"           }}        ],        \"defaultValue\": \"{53}\",        \"displayName\": \"{54}\",        \"id\": \"{55}\",        \"isVisibile\": \"{56}\",        \"parentSettingId\": \"{57}\",        \"regexValidation\": \"{58}\",        \"settingName\": \"{59}\",        \"settingSectionId\": \"{60}\",        \"settingType\": \"{61}\",        \"subSettingSectionId\": \"{62}\"       }},      \"settingId\": \"{63}\",      \"settingName\": \"{64}\",      \"settingValue\": \"{65}\"     }}  ],  \"sortOrder\": \"{66}\",  \"sshKeySecretId\": \"{67}\",  \"typeId\": \"{68}\",  \"typeName\": \"{69}\" }}",active,conditionDependencyId,conditionMode,changerScriptId,id_p,name_p,parentName,value,scriptName,secretDependencyChangerId,secretDependencyTemplateId,description,groupId,machineName,privilegedAccountSecretId,runScript_machineName,odbcConnectionArguments_name,odbcConnectionArguments_value,scriptArguments_name,type,scriptArguments_value,scriptId,runScript_scriptName,serviceName,secretId,secretName,_serviceName,changerSettingValue,setting_active,canEdit,canEditValue,childSettings_active,childSettings_canEdit,childSettings_canEditValue,defaultValue,displayName,childSettings_id,isVisibile,parentSettingId,regexValidation,settingName,settingSectionId,settingType,subSettingSectionId,childSettings_defaultValue,childSettings_displayName,childSettings_isVisibile,childSettings_parentSettingId,childSettings_regexValidation,childSettings_settingName,childSettings_settingSectionId,childSettings_settingType,childSettings_subSettingSectionId,setting_defaultValue,setting_displayName,setting_id,setting_isVisibile,setting_parentSettingId,setting_regexValidation,setting_settingName,setting_settingSectionId,setting_settingType,setting_subSettingSectionId,settingId,settings_settingName,settingValue,sortOrder,sshKeySecretId,typeId,typeName);
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> headers {
        get {
            return new Dictionary<string, string>() {{"Authorization","Bearer " + password1}};
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