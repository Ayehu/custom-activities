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
    public class SharepointCreateSite : IActivity
    {
        /// <summary>
        /// The Sharepoint ADMIN base URL
        /// </summary>
        public string InstanceAdminURL;

        /// <summary>
        /// The new site name
        /// </summary>
        public string SiteName;

        /// <summary>
        /// The title of the new Site
        /// </summary>
        public string SiteTitle;

        /// <summary>
        /// The email of the user as defined in Active Directory
        /// </summary>
        public string SiteOwnerLogin;

        /// <summary>
        /// The template to create site from
        /// </summary>
        public string SiteTemplate;

        /// <summary>
        /// Username used to login in admin panel of Sharepoint instance
        /// </summary>
        public string UserName;

        /// <summary>
        /// Password used to login in admin panel of Sharepoint instance
        /// </summary>
        public string Password;

        public ICustomActivityResult Execute()
        {
            try
            {
                //Open the Tenant Administration Context with the Tenant Admin Url
                using (ClientContext clientContext = new ClientContext(InstanceAdminURL))
                {
                    SecureString secureString = new SecureString();
                    Password.ToList().ForEach(secureString.AppendChar);
                    clientContext.AuthenticationMode = ClientAuthenticationMode.Default;
                    clientContext.Credentials = new SharePointOnlineCredentials(UserName, secureString);
                    var tenant = new Tenant(clientContext);

                    NormalizeURL();
                    string instanceUrl = InstanceAdminURL.Replace("-admin", "");
                    var scp = new SiteCreationProperties();
                    scp.Url = instanceUrl;
                    scp.Title = SiteTitle;
                    scp.Owner = SiteOwnerLogin;
                    scp.Template = SiteTemplate;

                    tenant.CreateSite(scp);
                    clientContext.ExecuteQuery();
                }

                return this.GenerateActivityResult(GetActivityResult);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Error creating site '{0}'. {1}", SiteName, e.Message));
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
            if (!SiteName.StartsWith("sites") && !SiteName.StartsWith("/sites"))
                SiteName = "sites/" + SiteName;

            if (InstanceAdminURL.EndsWith("/"))
                InstanceAdminURL = InstanceAdminURL + SiteName;
            else
                InstanceAdminURL = InstanceAdminURL + "/" + SiteName;
        }
    }
}
