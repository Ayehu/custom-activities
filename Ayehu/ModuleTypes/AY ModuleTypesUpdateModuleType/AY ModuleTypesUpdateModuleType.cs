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
    public class AY_ModuleTypesUpdateModuleType : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "updateModuleType";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string type_p = "";
    
    public string typeName = "";
    
    public string entityName = "";
    
    public string icon_p = "";
    
    public string desc = "";
    
    public string confType = "";
    
    public string settings_p = "";
    
    public string behavior = "";
    
    public string defaultPort = "";
    
    public string Popserver = "";
    
    public string Popuser = "";
    
    public string Poppass = "";
    
    public string Smtpserver = "";
    
    public string Smtpout = "";
    
    public string Isavailable_p = "";
    
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
    
    public string files = "";
    
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
_uriBuilderPath = "Server/Api/ModuleType/updateModuleType";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"type\": \"{1}\",  \"typeName\": \"{2}\",  \"entityName\": \"{3}\",  \"icon\": \"{4}\",  \"desc\": \"{5}\",  \"confType\": \"{6}\",  \"settings\": \"{7}\",  \"behavior\": \"{8}\",  \"defaultPort\": \"{9}\",  \"dynamicMap\": {{   \"Popserver\": \"{10}\",    \"Popuser\": \"{11}\",    \"Poppass\": \"{12}\",    \"Smtpserver\": \"{13}\",    \"Smtpout\": \"{14}\",    \"Isavailable\": \"{15}\",    \"Incom\": \"{16}\",    \"Outcom\": \"{17}\",    \"Voicerepeat\": \"{18}\",    \"Voicespeed\": \"{19}\",    \"Voicetype\": \"{20}\",    \"Voicetypes\": \"{21}\",    \"Voicevolume\": \"{22}\",    \"Smscom\": \"{23}\",    \"Notactive\": \"{24}\",    \"Lic1\": \"{25}\",    \"Lic2\": \"{26}\",    \"Keypress\": \"{27}\",    \"Alerttype\": \"{28}\",    \"moduledevices\": \"{29}\",    \"reporttf\": \"{30}\",    \"PhoneLines\": \"{31}\",    \"Exe_Path\": \"{32}\",    \"loglevel\": \"{33}\",    \"logsdirectory\": \"{34}\",    \"lognumberofdaystopreserve\": \"{35}\",    \"dateformat\": \"{36}\"   }},  \"files\": {37} }}",id_p,type_p,typeName,entityName,icon_p,desc,confType,settings_p,behavior,defaultPort,Popserver,Popuser,Poppass,Smtpserver,Smtpout,Isavailable_p,Incom,Outcom,Voicerepeat,Voicespeed,Voicetype,Voicetypes,Voicevolume,Smscom,Notactive,Lic1,Lic2,Keypress,Alerttype,moduledevices,reporttf,PhoneLines,Exe_Path,loglevel,logsdirectory,lognumberofdaystopreserve,dateformat,files);
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
    
    public AY_ModuleTypesUpdateModuleType() {
    }
    
    public AY_ModuleTypesUpdateModuleType(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string type_p, 
                string typeName, 
                string entityName, 
                string icon_p, 
                string desc, 
                string confType, 
                string settings_p, 
                string behavior, 
                string defaultPort, 
                string Popserver, 
                string Popuser, 
                string Poppass, 
                string Smtpserver, 
                string Smtpout, 
                string Isavailable_p, 
                string Incom, 
                string Outcom, 
                string Voicerepeat, 
                string Voicespeed, 
                string Voicetype, 
                string Voicetypes, 
                string Voicevolume, 
                string Smscom, 
                string Notactive, 
                string Lic1, 
                string Lic2, 
                string Keypress, 
                string Alerttype, 
                string moduledevices, 
                string reporttf, 
                string PhoneLines, 
                string Exe_Path, 
                string loglevel, 
                string logsdirectory, 
                string lognumberofdaystopreserve, 
                string dateformat, 
                string files) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.type_p = type_p;
        this.typeName = typeName;
        this.entityName = entityName;
        this.icon_p = icon_p;
        this.desc = desc;
        this.confType = confType;
        this.settings_p = settings_p;
        this.behavior = behavior;
        this.defaultPort = defaultPort;
        this.Popserver = Popserver;
        this.Popuser = Popuser;
        this.Poppass = Poppass;
        this.Smtpserver = Smtpserver;
        this.Smtpout = Smtpout;
        this.Isavailable_p = Isavailable_p;
        this.Incom = Incom;
        this.Outcom = Outcom;
        this.Voicerepeat = Voicerepeat;
        this.Voicespeed = Voicespeed;
        this.Voicetype = Voicetype;
        this.Voicetypes = Voicetypes;
        this.Voicevolume = Voicevolume;
        this.Smscom = Smscom;
        this.Notactive = Notactive;
        this.Lic1 = Lic1;
        this.Lic2 = Lic2;
        this.Keypress = Keypress;
        this.Alerttype = Alerttype;
        this.moduledevices = moduledevices;
        this.reporttf = reporttf;
        this.PhoneLines = PhoneLines;
        this.Exe_Path = Exe_Path;
        this.loglevel = loglevel;
        this.logsdirectory = logsdirectory;
        this.lognumberofdaystopreserve = lognumberofdaystopreserve;
        this.dateformat = dateformat;
        this.files = files;
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