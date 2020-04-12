using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.SharePoint.Client;
using System;
using System.Data;
using System.Linq;
using System.Security;

namespace Ayehu.Sdk.ActivityCreation
{
    public class SharepointRemoveSiteUser : IActivity
    {
        /// <summary>
        /// The Sharepoint base URL
        /// </summary>
        public string InstanceURL;

        /// <summary>
        /// Sharepoint Site to remove user from.
        /// </summary>
        /// <remarks>If it's the root website, then leave it empty.</remarks>
        public string Site;

        /// <summary>
        /// Username used to login in admin panel of Sharepoint instance
        /// </summary>
        public string UserName;

        /// <summary>
        /// Password used to login in admin panel of Sharepoint instance
        /// </summary>
        public string Password;

        /// <summary>
        /// User full login name as defined in the Domain or Azure
        /// </summary>
        public string UserLogonName;

        public ICustomActivityResult Execute()
        {
            NormalizeURL();

            using (ClientContext clientContext = new ClientContext(InstanceURL))
            {
                SecureString secureString = new SecureString();
                Password.ToList().ForEach(secureString.AppendChar);
                clientContext.AuthenticationMode = ClientAuthenticationMode.Default;
                clientContext.Credentials = new SharePointOnlineCredentials(UserName, secureString);

                var user = clientContext.Web.EnsureUser(UserLogonName);
                clientContext.Load(user);
                clientContext.ExecuteQuery();

                if (user != null)
                {
                    clientContext.Site.RootWeb.SiteUsers.Remove(user);
                    clientContext.ExecuteQuery();

                    return this.GenerateActivityResult(GetActivityResult);
                }

                throw new Exception(string.Format("User '{0}' not found.", UserLogonName));
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

            if (InstanceURL.EndsWith("/"))
                InstanceURL = InstanceURL + Site;
            else
                InstanceURL = InstanceURL + "/" + Site;
        }
    }
}
