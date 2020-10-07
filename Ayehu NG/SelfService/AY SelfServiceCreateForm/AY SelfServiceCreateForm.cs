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
    public class CustomActivity_AY_SelfServiceCreateForm : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "createForm";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string tags__ = "";
    
    public string tags_id = "";
    
    public string tags_name = "";
    
    public string description = "";
    
    public string _description = "";
    
    public string workflowId = "";
    
    public string enabled = "";
    
    public string deleted = "";
    
    public string structure = "";
    
    public string permissions__ = "";
    
    public string type = "";
    
    public string number = "";
    
    public string permissions_name = "";
    
    public string read = "";
    
    public string write = "";
    
    public string run = "";
    
    public string owner = "";
    
    public string jsonStructure = "";
    
    public string formControls__ = "";
    
    public string variableName = "";
    
    public string variableId = "";
    
    public string formControls_workflowId = "";
    
    public string workflowName = "";
    
    public string formControls_id = "";
    
    public string selected = "";
    
    public string rightToLeft = "";
    
    public string maxLength = "";
    
    public string formControls_name = "";
    
    public string bold = "";
    
    public string italic = "";
    
    public string underline = "";
    
    public string color = "";
    
    public string font = "";
    
    public string size = "";
    
    public string strike = "";
    
    public string folderId = "";
    
    public string createUserId = "";
    
    public string lastModfieidUserId = "";
    
    public string createDate = "";
    
    public string modifiedDate = "";
    
    public string enableConfirm = "";
    
    public string parentPath = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "Server/Api/selfService/createForm";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"id\": \"{0}\",  \"name\": \"{1}\",  \"tags\": [    {{     \"id\": \"{2}\",      \"name\": \"{3}\",      \"description\": \"{4}\"     }}  ],  \"description\": \"{5}\",  \"workflowId\": \"{6}\",  \"enabled\": \"{7}\",  \"deleted\": \"{8}\",  \"structure\": \"{9}\",  \"permissions\": [    {{     \"type\": \"{10}\",      \"number\": \"{11}\",      \"name\": \"{12}\",      \"read\": \"{13}\",      \"write\": \"{14}\",      \"run\": \"{15}\",      \"owner\": \"{16}\"     }}  ],  \"jsonStructure\": \"{17}\",  \"formControls\": [    {{     \"variableName\": \"{18}\",      \"variableId\": \"{19}\",      \"workflowId\": \"{20}\",      \"workflowName\": \"{21}\",      \"id\": \"{22}\",      \"selected\": \"{23}\",      \"rightToLeft\": \"{24}\",      \"maxLength\": \"{25}\",      \"name\": \"{26}\",      \"toolbarModel\": {{       \"data\": {{         \"bold\": \"{27}\",          \"italic\": \"{28}\",          \"underline\": \"{29}\",          \"color\": \"{30}\",          \"font\": \"{31}\",          \"size\": \"{32}\",          \"strike\": \"{33}\"         }}       }}     }}  ],  \"folderId\": \"{34}\",  \"createUserId\": \"{35}\",  \"lastModfieidUserId\": \"{36}\",  \"createDate\": \"{37}\",  \"modifiedDate\": \"{38}\",  \"enableConfirm\": \"{39}\",  \"parentPath\": \"{40}\" }}",id_p,name_p,tags_id,tags_name,description,_description,workflowId,enabled,deleted,structure,type,number,permissions_name,read,write,run,owner,jsonStructure,variableName,variableId,formControls_workflowId,workflowName,formControls_id,selected,rightToLeft,maxLength,formControls_name,bold,italic,underline,color,font,size,strike,folderId,createUserId,lastModfieidUserId,createDate,modifiedDate,enableConfirm,parentPath);
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