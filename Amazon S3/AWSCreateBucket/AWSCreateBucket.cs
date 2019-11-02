using Amazon;
using Amazon.S3;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Amazon.S3.Model;
using Amazon.Runtime;
using System.Net;

namespace Ayehu.Sdk.AWSS3
{
    class AWSCreateBucket : IActivity
    {
        public string bucketName;
        public string AccessKey;
        public string SecretKey;
        private static S3CannedACL cannedACL = S3CannedACL.Private;
        public ICustomActivityResult Execute()
        {
            var message = string.Empty;
            try
            {
                var credentials = new BasicAWSCredentials(AccessKey, SecretKey);
                ListBucketsResponse response = new AmazonS3Client(credentials, RegionEndpoint.USEast1).ListBuckets();
                foreach (var item in response.Buckets)
                {
                    if (item.BucketName == bucketName)
                    {
                        message = "Bucket name \"" + bucketName + "\" already exists.";
                        return this.GenerateActivityResult(message);
                    }
                }
                PutBucketRequest request = new PutBucketRequest()
                {
                    BucketName = bucketName,
                    UseClientRegion = true,
                };
                var result = new AmazonS3Client(credentials, RegionEndpoint.USEast1).PutBucket(request);
                if (result.HttpStatusCode == HttpStatusCode.OK)
                {
                    message = "Success";
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    message = "Please check the provided AWS Credentials.";
                    message = message + "/nIf you haven't signed up for Amazon S3, please visit http://aws.amazon.com/s3";
                }
                else
                {
                    message = "An Error, number" + amazonS3Exception.ErrorCode + "occurred when creating a bucket with the message " + amazonS3Exception.Message;
                }
            }
            return this.GenerateActivityResult(message);
        }
    }
}
