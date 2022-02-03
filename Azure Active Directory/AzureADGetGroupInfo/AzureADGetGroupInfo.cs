using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.IO;
using System.Net;

namespace Ayehu.Sdk.ActivityCreation
{
    public class OfficeGetGroupInfo : IActivity
    {
        /// <summary>
        /// APPLICATION (CLIENT) ID
        /// </summary>
        public string appId;

        /// <summary>
        /// Directory (tenant) ID
        /// </summary>
        public string tenantId;

        /// <summary>
        /// Client secret
        /// </summary>
        /// <remarks>
        /// A secret string that the application uses to prove its identity when requesting a token. 
        /// Also can be referred to as application password.
        /// </remarks>
        public string secret_password;

        /// <summary>
        /// Group name to retrieve the information
        /// </summary>
        public string groupName;

        public ICustomActivityResult Execute()
        {
            string token = GetToken();

            if (string.IsNullOrEmpty(token))
                throw new Exception("Cannot get Access token.");

            return this.GenerateActivityResult(GetGroup(token));
        }

        private DataTable GetGroup(string token)
        {
            string getGroupUrl = string.Format("https://graph.microsoft.com/v1.0/groups?$filter=displayName eq '{0}'", groupName);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(getGroupUrl);
            request.Method = "GET";
            request.Headers.Add("Authorization", token);
            request.Accept = "application/json";
            request.ContentType = "application/json";
            var response = (HttpWebResponse)request.GetResponse();

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            { 
                var json = (JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());
                var group = json.Value<JToken>("value").First;
                DataTable dt = new DataTable("resultSet");

                if (group != null)
                {
                    dt.Columns.Add("Id");
                    dt.Columns.Add("Type");
                    dt.Columns.Add("IsEmailGroup");

                    string type = Convert.ToBoolean(group.Value<string>("securityEnabled")) ? "SecurityGroup" : "Office365";
                    string id = group.Value<string>("id");
                    bool mailEnabled = Convert.ToBoolean(group.Value<string>("mailEnabled"));
                    dt.Rows.Add(id, type, mailEnabled);
                }

                return dt;
            }
        }

        private string GetToken()
        {
            System.Collections.Generic.List<string> scopes = new System.Collections.Generic.List<string> { { "https://graph.microsoft.com/.default" } };
            var app = ConfidentialClientApplicationBuilder.Create(appId).
                WithTenantId(tenantId)
                .WithClientSecret(secret_password)
                .Build();
            var authResult = app.AcquireTokenForClient(scopes).ExecuteAsync().Result;

            if (authResult != null)
                return authResult.AccessToken;
            else
                return "";
        }
    }
}
