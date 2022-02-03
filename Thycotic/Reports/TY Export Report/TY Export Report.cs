using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.Thycotic
{
    public class TY_Export_Report : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "export";
    
    public string password1 = "";
    
    public string delimiter = "";
    
    public string domainId = "";
    
    public string password = "";
    
    public string twoFactor = "";
    
    public string username = "";
    
    public string encodeHtml = "";
    
    public string endRecordNumber = "";
    
    public string format = "";
    
    public string id_p = "";
    
    public string isAscending = "";
    
    public string name_p = "";
    
    public string orderByFieldOrdinal = "";
    
    public string pageNumber = "";
    
    public string parameters = "";
    
    public string recordsPerPage = "";
    
    public string startRecordNumber = "";
    
    public string timeZone = "";
    
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
_uriBuilderPath = "SecretServer/api/v1/reports/export";
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
_postData = string.Format("{{ \"delimiter\": \"{0}\",  \"dualControlApproval\": {{   \"domainId\": \"{1}\",    \"password\": \"{2}\",    \"twoFactor\": \"{3}\",    \"username\": \"{4}\"   }},  \"encodeHtml\": \"{5}\",  \"endRecordNumber\": \"{6}\",  \"format\": \"{7}\",  \"id\": \"{8}\",  \"isAscending\": \"{9}\",  \"name\": \"{10}\",  \"orderByFieldOrdinal\": \"{11}\",  \"pageNumber\": \"{12}\",  \"parameters\": {13},  \"recordsPerPage\": \"{14}\",  \"startRecordNumber\": \"{15}\",  \"timeZone\": \"{16}\" }}",delimiter,domainId,password,twoFactor,username,encodeHtml,endRecordNumber,format,id_p,isAscending,name_p,orderByFieldOrdinal,pageNumber,parameters,recordsPerPage,startRecordNumber,timeZone);
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
_headers = new Dictionary<string, string>() { {"Authorization","Bearer " + password1} };
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
    
    public TY_Export_Report() {
    }
    
    public TY_Export_Report(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string delimiter, 
                string domainId, 
                string password, 
                string twoFactor, 
                string username, 
                string encodeHtml, 
                string endRecordNumber, 
                string format, 
                string id_p, 
                string isAscending, 
                string name_p, 
                string orderByFieldOrdinal, 
                string pageNumber, 
                string parameters, 
                string recordsPerPage, 
                string startRecordNumber, 
                string timeZone) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.delimiter = delimiter;
        this.domainId = domainId;
        this.password = password;
        this.twoFactor = twoFactor;
        this.username = username;
        this.encodeHtml = encodeHtml;
        this.endRecordNumber = endRecordNumber;
        this.format = format;
        this.id_p = id_p;
        this.isAscending = isAscending;
        this.name_p = name_p;
        this.orderByFieldOrdinal = orderByFieldOrdinal;
        this.pageNumber = pageNumber;
        this.parameters = parameters;
        this.recordsPerPage = recordsPerPage;
        this.startRecordNumber = startRecordNumber;
        this.timeZone = timeZone;
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