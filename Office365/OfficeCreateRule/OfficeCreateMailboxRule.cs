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
    /// <summary>
    /// Class to create emailbox rules 
    /// </summary>
    public class OfficeCreateMailboxRule : IActivity
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

            MessageRulePredicates condition = new MessageRulePredicates();
            MessageRuleActions actions = new MessageRuleActions();

            GraphServiceClient client = new GraphServiceClient("https://graph.microsoft.com/v1.0", GetProvider());
            var user = client.Users[GetUserId(client)];
            var rules = user.MailFolders["Inbox"].MessageRules.Request().GetAsync().Result;

            if (rules.Where(r => r.DisplayName.ToLower() == ruleDisplayName.ToLower()).FirstOrDefault() != null)
                throw new Exception(string.Format("Rule with name '{0}' already exist", ruleDisplayName));

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

            messageRule.Conditions = condition;
            messageRule.Actions = actions;
            messageRule.Actions.StopProcessingRules =
            messageRule.IsEnabled = true;
            messageRule.Sequence = rules.Count + 1;
            
            user.MailFolders["Inbox"].MessageRules.Request().AddAsync(messageRule).Wait();

			dt.Rows.Add(messageRule.Id);
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
