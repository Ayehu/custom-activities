using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.IO;
using System.Net;

namespace AzureDeleteImage
{
    class AzureDeleteImage : IActivity
    {
        public string tenantId;
        public string clientId;
        public string clientSecret;
        public string subscriptionId;
        public string resourceGroupName;
        public string imageName;
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
            HttpWebRequest requestG = (HttpWebRequest)HttpWebRequest.Create("https://management.azure.com/subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.Compute/images/" + imageName + "?api-version=2019-03-01");
            requestG.Method = "GET";
            requestG.Headers["Authorization"] = "Bearer " + token;
            requestG.ContentType = "application/json";
            try
            {
                var response = (HttpWebResponse)requestG.GetResponse();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return this.GenerateActivityResult(Message);
            }
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://management.azure.com/subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.Compute/images/" + imageName + "?api-version=2019-03-01");
                request.Method = "DELETE";
                request.Headers["Authorization"] = "Bearer " + token;
                var responseRequest = request.GetRequestStream();
                var httpResponse = (HttpWebResponse)request.GetResponse();
                var getresponseStream = httpResponse.GetResponseStream();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return this.GenerateActivityResult(Message);
            }
            Message = "Success";
            return this.GenerateActivityResult(Message);
        }
    }
}
