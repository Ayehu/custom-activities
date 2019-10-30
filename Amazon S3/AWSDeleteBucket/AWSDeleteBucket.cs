using Amazon;
using Amazon.S3;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Amazon.Runtime;
namespace ayehu.Sdk.AWSS3
{
    class AWSDeleteBucket : IActivity
    {
        public string bucketName;
        public string AccessKey;
        public string SecretKey;

        public ICustomActivityResult Execute()
        {
            var message = string.Empty;
            var credentials = new BasicAWSCredentials(AccessKey, SecretKey);
            using (var result = new AmazonS3Client(credentials, RegionEndpoint.USEast1))
            {
                result.DeleteBucket(bucketName);
                message = "Success";
            }
            return this.GenerateActivityResult(message);
        }
    }
}
