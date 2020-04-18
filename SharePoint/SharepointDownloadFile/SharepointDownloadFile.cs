using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Security;

namespace Ayehu.Sdk.ActivityCreation
{
    public class SharePointDownloadFile : IActivity
    {
        /// <summary>
        /// The SharePoint base URL
        /// </summary>
        public string InstanceURL;

        /// <summary>
        /// SharePoint Site to download the file from.
        /// </summary>
        /// <remarks>If it's the root website, then leave it empty.</remarks>
        public string Site;

        /// <summary>
        /// File Name to download
        /// </summary>
        public string FileName;

        /// <summary>
        /// Folder to copy file from server.
        /// </summary>
        /// <remarks>The file copied will have the same name as on the server</remarks>
        public string DestinationFolder;

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
                using (ClientContext adminContext = new ClientContext(InstanceURL))
                {
                    bool removeSiteAdmin = false;

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

                        var list = clientContext.Web.Lists.GetByTitle("Documents");
                        clientContext.Load(list);
                        clientContext.Load(list.RootFolder);
                        clientContext.ExecuteQuery();

                        if (clientContext.HasPendingRequest)
                            clientContext.ExecuteQuery();

                        string serverFile = list.RootFolder.ServerRelativeUrl.ToString() + "/" + FileName;
                        var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, serverFile);

                        if (fileInfo == null || fileInfo.Stream == null)
                            throw new Exception(string.Format("File '{0}' not found.", FileName));

                        using (var fileStream = new FileStream(DestinationFolder, FileMode.Create, FileAccess.Write))
                        {
                            fileInfo.Stream.CopyTo(fileStream);
                            fileStream.Flush();
                        }

                        fileInfo.Stream.Dispose();
                    }

                    if (removeSiteAdmin)
                    {
                        tenant.SetSiteAdmin(instanceUrl, UserName, false);
                        adminContext.ExecuteQuery();
                    }

                    return this.GenerateActivityResult(GetActivityResult);
                }
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Error downloading file '{0}'. Message: {1}", FileName, e.Message));
            }
        }

        private void SetCredentials(ClientContext ctx)
        {
            SecureString secureString = new SecureString();
            Password.ToList().ForEach(secureString.AppendChar);
            ctx.AuthenticationMode = ClientAuthenticationMode.Default;
            ctx.Credentials = new SharePointOnlineCredentials(UserName, secureString);
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

            if (DestinationFolder.EndsWith("/"))
                DestinationFolder = DestinationFolder + FileName;
            else
                DestinationFolder = DestinationFolder + "/" + FileName;
        }
    }
}
