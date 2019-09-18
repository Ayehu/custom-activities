using System;
using System.Data;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Graph.Auth;
using System.Collections.Generic;

namespace ActivityCreator.Users
{
    public class OfficeAssignUserLicense : IActivity
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

        ICustomActivityResult IActivity.Execute()
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");
            dt.Rows.Add("Success");

            GraphServiceClient client = new GraphServiceClient("https://graph.microsoft.com/v1.0", GetProvider());
            var user = client.Users[userId];
            Guid? skuId = GetLicense(client).SkuId;

            user.AssignLicense(new List<AssignedLicense>
            {
                new AssignedLicense { SkuId = skuId }
            },
               new List<Guid>()).Request().PostAsync().Wait();

            return this.GenerateActivityResult(dt);
        }

        private SubscribedSku GetLicense(GraphServiceClient client)
        {
            var skuResult = client.SubscribedSkus.Request().GetAsync().Result;
            return skuResult[0];
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
