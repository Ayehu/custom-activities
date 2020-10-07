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
    public class CustomActivity_TY_Search_Recorded_Sessions : IActivityAsync
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
    
    private string uriBuilderPath {
        get {
            return "SecretServer/api/v1/recorded-sessions";
        }
    }
    
    private string postData {
        get {
            return "";
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> headers {
        get {
            return new Dictionary<string, string>() {{"Authorization","Bearer " + password1}};
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> queryStringArray {
        get {
            return new Dictionary<string, string>() {{"filter.active",filter_active},{"filter.dateRange",filter_dateRange},{"filter.endDate",filter_endDate},{"filter.endTime",filter_endTime},{"filter.folderId",filter_folderId},{"filter.groupIds[]",filter_groupIds},{"filter.includeNonSecretServerSessions",filter_includeNonSecretServerSessions},{"filter.includeOnlyLaunchedSuccessfully",filter_includeOnlyLaunchedSuccessfully},{"filter.includeRestricted",filter_includeRestricted},{"filter.includeSubFolders",filter_includeSubFolders},{"filter.launcherTypeId",filter_launcherTypeId},{"filter.searchText",filter_searchText},{"filter.searchTypes[]",filter_searchTypes},{"filter.secretIds[]",filter_secretIds},{"filter.siteId",filter_siteId},{"filter.startDate",filter_startDate},{"filter.startTime",filter_startTime},{"filter.userIds[]",filter_userIds},{"skip",skip},{"sortBy[0].direction",sortBy_0__direction},{"sortBy[0].name",sortBy_0__name},{"sortBy[0].priority",sortBy_0__priority},{"take",take}};
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