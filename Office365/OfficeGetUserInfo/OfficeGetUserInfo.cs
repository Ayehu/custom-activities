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
    public class OfficeGetUserInfo : IActivity
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
        /// User's email to retrieve the information
        /// </summary>
        public string userEmail;

        public ICustomActivityResult Execute()
        {
            GraphServiceClient client = new GraphServiceClient("https://graph.microsoft.com/v1.0", GetProvider());
            var user = client.Users[GetUserId(client)].Request().GetAsync().Result;

            if (!string.IsNullOrEmpty(user.UserPrincipalName))
            {
                DataTable dt = new DataTable("resultSet");
                dt.Columns.Add("Id");
                dt.Columns.Add("Mail");
                dt.Columns.Add("UserPrincipalName");
                dt.Columns.Add("Surname");
                dt.Columns.Add("GivenName");
                dt.Columns.Add("UserType");
                dt.Columns.Add("MobilePhone");
                dt.Columns.Add("OfficeLocation");
                dt.Columns.Add("LicenseDetails");
                dt.Columns.Add("Settings");
                dt.Columns.Add("AccountEnabled");

                dt.Rows.Add(
                    user.Id,
                    user.Mail,
                    user.UserPrincipalName,
                    user.Surname,
                    user.GivenName,
                    user.UserType,
                    user.MobilePhone,
                    user.OfficeLocation,
                    user.LicenseDetails,
                    user.Settings,
                    user.AccountEnabled);

                return this.GenerateActivityResult(dt);
            }
            else
                throw new Exception("User not found");
        }

        /// <summary>
        /// Get the authentication provider to be used for API calls
        /// </summary>
        /// <returns><code>ClientCredentialProvider</code></returns>
        private ClientCredentialProvider GetProvider()
        {
            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create(appId)
                .WithTenantId(tenantId)
                .WithClientSecret(secret)
                .Build();

            return new ClientCredentialProvider(confidentialClientApplication);
        }

        private SubscribedSku GetLicense(GraphServiceClient client)
        {
            var skuResult = client.SubscribedSkus.Request().GetAsync().Result;
            return skuResult[0];
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
    }
}
