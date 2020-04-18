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
    public class SharePointAddSiteUser : IActivity
    {
        /// <summary>
        /// The SharePoint Admin base URL
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
        /// User full login name as defined in the Domain or Azure
        /// </summary>
        public string UserLogonName;

        public ICustomActivityResult Execute()
        {
            try
            {
                using (ClientContext adminContext = new ClientContext(InstanceURL))
                {
                    SetCredentials(adminContext);
                    var tenant = new Tenant(adminContext);

                    NormalizeURL();
                    string instanceUrl = InstanceURL.Replace("-admin", "");
                    tenant.SetSiteAdmin(instanceUrl, UserLogonName, true);
                    adminContext.ExecuteQuery();
                    return this.GenerateActivityResult(GetActivityResult);
                }
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Cannont add user '{0}' as administrator. Message: {1}", UserLogonName, e.Message));
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

        private void SetCredentials(ClientContext ctx)
        {
            SecureString secureString = new SecureString();
            Password.ToList().ForEach(secureString.AppendChar);
            ctx.AuthenticationMode = ClientAuthenticationMode.Default;
            ctx.Credentials = new SharePointOnlineCredentials(UserName, secureString);
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
    }
}
