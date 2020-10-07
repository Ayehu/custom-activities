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
    public class CustomActivity_AY_ModuleTypesCreateModuleType : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "createModuleType";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string type = "";
    
    public string typeName = "";
    
    public string entityName = "";
    
    public string icon = "";
    
    public string desc = "";
    
    public string confType = "";
    
    public string settings = "";
    
    public string behavior = "";
    
    public string defaultPort = "";
    
    public string Popserver = "";
    
    public string Popuser = "";
    
    public string Poppass = "";
    
    public string Smtpserver = "";
    
    public string Smtpout = "";
    
    public string Isavailable = "";
    
    public string Incom = "";
    
    public string Outcom = "";
    
    public string Voicerepeat = "";
    
    public string Voicespeed = "";
    
    public string Voicetype = "";
    
    public string Voicetypes = "";
    
    public string Voicevolume = "";
    
    public string Smscom = "";
    
    public string Notactive = "";
    
    public string Lic1 = "";
    
    public string Lic2 = "";
    
    public string Keypress = "";
    
    public string Alerttype = "";
    
    public string moduledevices = "";
    
    public string reporttf = "";
    
    public string PhoneLines = "";
    
    public string Exe_Path = "";
    
    public string loglevel = "";
    
    public string logsdirectory = "";
    
    public string lognumberofdaystopreserve = "";
    
    public string dateformat = "";
    
    public string files__ = "";
    
    public string files_id = "";
    
    public string fileId = "";
    
    public string fileName = "";
    
    public string fileType = "";
    
    public string fileData = "";
    
    public string fileDataType = "";
    
    public string fileMetaData = "";
    
    public string dateCreated = "";
    
    public string userCreatedBy = "";
    
    public string code = "";
    
    public string description = "";
    
    public string extraData = "";
    
    public string errorsList__ = "";
    
    public string errorsList_code = "";
    
    public string errorsList_description = "";
    
    public string errorsList_extraData = "";
    
    public string errorType = "";
    
    public string errorsList_errorType = "";
    
    public string errorMessageDetails_errorType = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "Server/Api/ModuleType/createModuleType";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"id\": \"{0}\",  \"type\": \"{1}\",  \"typeName\": \"{2}\",  \"entityName\": \"{3}\",  \"icon\": \"{4}\",  \"desc\": \"{5}\",  \"confType\": \"{6}\",  \"settings\": \"{7}\",  \"behavior\": \"{8}\",  \"defaultPort\": \"{9}\",  \"dynamicMap\": {{   \"Popserver\": \"{10}\",    \"Popuser\": \"{11}\",    \"Poppass\": \"{12}\",    \"Smtpserver\": \"{13}\",    \"Smtpout\": \"{14}\",    \"Isavailable\": \"{15}\",    \"Incom\": \"{16}\",    \"Outcom\": \"{17}\",    \"Voicerepeat\": \"{18}\",    \"Voicespeed\": \"{19}\",    \"Voicetype\": \"{20}\",    \"Voicetypes\": \"{21}\",    \"Voicevolume\": \"{22}\",    \"Smscom\": \"{23}\",    \"Notactive\": \"{24}\",    \"Lic1\": \"{25}\",    \"Lic2\": \"{26}\",    \"Keypress\": \"{27}\",    \"Alerttype\": \"{28}\",    \"moduledevices\": \"{29}\",    \"reporttf\": \"{30}\",    \"PhoneLines\": \"{31}\",    \"Exe_Path\": \"{32}\",    \"loglevel\": \"{33}\",    \"logsdirectory\": \"{34}\",    \"lognumberofdaystopreserve\": \"{35}\",    \"dateformat\": \"{36}\"   }},  \"files\": [    {{     \"id\": \"{37}\",      \"fileId\": \"{38}\",      \"fileName\": \"{39}\",      \"fileType\": \"{40}\",      \"fileData\": \"{41}\",      \"fileDataType\": \"{42}\",      \"fileMetaData\": \"{43}\",      \"dateCreated\": \"{44}\",      \"userCreatedBy\": \"{45}\",      \"errorMessageDetails\": {{       \"code\": \"{46}\",        \"description\": \"{47}\",        \"extraData\": \"{48}\",        \"errorsList\": [          {{           \"code\": \"{49}\",            \"description\": \"{50}\",            \"extraData\": \"{51}\",            \"errorsList\": [              {{               \"code\": \"{49}\",                \"description\": \"{50}\",                \"extraData\": \"{51}\",                \"errorType\": \"{52}\"               }}            ],            \"errorType\": \"{53}\"           }}        ],        \"errorType\": \"{54}\"       }}     }}  ] }}",id_p,type,typeName,entityName,icon,desc,confType,settings,behavior,defaultPort,Popserver,Popuser,Poppass,Smtpserver,Smtpout,Isavailable,Incom,Outcom,Voicerepeat,Voicespeed,Voicetype,Voicetypes,Voicevolume,Smscom,Notactive,Lic1,Lic2,Keypress,Alerttype,moduledevices,reporttf,PhoneLines,Exe_Path,loglevel,logsdirectory,lognumberofdaystopreserve,dateformat,files_id,fileId,fileName,fileType,fileData,fileDataType,fileMetaData,dateCreated,userCreatedBy,code,description,extraData,errorsList_code,errorsList_description,errorsList_extraData,errorType,errorsList_errorType,errorMessageDetails_errorType);
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