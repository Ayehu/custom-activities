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

namespace AzureGetRoleIdByName
{
    class AzureGetRoleIdByName : IActivity
    {
        public string tenantId;
        public string clientId;
        public string clientSecret;
        public string subscriptionId;
        public string roleName;

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

            string apiURL = "https://management.azure.com/subscriptions/" + subscriptionId + "/providers/Microsoft.Authorization/roleDefinitions?$filter=roleName eq '" + roleName + "'&api-version=2015-07-01";

            HttpWebRequest request1 = (HttpWebRequest)HttpWebRequest.Create(apiURL);
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

                    JArray roleDefinitions = (JArray)jsonResults1["value"];

                    int roleDefinitionCount = roleDefinitions.Count;

                    if(roleDefinitionCount == 0)
                    {
                        return this.GenerateActivityResult("Empty");
                    }
                    else
                    {
                        DataTable dt = new DataTable("resultSet");

                        for(int i = 0; i < roleDefinitionCount; i ++)
                        {
                            dt.Rows.Add(dt.NewRow());

                            JObject roleDetails = JObject.Parse(jsonResults1["value"][i].ToString());

                            foreach(JProperty property in roleDetails.Properties())
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