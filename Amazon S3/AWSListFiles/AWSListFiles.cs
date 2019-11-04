using Amazon.S3;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Amazon.S3.Model;
using System.Data;
using System;
using Amazon;

namespace ayehu.Sdk.AWSS3
{
    class AWSListFiles : IActivity
    {
        public string AccessKey;
        public string SecretKey;
        public string bucketName;
        private static IAmazonS3 client;
        public ICustomActivityResult Execute()
        {
            string Message = string.Empty;
            var dataTable = new DataTable("List Files", "AWSS3");
            try
            {
                client = new AmazonS3Client(AccessKey, SecretKey, RegionEndpoint.USWest2);
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
                    dataTable.Columns.Add("Size");
                    int id = 0;
                    foreach (var item in response.S3Objects)
                    {
                        id++;
                        dataTable.Rows.Add(id, item.Key, item.Size);
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