using System;
using System.Data;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Graph.Auth;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureADResetUserPassword : IActivity
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
        /// New password
        /// </summary>
        public string password;

        /// <summary>
        /// User email that identifies the account
        /// </summary>
        public string userEmail;

        public ICustomActivityResult Execute()
        {
            GraphServiceClient client = new GraphServiceClient("https://graph.microsoft.com/v1.0", GetProvider());            
            User user = client.Users[userEmail].Request().GetAsync().Result;

            if (user != null && !string.IsNullOrEmpty(user.UserPrincipalName))
            {
                var updateduser = new User();

                if (!string.IsNullOrEmpty(password))
                {
                    updateduser.PasswordProfile = new PasswordProfile { Password = password, ForceChangePasswordNextSignIn = false };
                    client.Users[userEmail].Request().UpdateAsync(updateduser).Wait();
                }
                else
                    throw new Exception("Password can't be empty");
            }
            else
                throw new Exception("User not found");

            return this.GenerateActivityResult(GetActivityResult);
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

        private DataTable GetActivityResult
        {
            get
            {
                DataTable dt = new DataTable("resultSet");
                dt.Columns.Add("Result");
                dt.Rows.Add("Success");

                return dt;
            }
        }
    }
}