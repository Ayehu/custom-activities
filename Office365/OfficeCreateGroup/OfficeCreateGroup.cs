using System;
using System.Data;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Graph.Auth;

namespace Ayehu.Sdk.ActivityCreation
{
    public class OfficeCreateGroup: IActivity
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
        /// Display name of the group
        /// </summary>
        public string groupName;
        
        /// <summary>
        /// An optional description
        /// </summary>
        public string groupDescription;
        /// <summary>
        /// The mail alias for the group. Must be unique in the organization
        /// </summary>
        public string groupMailNikName;

        public ICustomActivityResult Execute()
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");

            GraphServiceClient client = new GraphServiceClient("https://graph.microsoft.com/v1.0", GetProvider());
            var group = client.Groups.Request().AddAsync(new Group
            {
                GroupTypes = new System.Collections.Generic.List<string> { "Unified" },
                DisplayName = groupName,
                Description = groupDescription,
                MailNickname = groupMailNikName,                
                MailEnabled = true,
                SecurityEnabled = false
            }).Result;

            dt.Rows.Add(group.Id);

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
