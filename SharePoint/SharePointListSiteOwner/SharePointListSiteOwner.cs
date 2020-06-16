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
    public class SharePointListSiteOwner : IActivity
    {
        /// <summary>
        /// The SharePoint Admin base URL
        /// </summary>
        public string InstanceURL;

        /// <summary>
        /// SharePoint Site to get the owner information.
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

        public ICustomActivityResult Execute()
        {
            try
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
                    }
                    
                    var siteOwner = tenant.GetSiteByUrl(instanceUrl).Owner;
                    adminContext.Load(siteOwner);

                    if (removeSiteAdmin)
                    {
                        tenant.SetSiteAdmin(instanceUrl, UserName, false);
                        adminContext.ExecuteQuery();
                    }
                    
                    DataTable dt = new DataTable("resultSet");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Email");

                    dt.Rows.Add(siteOwner.Title, siteOwner.Email);
                    return this.GenerateActivityResult(dt);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving Owner information. " + e.Message);
            }
        }

        private void NormalizeURL()
        {
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
