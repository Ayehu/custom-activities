using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
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
        /// The Sharepoint base URL
        /// </summary>
        public string InstanceURL;

        /// <summary>
        /// Sharepoint Site to get the owner information.
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

        public ICustomActivityResult Execute()
        {
            try
            {
                if (!InstanceURL.EndsWith("/"))
                    InstanceURL = InstanceURL + "/" + Site;
                else
                    InstanceURL = InstanceURL + Site;

                using (ClientContext clientContext = new ClientContext(InstanceURL))
                {
                    SecureString secureString = new SecureString();
                    Password.ToList().ForEach(secureString.AppendChar);
                    clientContext.AuthenticationMode = ClientAuthenticationMode.Default;
                    clientContext.Credentials = new SharePointOnlineCredentials(UserName, secureString);

                    User siteOwner = clientContext.Site.Owner;
                    clientContext.Load(siteOwner);
                    clientContext.ExecuteQuery();

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
    }
}
