using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using Docker.DotNet;
using System.IO;
using Docker.DotNet.BasicAuth;
using Docker.DotNet.Models;

namespace ActivitiesAyehu
{
    public class DockerPushImage : IActivity
    {
        public string RemoteDockerURI;
        public string ImageName;
        public string DockerUserName;
        public string DockerPassword;
        public string Tag;

        public ICustomActivityResult Execute()
        {
            var result = PushImage();

            return this.GenerateActivityResult(result);
        }

        private string PushImage()
        {
            var credentials = new BasicAuthCredentials(DockerUserName, DockerPassword);
            DockerClient client = new DockerClientConfiguration(
                new Uri(RemoteDockerURI), credentials)
                 .CreateClient();

            var stream = new MemoryStream();

            var prog = new Progress<JSONMessage>();
            var response = client.Images.PushImageAsync(ImageName,
                new ImagePushParameters()
                {
                    Tag = Tag
                }, new AuthConfig
                {
                    Username = DockerUserName,
                    Password = DockerPassword,
                    ServerAddress  = RemoteDockerURI
                }, prog);

            response.Wait();

            return "Success";
        }
    }
}
