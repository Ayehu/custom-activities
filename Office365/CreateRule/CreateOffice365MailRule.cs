using System;
using System.Data;
using System.Collections.Generic;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Graph.Auth;

namespace Ayehu.Sdk.ActivityCreation
{
    /// <summary>
    /// Class to create emailbox rules 
    /// </summary>
    public class CreateOffice365MailRule : IActivity
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
        /// Rule name
        /// </summary>
        public string ruleDisplayName;

        /// <summary>
        /// Apply the rule if sender contains this string
        /// </summary>
        public string senderContains;

        /// <summary>
        /// Apply the rule if body contains this string
        /// </summary>
        public string bodyContains;

        /// <summary>
        /// Indicates that email have to be forwarded
        /// </summary>
        public bool forwardAction;

        /// <summary>
        /// Forward email to the specified email address
        /// </summary>
        public string forwardEmail;

        /// <summary>
        /// Indicates that email have to be deleted
        /// </summary>
        public bool deleteAction;

        public ICustomActivityResult Execute()
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");
            dt.Rows.Add("Success");

            GraphServiceClient client = new GraphServiceClient("https://graph.microsoft.com/v1.0", GetProvider());
            var user = client.Users[userId];

            MessageRulePredicates condition = new MessageRulePredicates();
            MessageRuleActions actions = new MessageRuleActions();

            var messageRule = new MessageRule
            {
                DisplayName = ruleDisplayName,
                IsEnabled = true
            };

            if (!string.IsNullOrEmpty(senderContains))
            {
                condition.SenderContains = new List<string>() { senderContains };
            }

            if (!string.IsNullOrEmpty(bodyContains))
            {
                condition.BodyContains = new List<string>() { bodyContains };
            }

            if (forwardAction)
            {
                if (string.IsNullOrEmpty(forwardEmail))
                    throw new Exception("forwardEmail field must be populated when forwardAction is set to True");

                actions.ForwardTo = new List<Recipient>()
                {
                    new Recipient
                    {
                        EmailAddress = new EmailAddress
                        {
                            Address = forwardEmail
                        }
                    }
                };
            }
            else if (deleteAction)
            {
                actions.Delete = true;
            }

            if (string.IsNullOrEmpty(user.Request().GetAsync().Result.UsageLocation))
            {
                this.UpdateUser(user);
            }

            int rules = user.MailFolders["inbox"].MessageRules.Request().GetAsync().Result.Count;

            messageRule.Conditions = condition;
            messageRule.Actions = actions;
            messageRule.Actions.StopProcessingRules =
            messageRule.IsEnabled = true;
            messageRule.Sequence = rules + 1;
            
            user.MailFolders["Inbox"].MessageRules.Request().AddAsync(messageRule).Wait();

            return this.GenerateActivityResult(dt);
        }

        /// <summary>
        /// Set UsageLocation field. It's required when adding maibox rule.
        /// </summary>
        /// <param name="user">Current instance of user</param>
        private void UpdateUser(IUserRequestBuilder user)
        {
            user.Request().UpdateAsync(new User
            {
                UsageLocation = "US"
            }).Wait();
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
