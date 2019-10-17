using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.Compute.v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Compute.v1.Data;
using System.Threading.Tasks;
using System.Text;
using System.Data;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace ActivitiesAyehu
{
    public class DockerListImages : IActivity
    {
        public string RemoteDockerURI;

        public ICustomActivityResult Execute()
        {
            var result = ListImages();

            var dataTable = new DataTable("Image List", "ImageList");
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Shared size");
            dataTable.Columns.Add("Size");
            dataTable.Columns.Add("Parent ID");
            foreach (var img in result)
                dataTable.Rows.Add(img.ID, img.RepoTags[0], img.SharedSize, img.Size,
                    img.ParentID);

            return this.GenerateActivityResult(dataTable);
        }

        private IList<ImagesListResponse> ListImages()
        {
            DockerClient client = new DockerClientConfiguration(
                new Uri(RemoteDockerURI))
                 .CreateClient();

            var response = client.Images.ListImagesAsync(
                new Docker.DotNet.Models.ImagesListParameters());

            response.Wait();

            return response.Result;
        }
    }
}
