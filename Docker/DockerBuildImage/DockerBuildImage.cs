using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using Docker.DotNet;
using System.Collections.Generic;
using System.IO;

namespace ActivitiesAyehu
{
    public class DockerBuildImage : IActivity
    {
        public string RemoteDockerURI;
        public string RemoteContext;
        public string ImageName;

        public ICustomActivityResult Execute()
        {
            var result = BuildImage();

            return this.GenerateActivityResult(result);
        }

        private string BuildImage()
        {
            DockerClient client = new DockerClientConfiguration(
                new Uri(RemoteDockerURI))
                 .CreateClient();

            var stream = new MemoryStream();

            var response = client.Images.BuildImageFromDockerfileAsync(stream,
                new Docker.DotNet.Models.ImageBuildParameters
                {
                    RemoteContext = RemoteContext,
                    Tags = new List<string> { ImageName }
                });

            response.Wait();

            return "Success";
        }
    }
}
