using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net;

namespace AzureResourceExists
{
    class AzureResourceExists : IActivity
    {
        public string tenantId;
        public string clientId;
        public string clientSecret;
        public string subscriptionId;
        public string resourceId;

        public ICustomActivityResult Execute()
        {
            string latestAPI = String.Empty;

            string[] elements = resourceId.Split('/');

            string provider = elements[6];

            string resource = String.Empty;

            if(elements.Length == 11)
            {
                resource = elements[7] + "/" + elements[9];
            }
            else if(elements.Length == 13)
            {
                resource = elements[7] + "/" + elements[9] + "/" + elements[11];
            }
            else if(elements.Length == 15)
            {
                resource = elements[7] + "/" + elements[9] + "/" + elements[11] + "/" + elements[13];
            }
            else
            {
                resource = elements[7];
            }
            
            string authContextURL = "https://login.windows.net/" + tenantId;
            var authenticationContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authContextURL);
            var credential = new ClientCredential(clientId, clientSecret);
            var result = authenticationContext.AcquireTokenAsync(resource: "https://management.azure.com/", clientCredential: credential).Result;

            if (result == null)
            {
                return this.GenerateActivityResult("Failed to obtain JWT token.");
            }

            string token = result.AccessToken;

            HttpWebRequest request1 = (HttpWebRequest)HttpWebRequest.Create("https://management.azure.com/subscriptions/" + subscriptionId + "/providers/" + provider + "?api-version=2015-01-01");
            request1.Method = "GET";
            request1.Headers["Authorization"] = "Bearer " + token;
            request1.ContentType = "application/json";

            try
            {
                var response1 = (HttpWebResponse)request1.GetResponse();
                
                using(var streamReader1 = new StreamReader(response1.GetResponseStream()))
                {
                    var responseString1 = streamReader1.ReadToEnd();

                    JObject jsonResults1 = JObject.Parse(responseString1);

                    JArray resourceTypes = (JArray)jsonResults1["resourceTypes"];

                    int resourceTypeCount = resourceTypes.Count;

                    for(int i = 0; i < resourceTypeCount; i ++)
                    {
                        if(jsonResults1["resourceTypes"][i]["resourceType"].ToString() == resource)
                        {
                            latestAPI = jsonResults1["resourceTypes"][i]["apiVersions"][0].ToString();
                        }
                    }
                }
            }
            catch(WebException e)
            {
                return this.GenerateActivityResult("Error (" + e.Message + ")");
            }
            
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://management.azure.com" + resourceId + "?api-version=" + latestAPI);
            request.Method = "GET";
            request.Headers["Authorization"] = "Bearer " + token;
            request.ContentType = "application/json";

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                
                using(var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var responseString = streamReader.ReadToEnd();

                    return this.GenerateActivityResult("True");
                }
            }
            catch(WebException e)
            {
                return this.GenerateActivityResult("False");
            }
        }
    }
}
