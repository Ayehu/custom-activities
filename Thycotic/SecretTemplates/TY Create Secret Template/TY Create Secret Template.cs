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
    public class CustomActivity_TY_Create_Secret_Template : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "secret-templates";
    
    public string password1 = "";
    
    public string fields__ = "";
    
    public string description = "";
    
    public string displayName = "";
    
    public string editablePermission = "";
    
    public string editRequires = "";
    
    public string fieldSlugName = "";
    
    public string generatePasswordCharacterSet = "";
    
    public string generatePasswordLength = "";
    
    public string hideOnView = "";
    
    public string historyLength = "";
    
    public string isExpirationField = "";
    
    public string isFile = "";
    
    public string isIndexable = "";
    
    public string isNotes = "";
    
    public string isPassword = "";
    
    public string isRequired = "";
    
    public string isUrl = "";
    
    public string mustEncrypt = "";
    
    public string name_p = "";
    
    public string passwordRequirementId = "";
    
    public string passwordTypeFieldId = "";
    
    public string sortOrder = "";
    
    public string _name = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "SecretServer/api/v1/secret-templates";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"fields\": [    {{     \"description\": \"{0}\",      \"displayName\": \"{1}\",      \"editablePermission\": \"{2}\",      \"editRequires\": \"{3}\",      \"fieldSlugName\": \"{4}\",      \"generatePasswordCharacterSet\": \"{5}\",      \"generatePasswordLength\": \"{6}\",      \"hideOnView\": \"{7}\",      \"historyLength\": \"{8}\",      \"isExpirationField\": \"{9}\",      \"isFile\": \"{10}\",      \"isIndexable\": \"{11}\",      \"isNotes\": \"{12}\",      \"isPassword\": \"{13}\",      \"isRequired\": \"{14}\",      \"isUrl\": \"{15}\",      \"mustEncrypt\": \"{16}\",      \"name\": \"{17}\",      \"passwordRequirementId\": \"{18}\",      \"passwordTypeFieldId\": \"{19}\",      \"sortOrder\": \"{20}\"     }}  ],  \"name\": \"{21}\" }}",description,displayName,editablePermission,editRequires,fieldSlugName,generatePasswordCharacterSet,generatePasswordLength,hideOnView,historyLength,isExpirationField,isFile,isIndexable,isNotes,isPassword,isRequired,isUrl,mustEncrypt,name_p,passwordRequirementId,passwordTypeFieldId,sortOrder,_name);
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