using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.IO;
using System.Net;

namespace AzureCreateImage
{
    class AzureCreateImage : IActivity
    {
        public string tenantId;
        public string clientId;
        public string clientSecret;
        public string subscriptionId;
        public string resourceGroupName;
        public string imageName;
        public string body;
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
                this.GenerateActivityResult(Message);
            }
            string token = result.AccessToken;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://management.azure.com/subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.Compute/images/" + imageName + "?api-version=2019-03-01");
            request.Method = "PUT";
            request.Headers["Authorization"] = "Bearer " + token;
            request.ContentType = "application/json";

            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(body);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
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
