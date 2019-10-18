using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using System.Net.Http;
using System.Text;
using System.Web;

namespace ActivitiesAyehu
{
    public class DockerPushImage : IActivity
    {
        public string RemoteDockerURI;
        public string ImageName;
        public string DockerUsername;
        public string DockerPassword;

        public ICustomActivityResult Execute()
        {
            var result = PushImageHttp();

            return this.GenerateActivityResult(result);
        }

        private string PushImageHttp()
        {
            var authJson = "{\n  \"username\": \""+DockerUsername+"\",\n  \"password\": \""+DockerPassword+"\"\n}";

            var authBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(authJson));

            var uri_imageName = HttpUtility.UrlEncode(ImageName);

            var httpClient = new HttpClient();
            var content = new StringContent("", Encoding.UTF8);
            httpClient.DefaultRequestHeaders.Add("X-Registry-Auth", authBase64);
            var response = httpClient.PostAsync(RemoteDockerURI + string.Format("/images/{0}/push", uri_imageName), content);

            response.Wait();

            var respStr = response.Result.Content.ReadAsStringAsync();
            respStr.Wait();

            return "Success";
        }
    }
}
