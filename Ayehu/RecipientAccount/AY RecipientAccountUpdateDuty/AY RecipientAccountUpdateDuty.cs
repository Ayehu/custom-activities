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
    public class AY_RecipientAccountUpdateDuty : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "updateDuty";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string Ddescp = "";
    
    public string Site = "";
    
    public string DutyTimeFramesNumber = "";
    
    public string FollowTheSun = "";
    
    public string ObjectNumber = "";
    
    public string UseWhenShiftMissing = "";
    
    public string AlwaysUseThisContact = "";
    
    public string DutySupervisors = "";
    
    public string DefaultContactUserName = "";
    
    public string DefaultUserType = "";
    
    public string totalRecords = "";
    
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
_uriBuilderPath = "Server/Api/recipients/updateDuty";
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
_postData = string.Format("{{ \"id\": \"{0}\",  \"name\": \"{1}\",  \"Ddescp\": \"{2}\",  \"Site\": \"{3}\",  \"DutyTimeFramesNumber\": \"{4}\",  \"FollowTheSun\": \"{5}\",  \"ObjectNumber\": \"{6}\",  \"UseWhenShiftMissing\": \"{7}\",  \"AlwaysUseThisContact\": \"{8}\",  \"DutySupervisors\": {9},  \"DefaultContactUserName\": \"{10}\",  \"DefaultUserType\": \"{11}\",  \"totalRecords\": \"{12}\" }}",id_p,name_p,Ddescp,Site,DutyTimeFramesNumber,FollowTheSun,ObjectNumber,UseWhenShiftMissing,AlwaysUseThisContact,DutySupervisors,DefaultContactUserName,DefaultUserType,totalRecords);
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
    
    public AY_RecipientAccountUpdateDuty() {
    }
    
    public AY_RecipientAccountUpdateDuty(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string name_p, 
                string Ddescp, 
                string Site, 
                string DutyTimeFramesNumber, 
                string FollowTheSun, 
                string ObjectNumber, 
                string UseWhenShiftMissing, 
                string AlwaysUseThisContact, 
                string DutySupervisors, 
                string DefaultContactUserName, 
                string DefaultUserType, 
                string totalRecords) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.name_p = name_p;
        this.Ddescp = Ddescp;
        this.Site = Site;
        this.DutyTimeFramesNumber = DutyTimeFramesNumber;
        this.FollowTheSun = FollowTheSun;
        this.ObjectNumber = ObjectNumber;
        this.UseWhenShiftMissing = UseWhenShiftMissing;
        this.AlwaysUseThisContact = AlwaysUseThisContact;
        this.DutySupervisors = DutySupervisors;
        this.DefaultContactUserName = DefaultContactUserName;
        this.DefaultUserType = DefaultUserType;
        this.totalRecords = totalRecords;
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