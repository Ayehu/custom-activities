using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using Docker.DotNet;
using System.Collections.Generic;
using System.IO;
using Docker.DotNet.Models;

namespace ActivitiesAyehu
{
    public class DockerStopContainer : IActivity
    {
        public string RemoteDockerURI;
        public string ContainerId;

        public ICustomActivityResult Execute()
        {
            var result = StopContainer();

            return this.GenerateActivityResult(result);
        }

        private string StopContainer()
        {
            DockerClient client = new DockerClientConfiguration(
                new Uri(RemoteDockerURI))
                 .CreateClient();

            var stream = new MemoryStream();

            var response = client.Containers.StopContainerAsync(ContainerId,
                new ContainerStopParameters());

            response.Wait();

            return "Success";
        }
    }
}
