using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using Docker.DotNet;
using System.Collections.Generic;
using System.IO;
using System.Data;
using Docker.DotNet.Models;

namespace ActivitiesAyehu
{
    public class DockerListContainers : IActivity
    {
        public string RemoteDockerURI;

        public ICustomActivityResult Execute()
        {
            var result = ListContainers();

            var dataTable = new DataTable("Image List", "ImageList");
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Image");
            dataTable.Columns.Add("Image ID");
            dataTable.Columns.Add("Status");
            dataTable.Columns.Add("State");
            foreach (var cont in result)
                dataTable.Rows.Add(cont.ID, string.Join(",", cont.Names), cont.Image, cont.ImageID, cont.Status, cont.State);

            return this.GenerateActivityResult(dataTable);
        }

        private IList<ContainerListResponse> ListContainers()
        {
            DockerClient client = new DockerClientConfiguration(
                new Uri(RemoteDockerURI))
                 .CreateClient();

            var stream = new MemoryStream();

            var response = client.Containers.ListContainersAsync(
                new ContainersListParameters());

            response.Wait();

            return response.Result;
        }
    }
}
