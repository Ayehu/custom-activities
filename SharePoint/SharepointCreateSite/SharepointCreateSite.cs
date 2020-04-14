using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Sites;
using System;
using System.Data;
using System.Linq;
using System.Security;

namespace Ayehu.Sdk.ActivityCreation
{
    public class SharePointCreateSite : IActivity
    {
        /// <summary>
        /// The SharePoint ADMIN base URL
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
                //Open the Tenant Administration Context with the Tenant Admin Url
                using (ClientContext clientContext = new ClientContext(InstanceAdminURL))
                {
                    SecureString secureString = new SecureString();
                    Password.ToList().ForEach(secureString.AppendChar);
                    clientContext.AuthenticationMode = ClientAuthenticationMode.Default;
                    clientContext.Credentials = new SharePointOnlineCredentials(UserName, secureString);

                    NormalizeURL();
                    string instanceUrl = InstanceAdminURL.Replace("-admin", "");

                    if (SiteTemplate.Contains("SITEPAGEPUBLISHING"))
                    {
                        CommunicationSiteCollectionCreationInformation communicationSiteInfo = new CommunicationSiteCollectionCreationInformation
                        {
                            Title = SiteTitle,
                            Url = instanceUrl,
                            SiteDesign = CommunicationSiteDesign.Blank,
                            Owner = SiteOwnerLogin
                        };

                        var createCommSite = clientContext.CreateSiteAsync(communicationSiteInfo).Result;
                    }
                    else
                    {
                        var teamSite = new TeamSiteCollectionCreationInformation
                        {
                            Description = SiteTitle,
                            DisplayName = SiteName,
                            Alias = SiteName,
                            Owners = new string[] { SiteOwnerLogin },
                            IsPublic = true
                        };

                        var createModernSite = clientContext.CreateSiteAsync(teamSite).Result;
                    }

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
