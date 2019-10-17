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
    public class OfficeDeleteMailboxRule : IActivity
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

        /// <summary>
        /// Rule name to delete
        /// </summary>
        public string ruleName;

        public ICustomActivityResult Execute()
        {
            GraphServiceClient client = new GraphServiceClient("https://graph.microsoft.com/v1.0", GetProvider());
            var user = client.Users[GetUserId(client)];

            if (user.Request().GetAsync().Result != null)
            {
                var messageRule = user.MailFolders["Inbox"].MessageRules.Request().GetAsync().
                    Result.Where(r => r.DisplayName.ToLower() == ruleName.ToLower()).FirstOrDefault();

                if (messageRule != null)
                {
                    user.MailFolders["Inbox"].MessageRules[messageRule.Id].Request().DeleteAsync().Wait();
                }
                else
                {
                    throw new Exception(string.Format("Mail rule with name '{0}' not found", ruleName));
                }
            }
            else
            {
                throw new Exception(string.Format("User with userEmail '{0}' not found", userEmail));
            }

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
