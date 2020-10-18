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
    public class AY_TenantManagementUpdateTenant : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "updateTenant";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string userName = "";
    
    public string desc = "";
    
    public string type_p = "";
    
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
    
    public string ports = "";
    
    public string clonedTenantId = "";
    
    public string timeZone = "";
    
    public string createdModules = "";
    
    public string licenseModules = "";
    
    public string licenseExpireDate = "";
    
    public string licensedWorkflow = "";
    
    public string licenseVersion = "";
    
    public string supportType = "";
    
    public string model = "";
    
    public string IsDeleted = "";
    
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
_uriBuilderPath = "Server/Api/TenantManagement/updateTenant";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"name\": \"{1}\",  \"userName\": \"{2}\",  \"desc\": \"{3}\",  \"type\": \"{4}\",  \"enabled\": \"{5}\",  \"ownerFname\": \"{6}\",  \"ownerLname\": \"{7}\",  \"ownerEmail\": \"{8}\",  \"ownerPhoneNumber\": \"{9}\",  \"adminUserName\": \"{10}\",  \"adminFirstName\": \"{11}\",  \"adminLastName\": \"{12}\",  \"adminEmail\": \"{13}\",  \"password\": \"{14}\",  \"isPasswordEncrypted\": \"{15}\",  \"ports\": {16},  \"clonedTenantId\": \"{17}\",  \"timeZone\": \"{18}\",  \"createdModules\": {19},  \"licenseData\": {{   \"licenseModules\": {20},    \"licenseExpireDate\": \"{21}\",    \"licensedWorkflow\": \"{22}\",    \"licenseVersion\": \"{23}\",    \"supportType\": \"{24}\",    \"model\": \"{25}\"   }},  \"IsDeleted\": \"{26}\" }}",id_p,name_p,userName,desc,type_p,enabled,ownerFname,ownerLname,ownerEmail,ownerPhoneNumber,adminUserName,adminFirstName,adminLastName,adminEmail,password,isPasswordEncrypted,ports,clonedTenantId,timeZone,createdModules,licenseModules,licenseExpireDate,licensedWorkflow,licenseVersion,supportType,model,IsDeleted);
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
    
    public AY_TenantManagementUpdateTenant() {
    }
    
    public AY_TenantManagementUpdateTenant(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string name_p, 
                string userName, 
                string desc, 
                string type_p, 
                string enabled, 
                string ownerFname, 
                string ownerLname, 
                string ownerEmail, 
                string ownerPhoneNumber, 
                string adminUserName, 
                string adminFirstName, 
                string adminLastName, 
                string adminEmail, 
                string password, 
                string isPasswordEncrypted, 
                string ports, 
                string clonedTenantId, 
                string timeZone, 
                string createdModules, 
                string licenseModules, 
                string licenseExpireDate, 
                string licensedWorkflow, 
                string licenseVersion, 
                string supportType, 
                string model, 
                string IsDeleted) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.name_p = name_p;
        this.userName = userName;
        this.desc = desc;
        this.type_p = type_p;
        this.enabled = enabled;
        this.ownerFname = ownerFname;
        this.ownerLname = ownerLname;
        this.ownerEmail = ownerEmail;
        this.ownerPhoneNumber = ownerPhoneNumber;
        this.adminUserName = adminUserName;
        this.adminFirstName = adminFirstName;
        this.adminLastName = adminLastName;
        this.adminEmail = adminEmail;
        this.password = password;
        this.isPasswordEncrypted = isPasswordEncrypted;
        this.ports = ports;
        this.clonedTenantId = clonedTenantId;
        this.timeZone = timeZone;
        this.createdModules = createdModules;
        this.licenseModules = licenseModules;
        this.licenseExpireDate = licenseExpireDate;
        this.licensedWorkflow = licensedWorkflow;
        this.licenseVersion = licenseVersion;
        this.supportType = supportType;
        this.model = model;
        this.IsDeleted = IsDeleted;
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