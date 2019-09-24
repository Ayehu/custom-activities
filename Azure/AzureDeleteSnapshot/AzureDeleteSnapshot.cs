using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Net;

namespace AzureDeleteSnapshot
{
    class AzureDeleteSnapshot : IActivity
    {
        public string tenantId;
        public string clientId;
        public string clientSecret;
        public string subscriptionId;
        public string resourceGroupName;
        public string snapshotName;
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
            request.Method = "DELETE";
            request.Headers["Authorization"] = "Bearer " + token;
            request.ContentType = "application/json";
            try
            {
                request.GetRequestStream();
                var httpResponse = (HttpWebResponse)request.GetResponse();
                httpResponse.GetResponseStream();
            }
            catch (Exception ex)
            {
                 Message ="Failure: "+ ex.Message;
                return this.GenerateActivityResult(Message);
            }
            Message = "Success";
            return this.GenerateActivityResult(Message);
        }
    }
}
