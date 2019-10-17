using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using Docker.DotNet;
using System.Collections.Generic;
using System.IO;

namespace ActivitiesAyehu
{
    public class DockerDeleteImage : IActivity
    {
        public string RemoteDockerURI;
        public string ImageName;

        public ICustomActivityResult Execute()
        {
            var result = DeleteImage();

            return this.GenerateActivityResult(result);
        }

        private string DeleteImage()
        {
            DockerClient client = new DockerClientConfiguration(
                new Uri(RemoteDockerURI))
                 .CreateClient();

            var response = client.Images.DeleteImageAsync(ImageName,
                new Docker.DotNet.Models.ImageDeleteParameters());

            response.Wait();

            return "Success";
        }
    }
}
