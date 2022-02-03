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
    public class TY_Update_User : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string dateOptionId = "";
    
    public string displayName_p = "";
    
    public string duoTwoFactor = "";
    
    public string emailAddress = "";
    
    public string enabled = "";
    
    public string fido2TwoFactor = "";
    
    public string _id = "";
    
    public string isApplicationAccount = "";
    
    public string isGroupOwnerUpdate = "";
    
    public string isLockedOut = "";
    
    public string loginFailures = "";
    
    public string oathTwoFactor = "";
    
    public string password = "";
    
    public string radiusTwoFactor = "";
    
    public string radiusUserName = "";
    
    public string timeOptionId = "";
    
    public string twoFactor = "";
    
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
_uriBuilderPath = string.Format("SecretServer/api/v1/users/{0}",id_p);
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
_postData = string.Format("{{ \"dateOptionId\": \"{0}\",  \"displayName\": \"{1}\",  \"duoTwoFactor\": \"{2}\",  \"emailAddress\": \"{3}\",  \"enabled\": \"{4}\",  \"fido2TwoFactor\": \"{5}\",  \"id\": \"{6}\",  \"isApplicationAccount\": \"{7}\",  \"isGroupOwnerUpdate\": \"{8}\",  \"isLockedOut\": \"{9}\",  \"loginFailures\": \"{10}\",  \"oathTwoFactor\": \"{11}\",  \"password\": \"{12}\",  \"radiusTwoFactor\": \"{13}\",  \"radiusUserName\": \"{14}\",  \"timeOptionId\": \"{15}\",  \"twoFactor\": \"{16}\" }}",dateOptionId,displayName_p,duoTwoFactor,emailAddress,enabled,fido2TwoFactor,_id,isApplicationAccount,isGroupOwnerUpdate,isLockedOut,loginFailures,oathTwoFactor,password,radiusTwoFactor,radiusUserName,timeOptionId,twoFactor);
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
    
    public TY_Update_User() {
    }
    
    public TY_Update_User(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string id_p, 
                string dateOptionId, 
                string displayName_p, 
                string duoTwoFactor, 
                string emailAddress, 
                string enabled, 
                string fido2TwoFactor, 
                string _id, 
                string isApplicationAccount, 
                string isGroupOwnerUpdate, 
                string isLockedOut, 
                string loginFailures, 
                string oathTwoFactor, 
                string password, 
                string radiusTwoFactor, 
                string radiusUserName, 
                string timeOptionId, 
                string twoFactor) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.id_p = id_p;
        this.dateOptionId = dateOptionId;
        this.displayName_p = displayName_p;
        this.duoTwoFactor = duoTwoFactor;
        this.emailAddress = emailAddress;
        this.enabled = enabled;
        this.fido2TwoFactor = fido2TwoFactor;
        this._id = _id;
        this.isApplicationAccount = isApplicationAccount;
        this.isGroupOwnerUpdate = isGroupOwnerUpdate;
        this.isLockedOut = isLockedOut;
        this.loginFailures = loginFailures;
        this.oathTwoFactor = oathTwoFactor;
        this.password = password;
        this.radiusTwoFactor = radiusTwoFactor;
        this.radiusUserName = radiusUserName;
        this.timeOptionId = timeOptionId;
        this.twoFactor = twoFactor;
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