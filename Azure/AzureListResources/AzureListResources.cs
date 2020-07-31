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

namespace AzureListResources
{
    class AzureListResources : IActivity
    {
        public string tenantId;
        public string clientId;
        public string clientSecret;
        public string subscriptionId;

        public ICustomActivityResult Execute()
        {            
            string authContextURL = "https://login.windows.net/" + tenantId;
            var authenticationContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authContextURL);
            var credential = new ClientCredential(clientId, clientSecret);
            var result = authenticationContext.AcquireTokenAsync(resource: "https://management.azure.com/", clientCredential: credential).Result;
            
            if (result == null)
            {
                return this.GenerateActivityResult("Failed to obtain JWT token.");
            }
            
            string token = result.AccessToken;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://management.azure.com/subscriptions/" + subscriptionId + "/resources?api-version=2019-10-01");
            request.Method = "GET";
            request.Headers["Authorization"] = "Bearer " + token;
            request.ContentType = "application/json";

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                
                using(var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var responseString = streamReader.ReadToEnd();

                    JObject jsonResults = JObject.Parse(responseString);

                    JArray resources = (JArray)jsonResults["value"];

                    int resoureCount = resources.Count;

                    if(resoureCount == 0)
                    {
                        return this.GenerateActivityResult("Empty");
                    }
                    else
                    {
                        DataTable dt = new DataTable("resultSet");

                        for(int i = 0; i < resoureCount; i ++)
                        {
                            dt.Rows.Add(dt.NewRow());

                            JObject resourceDetails = JObject.Parse(jsonResults["value"][i].ToString());

                            foreach(JProperty property in resourceDetails.Properties())
                            {
                                if(!dt.Columns.Contains(property.Name))
                                {
                                    dt.Columns.Add(property.Name);
                                }

                                dt.Rows[i][property.Name] = property.Value;
                            }
                        }

                        return this.GenerateActivityResult(dt);
                    }
                }
            }
            catch(WebException e)
            {
                return this.GenerateActivityResult("Error (" + e.Message + ")");
            }
        }
    }
}