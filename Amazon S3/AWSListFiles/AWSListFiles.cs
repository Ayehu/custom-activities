using Amazon.S3;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Amazon.S3.Model;
using System.Data;
using System;
using Amazon;

namespace Ayehu.Sdk.AWSS3
{
    class AWSListFiles : IActivity
    {
        public string AccessKey;
        public string SecretKey;
        public string bucketName;
        public string keyRegion;
        private static IAmazonS3 client;
        RegionEndpoint regionEndpoint;
        public ICustomActivityResult Execute()
        {
            string Message = string.Empty;
            var dataTable = new DataTable("List Files", "AWSS3");
            try
            {
                switch(keyRegion)
                {
                    case "1":
                        regionEndpoint = RegionEndpoint.USEast2;
                        break;
                    case "2":
                        regionEndpoint = RegionEndpoint.USEast1;
                        break;
                    case "3":
                        regionEndpoint = RegionEndpoint.USWest1;
                        break;
                    case "4":
                        regionEndpoint = RegionEndpoint.USWest2;
                        break;
                    case "5":
                        regionEndpoint = RegionEndpoint.APEast1;
                        break;
                    case "6":
                        regionEndpoint = RegionEndpoint.APSouth1;
                        break;
                    case "7":
                        regionEndpoint = RegionEndpoint.APNortheast2;
                        break;
                    case "8":
                        regionEndpoint = RegionEndpoint.APSoutheast1;
                        break;
                    case "9":
                        regionEndpoint = RegionEndpoint.APSoutheast2;
                        break;
                    case "10":
                        regionEndpoint = RegionEndpoint.APNortheast2;
                        break;
                    case "11":
                        regionEndpoint = RegionEndpoint.CACentral1;
                        break;
                    case "12":
                        regionEndpoint = RegionEndpoint.CNNorth1;
                        break;
                    case "13":
                        regionEndpoint = RegionEndpoint.CNNorthWest1;
                        break;
                    case "14":
                        regionEndpoint = RegionEndpoint.EUCentral1;
                        break;
                    case "15":
                        regionEndpoint = RegionEndpoint.EUWest1;
                        break;
                    case "16":
                        regionEndpoint = RegionEndpoint.EUWest2;
                        break;
                    case "17":
                        regionEndpoint = RegionEndpoint.EUWest3;
                        break;
                    case "18":
                        regionEndpoint = RegionEndpoint.EUNorth1;
                        break;
                    case "19":
                        regionEndpoint = RegionEndpoint.MESouth1;
                        break;
                    case "20":
                        regionEndpoint = RegionEndpoint.SAEast1;
                        break;
                    case "21":
                        regionEndpoint = RegionEndpoint.USGovCloudEast1;
                        break;
                    case "22":
                        regionEndpoint = RegionEndpoint.USGovCloudWest1;
                        break;
                }
                client = new AmazonS3Client(AccessKey, SecretKey, regionEndpoint);
                ListObjectsV2Request request = new ListObjectsV2Request
                {
                    BucketName = bucketName,
                    MaxKeys = 100
                };
                ListObjectsV2Response response;
                do
                {
                    response = client.ListObjectsV2(request);
                    dataTable.Columns.Add("Id");
                    dataTable.Columns.Add("FileName");
                    dataTable.Columns.Add("BucketName");
                    dataTable.Columns.Add("Size");
                    dataTable.Columns.Add("ETag");
                    dataTable.Columns.Add("LastModified");
                    dataTable.Columns.Add("Owner");
                    int id = 0;
                    foreach (var item in response.S3Objects)
                    {
                        id++;
                        dataTable.Rows.Add(id, item.Key, item.BucketName, item.Size,item.ETag,item.LastModified,item.Owner);
                    }
                    // Process the response.
                    request.ContinuationToken = response.NextContinuationToken;
                }
                while (response.IsTruncated);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                Message = "S3 error occurred. Exception: " + amazonS3Exception.ToString();
                return this.GenerateActivityResult(Message);
            }
            catch (Exception e)
            {
                Message = "Exception: " + e.ToString();
                Console.ReadKey();
            }
            return this.GenerateActivityResult(dataTable);
        }
    }
}
