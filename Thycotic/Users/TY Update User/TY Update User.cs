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
    public class CustomActivity_TY_Update_User : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string dateOptionId = "";
    
    public string displayName = "";
    
    public string duoTwoFactor = "";
    
    public string emailAddress = "";
    
    public string enabled = "";
    
    public string fido2TwoFactor = "";
    
    public string groupOwners__ = "";
    
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
    
    private string uriBuilderPath {
        get {
            return string.Format("SecretServer/api/v1/users/{0}",id_p);
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"dateOptionId\": \"{0}\",  \"displayName\": \"{1}\",  \"duoTwoFactor\": \"{2}\",  \"emailAddress\": \"{3}\",  \"enabled\": \"{4}\",  \"fido2TwoFactor\": \"{5}\",  \"id\": \"{6}\",  \"isApplicationAccount\": \"{7}\",  \"isGroupOwnerUpdate\": \"{8}\",  \"isLockedOut\": \"{9}\",  \"loginFailures\": \"{10}\",  \"oathTwoFactor\": \"{11}\",  \"password\": \"{12}\",  \"radiusTwoFactor\": \"{13}\",  \"radiusUserName\": \"{14}\",  \"timeOptionId\": \"{15}\",  \"twoFactor\": \"{16}\" }}",dateOptionId,displayName,duoTwoFactor,emailAddress,enabled,fido2TwoFactor,_id,isApplicationAccount,isGroupOwnerUpdate,isLockedOut,loginFailures,oathTwoFactor,password,radiusTwoFactor,radiusUserName,timeOptionId,twoFactor);
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> headers {
        get {
            return new Dictionary<string, string>() {{"Authorization","Bearer " + password1}};
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