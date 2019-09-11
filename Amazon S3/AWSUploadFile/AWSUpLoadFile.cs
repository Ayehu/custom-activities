using System;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;

namespace Ayehu.Sdk.AWSS3
{
    public class AWSUpLoadFile : IActivity
    {
        public string Bucket;
        public string File_Path;
        public string AccessKey;
        public string SecretKey;
        // Specify your bucket region (an example region is shown).

        public ICustomActivityResult Execute()
        {
            var message = string.Empty;
            RegionEndpoint bucketRegion = RegionEndpoint.EUWest1;
            IAmazonS3 s3Client = new AmazonS3Client(AccessKey, SecretKey, bucketRegion);
            var fileTransferUtility = new TransferUtility(s3Client);
            fileTransferUtility.Upload(File_Path, Bucket);
            message = "Success";
            return this.GenerateActivityResult(message);
        }
    }
}
