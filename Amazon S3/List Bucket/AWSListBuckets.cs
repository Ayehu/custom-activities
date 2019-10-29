using Amazon;
using Amazon.S3;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Amazon.Runtime;
using Amazon.S3.Model;
using System.Data;

namespace ayehu.Sdk.AWSS3
{

    class AWSListBuckets : IActivity
    {
        public string AccessKey;
        public string SecretKey;
        public ICustomActivityResult Execute()
        {
            var credentials = new BasicAWSCredentials(AccessKey, SecretKey);
            ListBucketsResponse response = new AmazonS3Client(credentials, RegionEndpoint.USEast1).ListBuckets();
            var dataTable = new DataTable("List bucket", "AWSS3");
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("BucketName");
            dataTable.Columns.Add("Created date");
            int id = 0;
            foreach (S3Bucket bucket in response.Buckets)
            {
                id++;
                dataTable.Rows.Add(id, bucket.BucketName, bucket.CreationDate);
            }
            return this.GenerateActivityResult(dataTable);
        }
    }
}
