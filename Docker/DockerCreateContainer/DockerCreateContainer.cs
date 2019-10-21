using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using Docker.DotNet;
using System.Collections.Generic;
using System.IO;

namespace ActivitiesAyehu
{
    public class DockerCreateContainer : IActivity
    {
        public string RemoteDockerURI;
        public string ImageName;
        public string ContainerName;

        public ICustomActivityResult Execute()
        {
            var result = CreateContainer();

            return this.GenerateActivityResult(result);
        }

        private string CreateContainer()
        {
            DockerClient client = new DockerClientConfiguration(
                new Uri(RemoteDockerURI))
                 .CreateClient();

            var response = client.Containers.CreateContainerAsync(
                new Docker.DotNet.Models.CreateContainerParameters
                {
                    Image = ImageName,
                    Name = ContainerName
                });

            response.Wait();

            return "Success";
        }
    }
}
