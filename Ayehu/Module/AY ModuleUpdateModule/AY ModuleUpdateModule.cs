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
    public class AY_ModuleUpdateModule : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "updateModuleData";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string type_p = "";
    
    public string params_p = "";
    
    public string mtypeId = "";
    
    public string name_p = "";
    
    public string desc = "";
    
    public string behavior = "";
    
    public string status = "";
    
    public string isMonitored = "";
    
    public string isDeleted = "";
    
    public string objectJson = "";
    
    public string moduleTypeEntityName = "";
    
    public string moduleTypeDescription = "";
    
    public string moduleTypeUISettings = "";
    
    public string configurationType = "";
    
    public string instances = "";
    
    public string lastModifyInstance = "";
    
    public string Form = "";
    
    public string MappingType = "";
    
    public string Map = "";
    
    public string forms = "";
    
    public string mode = "";
    
    public string defaultPort = "";
    
    public string logLevelDetails = "";
    
    public string connectionParameters = "";
    
    public string hasConfiguredHooper = "";
    
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
_uriBuilderPath = "Server/Api/Module/updateModuleData";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"type\": \"{1}\",  \"params\": \"{2}\",  \"mtypeId\": \"{3}\",  \"name\": \"{4}\",  \"desc\": \"{5}\",  \"behavior\": \"{6}\",  \"status\": \"{7}\",  \"isMonitored\": \"{8}\",  \"isDeleted\": \"{9}\",  \"objectJson\": \"{10}\",  \"moduleTypeEntityName\": \"{11}\",  \"moduleTypeDescription\": \"{12}\",  \"moduleTypeUISettings\": \"{13}\",  \"configurationType\": \"{14}\",  \"instances\": {15},  \"lastModifyInstance\": \"{16}\",  \"filters\": {{   \"Form\": {17}   }},  \"mapping\": {{   \"MappingType\": \"{18}\",    \"Map\": {19}   }},  \"forms\": {20},  \"mode\": \"{21}\",  \"defaultPort\": \"{22}\",  \"logLevelDetails\": \"{23}\",  \"connectionParameters\": {24},  \"hasConfiguredHooper\": \"{25}\" }}",id_p,type_p,params_p,mtypeId,name_p,desc,behavior,status,isMonitored,isDeleted,objectJson,moduleTypeEntityName,moduleTypeDescription,moduleTypeUISettings,configurationType,instances,lastModifyInstance,Form,MappingType,Map,forms,mode,defaultPort,logLevelDetails,connectionParameters,hasConfiguredHooper);
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
    
    public AY_ModuleUpdateModule() {
    }
    
    public AY_ModuleUpdateModule(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string type_p, 
                string params_p, 
                string mtypeId, 
                string name_p, 
                string desc, 
                string behavior, 
                string status, 
                string isMonitored, 
                string isDeleted, 
                string objectJson, 
                string moduleTypeEntityName, 
                string moduleTypeDescription, 
                string moduleTypeUISettings, 
                string configurationType, 
                string instances, 
                string lastModifyInstance, 
                string Form, 
                string MappingType, 
                string Map, 
                string forms, 
                string mode, 
                string defaultPort, 
                string logLevelDetails, 
                string connectionParameters, 
                string hasConfiguredHooper) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.type_p = type_p;
        this.params_p = params_p;
        this.mtypeId = mtypeId;
        this.name_p = name_p;
        this.desc = desc;
        this.behavior = behavior;
        this.status = status;
        this.isMonitored = isMonitored;
        this.isDeleted = isDeleted;
        this.objectJson = objectJson;
        this.moduleTypeEntityName = moduleTypeEntityName;
        this.moduleTypeDescription = moduleTypeDescription;
        this.moduleTypeUISettings = moduleTypeUISettings;
        this.configurationType = configurationType;
        this.instances = instances;
        this.lastModifyInstance = lastModifyInstance;
        this.Form = Form;
        this.MappingType = MappingType;
        this.Map = Map;
        this.forms = forms;
        this.mode = mode;
        this.defaultPort = defaultPort;
        this.logLevelDetails = logLevelDetails;
        this.connectionParameters = connectionParameters;
        this.hasConfiguredHooper = hasConfiguredHooper;
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