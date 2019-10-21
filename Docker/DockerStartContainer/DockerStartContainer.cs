using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using Docker.DotNet;
using System.IO;
using Docker.DotNet.Models;

namespace ActivitiesAyehu
{
    public class DockerStartContainer : IActivity
    {
        public string RemoteDockerURI;
        public string ContainerId;

        public ICustomActivityResult Execute()
        {
            var result = StartContainer();

            return this.GenerateActivityResult(result);
        }

        private string StartContainer()
        {
            DockerClient client = new DockerClientConfiguration(
                new Uri(RemoteDockerURI))
                 .CreateClient();

            var stream = new MemoryStream();

            var response = client.Containers.StartContainerAsync(ContainerId, new ContainerStartParameters());

            response.Wait();

            return "Success";
        }
    }
}
