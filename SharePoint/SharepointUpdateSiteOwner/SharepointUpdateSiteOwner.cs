using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using System;
using System.Data;
using System.Linq;
using System.Security;

namespace Ayehu.Sdk.ActivityCreation
{
    public class SharePointUpdateSiteOwner : IActivity
    {
        /// <summary>
        /// The SharePoint base URL
        /// </summary>
        public string InstanceURL;

        /// <summary>
        /// SharePoint Site to add user to.
        /// </summary>
        /// <remarks>If it's the root website, then leave it empty.</remarks>
        public string Site;

        /// <summary>
        /// Username used to login in admin panel of SharePoint instance
        /// </summary>
        public string UserName;

        /// <summary>
        /// Password used to login in admin panel of SharePoint instance
        /// </summary>
        public string Password;

        /// <summary>
        /// User full login name as defined in the Domain or Azure Active Directory
        /// </summary>
        public string UserLogonName;

        public ICustomActivityResult Execute()
        {
            bool removeSiteAdmin = false;

            using (ClientContext adminContext = new ClientContext(InstanceURL))
            {
                SetCredentials(adminContext);
                var tenant = new Tenant(adminContext);
                NormalizeURL();
                string instanceUrl = InstanceURL.Replace("-admin", "");
               
                using (ClientContext clientContext = new ClientContext(instanceUrl))
                {
                    SetCredentials(clientContext);

                    try
                    {
                        var currentUser = clientContext.Web.CurrentUser;
                        clientContext.Load(currentUser);
                        clientContext.ExecuteQuery();
                    }
                    catch (System.Net.WebException)
                    {
                        // add current user as site admin so it have enough rights to upload a file
                        tenant.SetSiteAdmin(instanceUrl, UserName, true);
                        adminContext.ExecuteQuery();
                        removeSiteAdmin = true;
                    }

                    var user = clientContext.Web.EnsureUser(UserLogonName);
                    clientContext.Load(user);
                    clientContext.ExecuteQuery();

                    if (user != null)
                    {
                        clientContext.Site.Owner = user;
                        clientContext.Site.Owner.Update();
                        clientContext.ExecuteQuery();

                        var groups = clientContext.Web.SiteGroups;
                        clientContext.Load(groups);
                        clientContext.ExecuteQuery();

                        foreach (var group in groups)
                        {
                            group.Owner = user;
                            group.Update();
                        }

                        if (removeSiteAdmin)
                        {
                            // reset the site admin
                            tenant.SetSiteAdmin(instanceUrl, UserName, false);
                            adminContext.ExecuteQuery();
                        }

                        DataTable dt = new DataTable("resultSet");
                        dt.Columns.Add("Result");
                        dt.Rows.Add("Success");
                        return this.GenerateActivityResult(dt);
                    }

                    throw new Exception(string.Format("User '{0}' not found.", UserLogonName));
                }
            }
        }

        private void NormalizeURL()
        {
            if (!Site.StartsWith("sites") && !Site.StartsWith("/sites"))
                Site = "sites/" + Site;

            if (InstanceURL.EndsWith("/"))
                InstanceURL = InstanceURL + Site;
            else
                InstanceURL = InstanceURL + "/" + Site;
        }

        private void SetCredentials(ClientContext ctx)
        {
            SecureString secureString = new SecureString();
            Password.ToList().ForEach(secureString.AppendChar);
            ctx.AuthenticationMode = ClientAuthenticationMode.Default;
            ctx.Credentials = new SharePointOnlineCredentials(UserName, secureString);
        }
    }
}
