using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureADUserAddToGroup : IActivity
    {
        public string groupName = "";
        public string userEmail = "";
        public string accessToken = "";
        public string Jsonkeypath = "";

        public ICustomActivityResult Execute()
        {
            string groupId = String.Empty;
            string userId = String.Empty;

            if (string.IsNullOrEmpty(accessToken))
            {
                throw new Exception("Unable to retrieve access token.");
            }

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://graph.microsoft.com/v1.0/groups?$filter=displayName eq '" + groupName + "'");
            request.Method = "GET";
            request.Headers.Add("Authorization", accessToken);
            request.Accept = "application/json";
            request.ContentType = "application/json";

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var responseString = streamReader.ReadToEnd();

                    JObject jsonResults = JObject.Parse(responseString);

                    JArray groupList = (JArray)jsonResults["value"];

                    if (groupList.Count == 0)
                    {
                        throw new Exception("Group not found.");
                    }

                    groupId = jsonResults["value"][0]["id"].ToString();
                }
            }
            catch (WebException e)
            {
                throw new Exception(e.Message);
            }

            HttpWebRequest request1 = (HttpWebRequest)HttpWebRequest.Create("https://graph.microsoft.com/v1.0/users?$filter=userPrincipalName eq '" + userEmail + "'");
            request1.Method = "GET";
            request1.Headers.Add("Authorization", accessToken);
            request1.Accept = "application/json";
            request1.ContentType = "application/json";

            try
            {
                var response = (HttpWebResponse)request1.GetResponse();

                using (var streamReader1 = new StreamReader(response.GetResponseStream()))
                {
                    var responseString1 = streamReader1.ReadToEnd();

                    JObject jsonResults1 = JObject.Parse(responseString1);

                    JArray userList = (JArray)jsonResults1["value"];

                    if (userList.Count == 0)
                    {
                        throw new Exception("User not found.");
                    }

                    userId = jsonResults1["value"][0]["id"].ToString();
                }
            }
            catch (WebException e)
            {
                throw new Exception(e.Message);
            }

            HttpWebRequest request2 = (HttpWebRequest)HttpWebRequest.Create("https://graph.microsoft.com/v1.0/groups/" + groupId + "/members/$ref");
            request2.Method = "POST";
            request2.Headers.Add("Authorization", accessToken);
            request2.Accept = "application/json";
            request2.ContentType = "application/json";

            string jsonBody = "{\"@odata.id\": \"https://graph.microsoft.com/v1.0/users/" + userId + "\"}";

            try
            {
                using (var streamWriter = new StreamWriter(request2.GetRequestStream()))
                {
                    streamWriter.Write(jsonBody);
                    streamWriter.Flush();
                    streamWriter.Close();

                    var httpResponse = (HttpWebResponse)request2.GetResponse();

                    if (httpResponse.StatusCode.ToString() == "NoContent")
                    {
                        return this.GenerateActivityResult("Success");
                    }
                    else
                    {
                        throw new Exception(httpResponse.StatusCode.ToString());
                    }
                }
            }
            catch (WebException e2)
            {
                throw new Exception(e2.Message);
            }
        }
    }
}
