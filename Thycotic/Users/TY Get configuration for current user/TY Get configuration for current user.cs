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
    public class CustomActivity_TY_Get_configuration_for_current_user : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string dirty = "";
    
    public string value = "";
    
    public string displayName_dirty = "";
    
    public string displayName_value = "";
    
    public string duoTwoFactor_dirty = "";
    
    public string duoTwoFactor_value = "";
    
    public string emailAddress_dirty = "";
    
    public string emailAddress_value = "";
    
    public string enabled_dirty = "";
    
    public string enabled_value = "";
    
    public string fido2TwoFactor_dirty = "";
    
    public string fido2TwoFactor_value = "";
    
    public string groupOwners__ = "";
    
    public string _id = "";
    
    public string isApplicationAccount_dirty = "";
    
    public string isApplicationAccount_value = "";
    
    public string isGroupOwnerUpdate = "";
    
    public string isLockedOut_dirty = "";
    
    public string isLockedOut_value = "";
    
    public string loginFailures_dirty = "";
    
    public string loginFailures_value = "";
    
    public string oathTwoFactor_dirty = "";
    
    public string oathTwoFactor_value = "";
    
    public string password_dirty = "";
    
    public string password_value = "";
    
    public string radiusTwoFactor_dirty = "";
    
    public string radiusTwoFactor_value = "";
    
    public string radiusUserName_dirty = "";
    
    public string radiusUserName_value = "";
    
    public string timeOptionId_dirty = "";
    
    public string timeOptionId_value = "";
    
    public string twoFactor_dirty = "";
    
    public string twoFactor_value = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "PATCH";
    
    private string uriBuilderPath {
        get {
            return string.Format("SecretServer/api/v1/users/{0}",id_p);
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"dateOptionId\": {{   \"dirty\": \"{0}\",    \"value\": \"{1}\"   }},  \"displayName\": {{   \"dirty\": \"{2}\",    \"value\": \"{3}\"   }},  \"duoTwoFactor\": {{   \"dirty\": \"{4}\",    \"value\": \"{5}\"   }},  \"emailAddress\": {{   \"dirty\": \"{6}\",    \"value\": \"{7}\"   }},  \"enabled\": {{   \"dirty\": \"{8}\",    \"value\": \"{9}\"   }},  \"fido2TwoFactor\": {{   \"dirty\": \"{10}\",    \"value\": \"{11}\"   }},  \"id\": \"{12}\",  \"isApplicationAccount\": {{   \"dirty\": \"{13}\",    \"value\": \"{14}\"   }},  \"isGroupOwnerUpdate\": \"{15}\",  \"isLockedOut\": {{   \"dirty\": \"{16}\",    \"value\": \"{17}\"   }},  \"loginFailures\": {{   \"dirty\": \"{18}\",    \"value\": \"{19}\"   }},  \"oathTwoFactor\": {{   \"dirty\": \"{20}\",    \"value\": \"{21}\"   }},  \"password\": {{   \"dirty\": \"{22}\",    \"value\": \"{23}\"   }},  \"radiusTwoFactor\": {{   \"dirty\": \"{24}\",    \"value\": \"{25}\"   }},  \"radiusUserName\": {{   \"dirty\": \"{26}\",    \"value\": \"{27}\"   }},  \"timeOptionId\": {{   \"dirty\": \"{28}\",    \"value\": \"{29}\"   }},  \"twoFactor\": {{   \"dirty\": \"{30}\",    \"value\": \"{31}\"   }} }}",dirty,value,displayName_dirty,displayName_value,duoTwoFactor_dirty,duoTwoFactor_value,emailAddress_dirty,emailAddress_value,enabled_dirty,enabled_value,fido2TwoFactor_dirty,fido2TwoFactor_value,_id,isApplicationAccount_dirty,isApplicationAccount_value,isGroupOwnerUpdate,isLockedOut_dirty,isLockedOut_value,loginFailures_dirty,loginFailures_value,oathTwoFactor_dirty,oathTwoFactor_value,password_dirty,password_value,radiusTwoFactor_dirty,radiusTwoFactor_value,radiusUserName_dirty,radiusUserName_value,timeOptionId_dirty,timeOptionId_value,twoFactor_dirty,twoFactor_value);
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