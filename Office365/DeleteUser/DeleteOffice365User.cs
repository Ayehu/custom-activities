using System;
using System.Data;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Graph.Auth;

namespace Ayehu.Sdk.ActivityCreation
{
    /// <summary>
    /// Deletes an user in Azure Active Directory
    /// </summary>
    public class DeleteOffice365User : IActivity
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
        /// GUID that identifies the current user.
        /// </summary>
        public string userId;

        /// <summary>
        /// The general format is alias@domain, where domain must be present in the tenant’s collection
        /// of verified domains. This property is required when a user is created.
        /// </summary>
        public string userPrincipalName;

        public ICustomActivityResult Execute()
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");
            DataRow dr = dt.NewRow();

            try
            {
                IUserRequest user = null;
                GraphServiceClient client = new GraphServiceClient("https://graph.microsoft.com/v1.0", GetProvider());

                string id = !string.IsNullOrEmpty(userId) ? userId : userPrincipalName;
                user = client.Users[id].Request();

                if (user != null)
                {
                    // Delete the user.
                    user.DeleteAsync();
                    dt.Rows.Add("SUCCESS");
                }
                else
                    throw new Exception();
            }
            catch
            {
                dt.Rows.Add("FAIL");
            }

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
