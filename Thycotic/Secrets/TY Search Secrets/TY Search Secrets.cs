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
    public class TY_Search_Secrets : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "secrets";
    
    public string password1 = "";
    
    public string filter_allowDoubleLocks = "";
    
    public string filter_doNotCalculateTotal = "";
    
    public string filter_doubleLockId = "";
    
    public string filter_extendedFields = "";
    
    public string filter_extendedTypeId = "";
    
    public string filter_folderId = "";
    
    public string filter_heartbeatStatus = "";
    
    public string filter_includeActive = "";
    
    public string filter_includeInactive = "";
    
    public string filter_includeRestricted = "";
    
    public string filter_includeSubFolders = "";
    
    public string filter_isExactMatch = "";
    
    public string filter_onlyRPCEnabled = "";
    
    public string filter_onlySharedWithMe = "";
    
    public string filter_passwordTypeIds = "";
    
    public string filter_permissionRequired = "";
    
    public string filter_scope = "";
    
    public string filter_searchField = "";
    
    public string filter_searchFieldSlug = "";
    
    public string filter_searchText = "";
    
    public string filter_secretTemplateId = "";
    
    public string filter_siteId = "";
    
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
_uriBuilderPath = "SecretServer/api/v1/secrets";
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
_queryStringArray = new Dictionary<string, string>() { {"filter.allowDoubleLocks",filter_allowDoubleLocks},{"filter.doNotCalculateTotal",filter_doNotCalculateTotal},{"filter.doubleLockId",filter_doubleLockId},{"filter.extendedFields",filter_extendedFields},{"filter.extendedTypeId",filter_extendedTypeId},{"filter.folderId",filter_folderId},{"filter.heartbeatStatus",filter_heartbeatStatus},{"filter.includeActive",filter_includeActive},{"filter.includeInactive",filter_includeInactive},{"filter.includeRestricted",filter_includeRestricted},{"filter.includeSubFolders",filter_includeSubFolders},{"filter.isExactMatch",filter_isExactMatch},{"filter.onlyRPCEnabled",filter_onlyRPCEnabled},{"filter.onlySharedWithMe",filter_onlySharedWithMe},{"filter.passwordTypeIds",filter_passwordTypeIds},{"filter.permissionRequired",filter_permissionRequired},{"filter.scope",filter_scope},{"filter.searchField",filter_searchField},{"filter.searchFieldSlug",filter_searchFieldSlug},{"filter.searchText",filter_searchText},{"filter.secretTemplateId",filter_secretTemplateId},{"filter.siteId",filter_siteId},{"skip",skip},{"sortBy[0].direction",sortBy_0__direction},{"sortBy[0].name",sortBy_0__name},{"sortBy[0].priority",sortBy_0__priority},{"take",take} };
            }
return _queryStringArray;
        }
        set {
            this._queryStringArray = value;
        }
    }
    
    public TY_Search_Secrets() {
    }
    
    public TY_Search_Secrets(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string filter_allowDoubleLocks, 
                string filter_doNotCalculateTotal, 
                string filter_doubleLockId, 
                string filter_extendedFields, 
                string filter_extendedTypeId, 
                string filter_folderId, 
                string filter_heartbeatStatus, 
                string filter_includeActive, 
                string filter_includeInactive, 
                string filter_includeRestricted, 
                string filter_includeSubFolders, 
                string filter_isExactMatch, 
                string filter_onlyRPCEnabled, 
                string filter_onlySharedWithMe, 
                string filter_passwordTypeIds, 
                string filter_permissionRequired, 
                string filter_scope, 
                string filter_searchField, 
                string filter_searchFieldSlug, 
                string filter_searchText, 
                string filter_secretTemplateId, 
                string filter_siteId, 
                string skip, 
                string sortBy_0__direction, 
                string sortBy_0__name, 
                string sortBy_0__priority, 
                string take) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.filter_allowDoubleLocks = filter_allowDoubleLocks;
        this.filter_doNotCalculateTotal = filter_doNotCalculateTotal;
        this.filter_doubleLockId = filter_doubleLockId;
        this.filter_extendedFields = filter_extendedFields;
        this.filter_extendedTypeId = filter_extendedTypeId;
        this.filter_folderId = filter_folderId;
        this.filter_heartbeatStatus = filter_heartbeatStatus;
        this.filter_includeActive = filter_includeActive;
        this.filter_includeInactive = filter_includeInactive;
        this.filter_includeRestricted = filter_includeRestricted;
        this.filter_includeSubFolders = filter_includeSubFolders;
        this.filter_isExactMatch = filter_isExactMatch;
        this.filter_onlyRPCEnabled = filter_onlyRPCEnabled;
        this.filter_onlySharedWithMe = filter_onlySharedWithMe;
        this.filter_passwordTypeIds = filter_passwordTypeIds;
        this.filter_permissionRequired = filter_permissionRequired;
        this.filter_scope = filter_scope;
        this.filter_searchField = filter_searchField;
        this.filter_searchFieldSlug = filter_searchFieldSlug;
        this.filter_searchText = filter_searchText;
        this.filter_secretTemplateId = filter_secretTemplateId;
        this.filter_siteId = filter_siteId;
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