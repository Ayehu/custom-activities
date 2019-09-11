using System;
using System.Data;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Graph.Auth;

namespace Ayehu.Sdk.ActivityCreation
{
    public class RemoveUserFromOffice365Group : IActivity
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
        public string secret;

        /// <summary>
        /// GUID that identifies the current user or can be the UserPrincipal Name.
        /// </summary>
        public string userId;
        /// <summary>
        /// Group GUID
        /// </summary>
        public string groupId;

        public ICustomActivityResult Execute()
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");

            GraphServiceClient client = new GraphServiceClient("https://graph.microsoft.com/v1.0", GetProvider());
            User user = client.Users[userId].Request().GetAsync().Result;

            if (user.UserPrincipalName != null)
            {
                client.Groups[groupId].Members[user.Id].Reference.Request().DeleteAsync();
                dt.Rows.Add("Success");
            }
            else
                throw new Exception("User not found");

            return this.GenerateActivityResult(dt);
        }

        private ClientCredentialProvider GetProvider()
        {
            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create(appId)
                .WithTenantId(tenantId)
                .WithClientSecret(secret)
                .Build();

            return new ClientCredentialProvider(confidentialClientApplication);
        }
    }
}
