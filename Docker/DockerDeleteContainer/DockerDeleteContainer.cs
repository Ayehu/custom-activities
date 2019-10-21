using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using Docker.DotNet;
using System.Collections.Generic;
using System.IO;

namespace ActivitiesAyehu
{
    public class DockerDeleteContainer : IActivity
    {
        public string RemoteDockerURI;
        public string ContainerId;

        public ICustomActivityResult Execute()
        {
            var result = DeleteContainer();

            return this.GenerateActivityResult(result);
        }

        private string DeleteContainer()
        {
            DockerClient client = new DockerClientConfiguration(
                new Uri(RemoteDockerURI))
                 .CreateClient();

            var stream = new MemoryStream();

            var response = client.Containers.RemoveContainerAsync(ContainerId,
                new Docker.DotNet.Models.ContainerRemoveParameters());

            response.Wait();

            return "Success";
        }
    }
}
