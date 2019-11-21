using System;
using System.Data;
using System.Linq;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureADGetAllObjects : IActivity
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
        /// Type of the object to filter
        /// </summary>
        public string typeId;

        public ICustomActivityResult Execute()
        {
            var auth = GetAuthenticated();
            var virtualMachines = auth.WithDefaultSubscription().VirtualMachines.List().ToList();
            var groups = auth.ActiveDirectoryGroups.List();
            var users = auth.ActiveDirectoryUsers.List();

            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Id");
            dt.Columns.Add("Type");
            dt.Columns.Add("Member Name");
            dt.Columns.Add("Member Details");

            switch (typeId)
            {
                case "user":
                    {
                        users.ToList().ForEach(u =>
                        {
                            dt.Rows.Add(u.Id, "User", u.Name, u.UserPrincipalName);
                        });

                        break;
                    }
                case "group":
                    {
                        groups.ToList().ForEach(g =>
                        {
                            dt.Rows.Add(g.Id, "Group", g.Name, g.SecurityEnabled ? "SecurityGroup" : "Office365");
                        });

                        break;
                    }
                default:
                    {
                        users.ToList().ForEach(u =>
                        {
                            dt.Rows.Add(u.Id, "User", u.Name, u.UserPrincipalName);
                        });

                        groups.ToList().ForEach(g =>
                        {
                            dt.Rows.Add(g.Id, "Group", g.Name, g.SecurityEnabled ? "SecurityGroup" : "Office365");
                        });

                        virtualMachines.ForEach(vm =>
                        {
                            dt.Rows.Add(vm.Id, "Virtual Machine", vm.Name, vm.OSType);
                        });

                        break;
                    }
            }

            return this.GenerateActivityResult(dt);
        }

        private Azure.IAuthenticated GetAuthenticated()
        {
            var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(appId, secret, tenantId, AzureEnvironment.AzureGlobalCloud);
            var azure = Azure
                   .Configure()
                   .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                   .Authenticate(credentials);

            return azure;
        }
    }
}
