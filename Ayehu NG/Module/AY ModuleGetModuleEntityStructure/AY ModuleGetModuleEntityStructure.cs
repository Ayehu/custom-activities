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
    public class CustomActivity_AY_ModuleGetModuleEntityStructure : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "getModuleEntityStructure";
    
    public string password1 = "";
    
    public string moduleId = "";
    
    public string moduleType = "";
    
    public string formId = "";
    
    public string entityType = "";
    
    public string entityName = "";
    
    public string entityAlias = "";
    
    public string fields__ = "";
    
    public string entriesField__ = "";
    
    public string idField = "";
    
    public string labelField = "";
    
    public string valueField = "";
    
    public string nameField = "";
    
    public string fields_nameField = "";
    
    public string fields_idField = "";
    
    public string typeField = "";
    
    public string isCreateField = "";
    
    public string isUpdateField = "";
    
    public string filterField = "";
    
    public string mandatoryField = "";
    
    public string isKeyField = "";
    
    public string lengthField = "";
    
    public string isSystemField = "";
    
    public string isHiddenField = "";
    
    public string entityIDField = "";
    
    public string lastUpdateField = "";
    
    public string operationsField = "";
    
    public string isFilterableField = "";
    
    public string operators__ = "";
    
    public string entriesField_idField = "";
    
    public string entriesField_labelField = "";
    
    public string entriesField_valueField = "";
    
    public string entriesField_nameField = "";
    
    public string operators_typeField = "";
    
    public string isFieldsDiscovered = "";
    
    public string confType = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "Server/Api/Module/getModuleEntityStructure";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"moduleId\": \"{0}\",  \"moduleType\": \"{1}\",  \"formId\": \"{2}\",  \"entityType\": \"{3}\",  \"entityName\": \"{4}\",  \"entityAlias\": \"{5}\",  \"fields\": [    {{     \"entriesField\": [        {{         \"idField\": \"{6}\",          \"labelField\": \"{7}\",          \"valueField\": \"{8}\",          \"nameField\": \"{9}\"         }}      ],      \"nameField\": \"{10}\",      \"idField\": \"{11}\",      \"typeField\": \"{12}\",      \"isCreateField\": \"{13}\",      \"isUpdateField\": \"{14}\",      \"filterField\": \"{15}\",      \"mandatoryField\": \"{16}\",      \"isKeyField\": \"{17}\",      \"lengthField\": \"{18}\",      \"isSystemField\": \"{19}\",      \"isHiddenField\": \"{20}\",      \"entityIDField\": \"{21}\",      \"lastUpdateField\": \"{22}\",      \"operationsField\": \"{23}\",      \"isFilterableField\": \"{24}\"     }}  ],  \"operators\": [    {{     \"entriesField\": [        {{         \"idField\": \"{25}\",          \"labelField\": \"{26}\",          \"valueField\": \"{27}\",          \"nameField\": \"{28}\"         }}      ],      \"typeField\": \"{29}\"     }}  ],  \"isFieldsDiscovered\": \"{30}\",  \"confType\": \"{31}\" }}",moduleId,moduleType,formId,entityType,entityName,entityAlias,idField,labelField,valueField,nameField,fields_nameField,fields_idField,typeField,isCreateField,isUpdateField,filterField,mandatoryField,isKeyField,lengthField,isSystemField,isHiddenField,entityIDField,lastUpdateField,operationsField,isFilterableField,entriesField_idField,entriesField_labelField,entriesField_valueField,entriesField_nameField,operators_typeField,isFieldsDiscovered,confType);
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