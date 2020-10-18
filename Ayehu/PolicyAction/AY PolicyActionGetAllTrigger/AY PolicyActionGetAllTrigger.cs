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
    public class AY_PolicyActionGetAllTrigger : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "getAllTrigger";
    
    public string password1 = "";
    
    public string status = "";
    
    public string stringToSearch = "";
    
    public string id_p = "";
    
    public string lastModify = "";
    
    public string pageSize = "";
    
    public string pageNumber = "";
    
    public string totalRecords = "";
    
    public string sortDirection = "";
    
    public string columnNameToSortBy = "";
    
    public string deleted = "";
    
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
_uriBuilderPath = "Server/Api/policyAction/getAllTrigger";
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
_postData = string.Format("{{ \"status\": \"{0}\",  \"stringToSearch\": \"{1}\",  \"id\": \"{2}\",  \"lastModify\": \"{3}\",  \"tableOptionsEntity\": {{   \"pageSize\": \"{4}\",    \"pageNumber\": \"{5}\",    \"totalRecords\": \"{6}\",    \"sortDirection\": \"{7}\",    \"columnNameToSortBy\": \"{8}\"   }},  \"deleted\": \"{9}\" }}",status,stringToSearch,id_p,lastModify,pageSize,pageNumber,totalRecords,sortDirection,columnNameToSortBy,deleted);
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
    
    public AY_PolicyActionGetAllTrigger() {
    }
    
    public AY_PolicyActionGetAllTrigger(string endPoint, string Jsonkeypath, string password1, string status, string stringToSearch, string id_p, string lastModify, string pageSize, string pageNumber, string totalRecords, string sortDirection, string columnNameToSortBy, string deleted) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.status = status;
        this.stringToSearch = stringToSearch;
        this.id_p = id_p;
        this.lastModify = lastModify;
        this.pageSize = pageSize;
        this.pageNumber = pageNumber;
        this.totalRecords = totalRecords;
        this.sortDirection = sortDirection;
        this.columnNameToSortBy = columnNameToSortBy;
        this.deleted = deleted;
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