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
    public class TY_Search_Recorded_Sessions : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "recorded-sessions";
    
    public string password1 = "";
    
    public string filter_active = "";
    
    public string filter_dateRange = "";
    
    public string filter_endDate = "";
    
    public string filter_endTime = "";
    
    public string filter_folderId = "";
    
    public string filter_groupIds = "";
    
    public string filter_includeNonSecretServerSessions = "";
    
    public string filter_includeOnlyLaunchedSuccessfully = "";
    
    public string filter_includeRestricted = "";
    
    public string filter_includeSubFolders = "";
    
    public string filter_launcherTypeId = "";
    
    public string filter_searchText = "";
    
    public string filter_searchTypes = "";
    
    public string filter_secretIds = "";
    
    public string filter_siteId = "";
    
    public string filter_startDate = "";
    
    public string filter_startTime = "";
    
    public string filter_userIds = "";
    
    public string skip = "";
    
    public string sortBy_0__direction = "";
    
    public string sortBy_0__name = "";
    
    public string sortBy_0__priority = "";
    
    public string take = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "GET";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = "SecretServer/api/v1/recorded-sessions";
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
_postData = "";
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
_queryStringArray = new Dictionary<string, string>() { {"filter.active",filter_active},{"filter.dateRange",filter_dateRange},{"filter.endDate",filter_endDate},{"filter.endTime",filter_endTime},{"filter.folderId",filter_folderId},{"filter.groupIds",filter_groupIds},{"filter.includeNonSecretServerSessions",filter_includeNonSecretServerSessions},{"filter.includeOnlyLaunchedSuccessfully",filter_includeOnlyLaunchedSuccessfully},{"filter.includeRestricted",filter_includeRestricted},{"filter.includeSubFolders",filter_includeSubFolders},{"filter.launcherTypeId",filter_launcherTypeId},{"filter.searchText",filter_searchText},{"filter.searchTypes",filter_searchTypes},{"filter.secretIds",filter_secretIds},{"filter.siteId",filter_siteId},{"filter.startDate",filter_startDate},{"filter.startTime",filter_startTime},{"filter.userIds",filter_userIds},{"skip",skip},{"sortBy[0].direction",sortBy_0__direction},{"sortBy[0].name",sortBy_0__name},{"sortBy[0].priority",sortBy_0__priority},{"take",take} };
            }
return _queryStringArray;
        }
        set {
            this._queryStringArray = value;
        }
    }
    
    public TY_Search_Recorded_Sessions() {
    }
    
    public TY_Search_Recorded_Sessions(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string filter_active, 
                string filter_dateRange, 
                string filter_endDate, 
                string filter_endTime, 
                string filter_folderId, 
                string filter_groupIds, 
                string filter_includeNonSecretServerSessions, 
                string filter_includeOnlyLaunchedSuccessfully, 
                string filter_includeRestricted, 
                string filter_includeSubFolders, 
                string filter_launcherTypeId, 
                string filter_searchText, 
                string filter_searchTypes, 
                string filter_secretIds, 
                string filter_siteId, 
                string filter_startDate, 
                string filter_startTime, 
                string filter_userIds, 
                string skip, 
                string sortBy_0__direction, 
                string sortBy_0__name, 
                string sortBy_0__priority, 
                string take) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.filter_active = filter_active;
        this.filter_dateRange = filter_dateRange;
        this.filter_endDate = filter_endDate;
        this.filter_endTime = filter_endTime;
        this.filter_folderId = filter_folderId;
        this.filter_groupIds = filter_groupIds;
        this.filter_includeNonSecretServerSessions = filter_includeNonSecretServerSessions;
        this.filter_includeOnlyLaunchedSuccessfully = filter_includeOnlyLaunchedSuccessfully;
        this.filter_includeRestricted = filter_includeRestricted;
        this.filter_includeSubFolders = filter_includeSubFolders;
        this.filter_launcherTypeId = filter_launcherTypeId;
        this.filter_searchText = filter_searchText;
        this.filter_searchTypes = filter_searchTypes;
        this.filter_secretIds = filter_secretIds;
        this.filter_siteId = filter_siteId;
        this.filter_startDate = filter_startDate;
        this.filter_startTime = filter_startTime;
        this.filter_userIds = filter_userIds;
        this.skip = skip;
        this.sortBy_0__direction = sortBy_0__direction;
        this.sortBy_0__name = sortBy_0__name;
        this.sortBy_0__priority = sortBy_0__priority;
        this.take = take;
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