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
    public class AY_IncidentConfigurationUpdateIncidentService : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "updateIncidentService";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string description_p = "";
    
    public string username = "";
    
    public string password = "";
    
    public string deleted = "";
    
    public string deviceType = "";
    
    public string site = "";
    
    public string executorId = "";
    
    public string ipAddress = "";
    
    public string platform = "";
    
    public string executeWorkflowForEveryUpdate = "";
    
    public string snmpMibs = "";
    
    public string sshCertificate = "";
    
    public string macAddress = "";
    
    public string inheritSSHCertificate = "";
    
    public string ticketID = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "PUT";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = "Server/API/IncidentConfiguration/updateIncidentService";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"name\": \"{1}\",  \"description\": \"{2}\",  \"username\": \"{3}\",  \"password\": \"{4}\",  \"deleted\": \"{5}\",  \"deviceType\": \"{6}\",  \"site\": \"{7}\",  \"executorId\": \"{8}\",  \"ipAddress\": \"{9}\",  \"platform\": \"{10}\",  \"executeWorkflowForEveryUpdate\": \"{11}\",  \"snmpMibs\": \"{12}\",  \"sshCertificate\": \"{13}\",  \"macAddress\": \"{14}\",  \"inheritSSHCertificate\": \"{15}\",  \"ticketID\": \"{16}\" }}",id_p,name_p,description_p,username,password,deleted,deviceType,site,executorId,ipAddress,platform,executeWorkflowForEveryUpdate,snmpMibs,sshCertificate,macAddress,inheritSSHCertificate,ticketID);
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
    
    public AY_IncidentConfigurationUpdateIncidentService() {
    }
    
    public AY_IncidentConfigurationUpdateIncidentService(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string name_p, 
                string description_p, 
                string username, 
                string password, 
                string deleted, 
                string deviceType, 
                string site, 
                string executorId, 
                string ipAddress, 
                string platform, 
                string executeWorkflowForEveryUpdate, 
                string snmpMibs, 
                string sshCertificate, 
                string macAddress, 
                string inheritSSHCertificate, 
                string ticketID) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.name_p = name_p;
        this.description_p = description_p;
        this.username = username;
        this.password = password;
        this.deleted = deleted;
        this.deviceType = deviceType;
        this.site = site;
        this.executorId = executorId;
        this.ipAddress = ipAddress;
        this.platform = platform;
        this.executeWorkflowForEveryUpdate = executeWorkflowForEveryUpdate;
        this.snmpMibs = snmpMibs;
        this.sshCertificate = sshCertificate;
        this.macAddress = macAddress;
        this.inheritSSHCertificate = inheritSSHCertificate;
        this.ticketID = ticketID;
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