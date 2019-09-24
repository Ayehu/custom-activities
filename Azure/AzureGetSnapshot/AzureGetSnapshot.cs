using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.IO;
using System.Net;

namespace AzureGetSnapshot
{
    class AzureGetSnapshot : IActivity
    {
        public string tenantId;
        public string clientId;
        public string clientSecret;
        public string subscriptionId;
        public string resourceGroupName;
        public string snapshotName;
        public string File_Path;
        public ICustomActivityResult Execute()
        {
            string Message = string.Empty;
            string authContextURL = "https://login.windows.net/" + tenantId;
            var authenticationContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authContextURL);
            var credential = new ClientCredential(clientId, clientSecret);
            var result = authenticationContext.AcquireTokenAsync(resource: "https://management.azure.com/", clientCredential: credential).Result;
            if (result == null)
            {
                Message = "Failed to obtain the JWT token";
                return this.GenerateActivityResult(Message);
            }
            string token = result.AccessToken;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://management.azure.com/subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.Compute/snapshots/" + snapshotName + "?api-version=2018-06-01");
            request.Method = "GET";
            request.Headers["Authorization"] = "Bearer " + token;
            request.ContentType = "application/json";
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                FileStream fs = null;
                try
                {
                    fs = new FileStream(File_Path + "\\" + snapshotName + ".txt", FileMode.Append);
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        StreamReader sr = new StreamReader(response.GetResponseStream());
                        writer.Write(sr.ReadToEnd());
                    }
                }
                finally
                {
                    if (fs != null)
                        fs.Dispose();
                }
            }
            catch (Exception ex)
            {
                Message = "Failure: " + ex.Message;
                return this.GenerateActivityResult(Message);
            }
            Message = "Success";
            return this.GenerateActivityResult(Message);
        }
    }
}
