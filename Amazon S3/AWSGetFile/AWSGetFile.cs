using System;
using Amazon.S3;
using Amazon.S3.Transfer;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;

namespace ayehu.Sdk.AWSS3
{
    public class AWSGetFile : IActivity
    {
        public string AccessKey;
        public string SecretKey;
        public string Bucket;
        public string File_Path;
        public string Key;
        public ICustomActivityResult Execute()
        {
            var message = string.Empty;
            TransferUtility fileTransferUtility = new TransferUtility(new AmazonS3Client(AccessKey, SecretKey, Amazon.RegionEndpoint.USEast1));
            fileTransferUtility.Download(File_Path + "\\" + Key, Bucket, Key);
            message = "Success";
            return this.GenerateActivityResult(message);
        }
    }
}
