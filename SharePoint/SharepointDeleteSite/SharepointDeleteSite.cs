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
    public class SharePointDeleteSite : IActivity
    {
        /// <summary>
        /// The SharePoint admin base URL
        /// </summary>
        public string InstanceAdminURL;

        /// <summary>
        /// Username used to login in admin panel of SharePoint instance
        /// </summary>
        public string UserName;

        /// <summary>
        /// Password used to login in admin panel of SharePoint instance
        /// </summary>
        public string Password;

        /// <summary>
        /// The site name to delete
        /// </summary>
        public string Site;

        public ICustomActivityResult Execute()
        {
            try
            {
                using (ClientContext clientContext = new ClientContext(InstanceAdminURL))
                {
                    SecureString secureString = new SecureString();
                    Password.ToList().ForEach(secureString.AppendChar);
                    clientContext.AuthenticationMode = ClientAuthenticationMode.Default;
                    clientContext.Credentials = new SharePointOnlineCredentials(UserName, secureString);
                    
                    NormalizeURL();
                    var tenant = new Tenant(clientContext);
                    string instanceUrl = InstanceAdminURL.Replace("-admin", "");
                    tenant.RemoveSite(instanceUrl);
					tenant.RemoveDeletedSite(instanceUrl);
                    clientContext.ExecuteQuery();
                }

                return this.GenerateActivityResult(GetActivityResult);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Error deleting site '{0}'. {1}", Site, e.Message));
            }
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

        private void NormalizeURL()
        {
            if (!Site.StartsWith("sites") && !Site.StartsWith("/sites"))
                Site = "sites/" + Site;

            if (InstanceAdminURL.EndsWith("/"))
                InstanceAdminURL = InstanceAdminURL + Site;
            else
                InstanceAdminURL = InstanceAdminURL + "/" + Site;
        }
    }
}
