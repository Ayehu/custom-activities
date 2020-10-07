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
    public class CustomActivity_AY_RecipientAccountUpdateUserGroup : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "updateUserGroup";
    
    public string password1 = "";
    
    public string groupModel = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string userGroupDescription = "";
    
    public string site = "";
    
    public string activeDirectoryId = "";
    
    public string owners__ = "";
    
    public string owners_activeDirectoryId = "";
    
    public string userGroupId = "";
    
    public string owners_name = "";
    
    public string owners_id = "";
    
    public string groupMembers__ = "";
    
    public string permissionType = "";
    
    public string orderIndex = "";
    
    public string groupMembers_activeDirectoryId = "";
    
    public string groupMembers_userGroupId = "";
    
    public string groupMembers_name = "";
    
    public string groupMembers_id = "";
    
    public string ownersString = "";
    
    public string totalRecords = "";
    
    public string roleId = "";
    
    public string roleName = "";
    
    public string rolePriority = "";
    
    public string userGroupType = "";
    
    public string domainId = "";
    
    public string domainName = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "Server/Api/recipients/updateUserGroup";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"id\": \"{0}\",  \"name\": \"{1}\",  \"userGroupDescription\": \"{2}\",  \"site\": \"{3}\",  \"activeDirectoryId\": \"{4}\",  \"owners\": [    {{     \"activeDirectoryId\": \"{5}\",      \"userGroupId\": \"{6}\",      \"name\": \"{7}\",      \"id\": \"{8}\"     }}  ],  \"groupMembers\": [    {{     \"permissionType\": \"{9}\",      \"orderIndex\": \"{10}\",      \"activeDirectoryId\": \"{11}\",      \"userGroupId\": \"{12}\",      \"name\": \"{13}\",      \"id\": \"{14}\"     }}  ],  \"ownersString\": \"{15}\",  \"totalRecords\": \"{16}\",  \"roleId\": \"{17}\",  \"roleName\": \"{18}\",  \"rolePriority\": \"{19}\",  \"userGroupType\": \"{20}\",  \"domainId\": \"{21}\",  \"domainName\": \"{22}\" }}",id_p,name_p,userGroupDescription,site,activeDirectoryId,owners_activeDirectoryId,userGroupId,owners_name,owners_id,permissionType,orderIndex,groupMembers_activeDirectoryId,groupMembers_userGroupId,groupMembers_name,groupMembers_id,ownersString,totalRecords,roleId,roleName,rolePriority,userGroupType,domainId,domainName);
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