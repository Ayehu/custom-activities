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
    public class CustomActivity_AY_ModuleAddModuleData : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "addModuleData";
    
    public string password1 = "";
    
    public string entity = "";
    
    public string id_p = "";
    
    public string type = "";
    
    public string @params = "";
    
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
    
    public string instances__ = "";
    
    public string instances_id = "";
    
    public string deviceId = "";
    
    public string deviceName = "";
    
    public string port = "";
    
    public string instances_status = "";
    
    public string lastModifyInstance = "";
    
    public string Form__ = "";
    
    public string FormID = "";
    
    public string FormName = "";
    
    public string Interval = "";
    
    public string Filter__ = "";
    
    public string FilterName = "";
    
    public string FilterItem__ = "";
    
    public string FieldID = "";
    
    public string FieldName = "";
    
    public string Operator = "";
    
    public string Value = "";
    
    public string IsDiscovered = "";
    
    public string MappingType = "";
    
    public string Map__ = "";
    
    public string Map_FormName = "";
    
    public string OptionalParams__ = "";
    
    public string key = "";
    
    public string value = "";
    
    public string EyeShareIncidentInstance = "";
    
    public string ByPassIncident = "";
    
    public string StaticState = "";
    
    public string StaticSeverity = "";
    
    public string SeverityStr = "";
    
    public string StateStr = "";
    
    public string Critical = "";
    
    public string Info = "";
    
    public string Major = "";
    
    public string Minor = "";
    
    public string Warning = "";
    
    public string Down = "";
    
    public string Up = "";
    
    public string forms__ = "";
    
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
    
    public string mode = "";
    
    public string defaultPort = "";
    
    public string logLevelDetails = "";
    
    public string connectionParameters__ = "";
    
    public string connectionParameters_key = "";
    
    public string connectionParameters_value = "";
    
    public string encrypted = "";
    
    public string hasConfiguredHooper = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "Server/Api/Module/addModuleData";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"id\": \"{0}\",  \"type\": \"{1}\",  \"params\": \"{2}\",  \"mtypeId\": \"{3}\",  \"name\": \"{4}\",  \"desc\": \"{5}\",  \"behavior\": \"{6}\",  \"status\": \"{7}\",  \"isMonitored\": \"{8}\",  \"isDeleted\": \"{9}\",  \"objectJson\": \"{10}\",  \"moduleTypeEntityName\": \"{11}\",  \"moduleTypeDescription\": \"{12}\",  \"moduleTypeUISettings\": \"{13}\",  \"configurationType\": \"{14}\",  \"instances\": [    {{     \"id\": \"{15}\",      \"deviceId\": \"{16}\",      \"deviceName\": \"{17}\",      \"port\": \"{18}\",      \"status\": \"{19}\"     }}  ],  \"lastModifyInstance\": \"{20}\",  \"filters\": {{   \"Form\": [      {{       \"FormID\": \"{21}\",        \"FormName\": \"{22}\",        \"Interval\": \"{23}\",        \"Filter\": [          {{           \"FilterName\": \"{24}\",            \"FilterItem\": [              {{               \"FieldID\": \"{25}\",                \"FieldName\": \"{26}\",                \"Operator\": \"{27}\",                \"Values\": {{                 \"Value\": \"{28}\"                 }}               }}            ]           }}        ],        \"IsDiscovered\": \"{29}\"       }}    ]   }},  \"mapping\": {{   \"MappingType\": \"{30}\",    \"Map\": [      {{       \"FormName\": \"{31}\",        \"OptionalParams\": [          {{           \"key\": \"{32}\",            \"value\": \"{33}\"           }}        ],        \"EyeShareIncidentInstance\": \"{34}\",        \"ByPassIncident\": \"{35}\",        \"StaticState\": \"{36}\",        \"StaticSeverity\": \"{37}\",        \"SeverityStr\": \"{38}\",        \"StateStr\": \"{39}\",        \"Severity\": {{         \"Critical\": \"{40}\",          \"Info\": \"{41}\",          \"Major\": \"{42}\",          \"Minor\": \"{43}\",          \"Warning\": \"{44}\"         }},        \"State\": {{         \"Down\": \"{45}\",          \"Up\": \"{46}\"         }}       }}    ]   }},  \"forms\": [    {{     \"moduleId\": \"{47}\",      \"moduleType\": \"{48}\",      \"formId\": \"{49}\",      \"entityType\": \"{50}\",      \"entityName\": \"{51}\",      \"entityAlias\": \"{52}\",      \"fields\": [        {{         \"entriesField\": [            {{             \"idField\": \"{53}\",              \"labelField\": \"{54}\",              \"valueField\": \"{55}\",              \"nameField\": \"{56}\"             }}          ],          \"nameField\": \"{57}\",          \"idField\": \"{58}\",          \"typeField\": \"{59}\",          \"isCreateField\": \"{60}\",          \"isUpdateField\": \"{61}\",          \"filterField\": \"{62}\",          \"mandatoryField\": \"{63}\",          \"isKeyField\": \"{64}\",          \"lengthField\": \"{65}\",          \"isSystemField\": \"{66}\",          \"isHiddenField\": \"{67}\",          \"entityIDField\": \"{68}\",          \"lastUpdateField\": \"{69}\",          \"operationsField\": \"{70}\",          \"isFilterableField\": \"{71}\"         }}      ],      \"operators\": [        {{         \"entriesField\": [            {{             \"idField\": \"{72}\",              \"labelField\": \"{73}\",              \"valueField\": \"{74}\",              \"nameField\": \"{75}\"             }}          ],          \"typeField\": \"{76}\"         }}      ],      \"isFieldsDiscovered\": \"{77}\",      \"confType\": \"{78}\"     }}  ],  \"mode\": \"{79}\",  \"defaultPort\": \"{80}\",  \"logLevelDetails\": \"{81}\",  \"connectionParameters\": [    {{     \"key\": \"{82}\",      \"value\": \"{83}\",      \"encrypted\": \"{84}\"     }}  ],  \"hasConfiguredHooper\": \"{85}\" }}",id_p,type,params,mtypeId,name_p,desc,behavior,status,isMonitored,isDeleted,objectJson,moduleTypeEntityName,moduleTypeDescription,moduleTypeUISettings,configurationType,instances_id,deviceId,deviceName,port,instances_status,lastModifyInstance,FormID,FormName,Interval,FilterName,FieldID,FieldName,Operator,Value,IsDiscovered,MappingType,Map_FormName,key,value,EyeShareIncidentInstance,ByPassIncident,StaticState,StaticSeverity,SeverityStr,StateStr,Critical,Info,Major,Minor,Warning,Down,Up,moduleId,moduleType,formId,entityType,entityName,entityAlias,idField,labelField,valueField,nameField,fields_nameField,fields_idField,typeField,isCreateField,isUpdateField,filterField,mandatoryField,isKeyField,lengthField,isSystemField,isHiddenField,entityIDField,lastUpdateField,operationsField,isFilterableField,entriesField_idField,entriesField_labelField,entriesField_valueField,entriesField_nameField,operators_typeField,isFieldsDiscovered,confType,mode,defaultPort,logLevelDetails,connectionParameters_key,connectionParameters_value,encrypted,hasConfiguredHooper);
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