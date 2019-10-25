using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Graph.Auth;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureADGetUserInfo : IActivity
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
        /// User's email to create the rule
        /// </summary>
        public string userEmail;

        public ICustomActivityResult Execute()
        {
            GraphServiceClient client = new GraphServiceClient("https://graph.microsoft.com/v1.0", GetProvider());
            var user = client.Users[GetUserId(client)];
            Guid? skuId = GetLicense(client).SkuId;

            if (user.Request().GetAsync().Result.UserPrincipalName != null)
            {
                var license = user.LicenseDetails.Request().GetAsync().Result.Where(l => l.SkuId == skuId).FirstOrDefault();

                if (license != null)
                    user.AssignLicense(new List<AssignedLicense>(), new List<Guid> { license.SkuId.Value }).Request().PostAsync().Wait();
                else
                    throw new Exception("User doesn't have any license assigned");
            }

            return this.GenerateActivityResult(GetActivityResult);
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
