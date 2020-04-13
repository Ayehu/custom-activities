using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
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
                NormalizeURL();

                using (ClientContext clientContext = new ClientContext(InstanceURL))
                {
                    SecureString secureString = new SecureString();
                    Password.ToList().ForEach(secureString.AppendChar);
                    clientContext.AuthenticationMode = ClientAuthenticationMode.Default;
                    clientContext.Credentials = new SharePointOnlineCredentials(UserName, secureString);

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

                return this.GenerateActivityResult(GetActivityResult);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Error downloading file '{0}'. Message: {1}", FileName, e.Message));
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

            if (DestinationFolder.EndsWith("/"))
                DestinationFolder = DestinationFolder + FileName;
            else
                DestinationFolder = DestinationFolder + "/" + FileName;
        }
    }
}
