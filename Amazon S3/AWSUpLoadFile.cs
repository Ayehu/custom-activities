using System;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;

namespace ayehu.BoxUpLoadFile
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
            try
            {
                RegionEndpoint bucketRegion = RegionEndpoint.EUWest1;
                IAmazonS3 s3Client = new AmazonS3Client(AccessKey, SecretKey, bucketRegion);
                var fileTransferUtility = new TransferUtility(s3Client);

                // Upload a file. The file name is used as the object key name.
                fileTransferUtility.Upload(File_Path, Bucket);
                message = "Upload completed";
            }
            catch (AmazonS3Exception e)
            {
                message = "Error encountered on server. Message:'{0}' when writing an object"+ e.Message;
            }
            catch (Exception e)
            {
                message = "Unknown encountered on server. Message:'{0}' when writing an object"+ e.Message;
            }

            return this.GenerateActivityResult(message);
        }
    }
}
