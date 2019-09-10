using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Graph.Auth;
using System.Data;

namespace Ayehu.Sdk.ActivityCreation
{
    /// <summary>
    /// Creates an user in Azure Active Directory
    /// </summary>
    public class CreateOffice365User : IActivity
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
        /// The general format is alias@domain, where domain must be present in the tenant’s collection
        /// of verified domains. This property is required when a user is created.
        /// </summary>
        public string userPrincipalName;

        /// <summary>
        /// First Name
        /// </summary>
        public string surname;

        /// <summary>
        /// Last Name
        /// </summary>
        public string givenName;

        /// <summary>
        /// Nik Name/Display Name
        /// </summary>
        public string displayName;

        /// <summary>
        /// User's password.
        /// By default, a strong password is required.
        /// </summary>
        /// <see cref="PasswordPolicies"/>
        public string password;

        /// <summary>
        /// Create an user account Enabled if the value is set to True
        /// </summary>
        public bool isAccountEnabled;

        /// <summary>
        /// User must change password at next login if value is set to True
        /// </summary>
        public bool forcePwdChange;

        ICustomActivityResult IActivity.Execute()
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");

            
            GraphServiceClient client = new GraphServiceClient("https://graph.microsoft.com/v1.0", GetProvider());

            var user = client.Users.Request().AddAsync(new User
            {
                AccountEnabled = isAccountEnabled,
                DisplayName = givenName + " " + surname,
                Surname = surname,
                GivenName = givenName,
                MailNickname = givenName + surname,
                UserPrincipalName = userPrincipalName,
                PasswordProfile = new PasswordProfile
                {
                    ForceChangePasswordNextSignIn = forcePwdChange,
                    Password = password
                }
            }).Result;

            dt.Rows.Add("Success");
            
            return this.GenerateActivityResult(dt);
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
    }
}
