using System;
using System.Data;
using System.Linq;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Graph.Auth;

namespace Ayehu.Sdk.ActivityCreation
{
    public class OfficeUpdateUser : IActivity
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
        /// User email that identifies the account
        /// </summary>
        public string userEmail;

        public string firstName;
        public string lastName;
        public string password;

        public ICustomActivityResult Execute()
        {
            GraphServiceClient client = new GraphServiceClient("https://graph.microsoft.com/v1.0", GetProvider());
            string userId = GetUserId(client);
            User user = client.Users[userId].Request().GetAsync().Result;

            if (user.UserPrincipalName != null)
            {
                var updateduser = new User();

                if (!string.IsNullOrEmpty(firstName))
                    updateduser.GivenName = firstName;

                if (!string.IsNullOrEmpty(lastName))
                    updateduser.Surname = lastName;

                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                    updateduser.DisplayName = firstName + " " + lastName;

                if (!string.IsNullOrEmpty(password))
                    updateduser.PasswordProfile = new PasswordProfile { Password = password, ForceChangePasswordNextSignIn = false };

                client.Users[userId].Request().UpdateAsync(updateduser).Wait();
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

        private string GetUserId(GraphServiceClient client)
        {
            var users = client.Users.Request().GetAsync().Result.ToList();

            foreach (var user in users)
            {
                if (user.Mail != null && user.Mail.ToLower() == userEmail.ToLower())
                {
                    return user.Id;
                }
            }

            return string.Empty;
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
