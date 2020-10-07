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
    public class CustomActivity_AY_TenantManagementUpdateTenant : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "updateTenant";
    
    public string password1 = "";
    
    public string entity = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string userName = "";
    
    public string desc = "";
    
    public string type = "";
    
    public string enabled = "";
    
    public string ownerFname = "";
    
    public string ownerLname = "";
    
    public string ownerEmail = "";
    
    public string ownerPhoneNumber = "";
    
    public string adminUserName = "";
    
    public string adminFirstName = "";
    
    public string adminLastName = "";
    
    public string adminEmail = "";
    
    public string password = "";
    
    public string isPasswordEncrypted = "";
    
    public string ports__ = "";
    
    public string portFrom = "";
    
    public string portTo = "";
    
    public string clonedTenantId = "";
    
    public string timeZone = "";
    
    public string createdModules__ = "";
    
    public string moduleId = "";
    
    public string moduleName = "";
    
    public string moduleType = "";
    
    public string moduleTypeName = "";
    
    public string deviceId = "";
    
    public string deviceName = "";
    
    public string quantity = "";
    
    public string licenseModules__ = "";
    
    public string licenseModules_moduleId = "";
    
    public string licenseModules_moduleName = "";
    
    public string licenseModules_moduleType = "";
    
    public string licenseModules_moduleTypeName = "";
    
    public string licenseModules_deviceId = "";
    
    public string licenseModules_deviceName = "";
    
    public string licenseModules_quantity = "";
    
    public string licenseExpireDate = "";
    
    public string licensedWorkflow = "";
    
    public string licenseVersion = "";
    
    public string supportType = "";
    
    public string model = "";
    
    public string IsDeleted = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "Server/Api/TenantManagement/updateTenant";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"id\": \"{0}\",  \"name\": \"{1}\",  \"userName\": \"{2}\",  \"desc\": \"{3}\",  \"type\": \"{4}\",  \"enabled\": \"{5}\",  \"ownerFname\": \"{6}\",  \"ownerLname\": \"{7}\",  \"ownerEmail\": \"{8}\",  \"ownerPhoneNumber\": \"{9}\",  \"adminUserName\": \"{10}\",  \"adminFirstName\": \"{11}\",  \"adminLastName\": \"{12}\",  \"adminEmail\": \"{13}\",  \"password\": \"{14}\",  \"isPasswordEncrypted\": \"{15}\",  \"ports\": [    {{     \"portFrom\": \"{16}\",      \"portTo\": \"{17}\"     }}  ],  \"clonedTenantId\": \"{18}\",  \"timeZone\": \"{19}\",  \"createdModules\": [    {{     \"moduleId\": \"{20}\",      \"moduleName\": \"{21}\",      \"moduleType\": \"{22}\",      \"moduleTypeName\": \"{23}\",      \"deviceId\": \"{24}\",      \"deviceName\": \"{25}\",      \"quantity\": \"{26}\"     }}  ],  \"licenseData\": {{   \"licenseModules\": [      {{       \"moduleId\": \"{27}\",        \"moduleName\": \"{28}\",        \"moduleType\": \"{29}\",        \"moduleTypeName\": \"{30}\",        \"deviceId\": \"{31}\",        \"deviceName\": \"{32}\",        \"quantity\": \"{33}\"       }}    ],    \"licenseExpireDate\": \"{34}\",    \"licensedWorkflow\": \"{35}\",    \"licenseVersion\": \"{36}\",    \"supportType\": \"{37}\",    \"model\": \"{38}\"   }},  \"IsDeleted\": \"{39}\" }}",id_p,name_p,userName,desc,type,enabled,ownerFname,ownerLname,ownerEmail,ownerPhoneNumber,adminUserName,adminFirstName,adminLastName,adminEmail,password,isPasswordEncrypted,portFrom,portTo,clonedTenantId,timeZone,moduleId,moduleName,moduleType,moduleTypeName,deviceId,deviceName,quantity,licenseModules_moduleId,licenseModules_moduleName,licenseModules_moduleType,licenseModules_moduleTypeName,licenseModules_deviceId,licenseModules_deviceName,licenseModules_quantity,licenseExpireDate,licensedWorkflow,licenseVersion,supportType,model,IsDeleted);
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