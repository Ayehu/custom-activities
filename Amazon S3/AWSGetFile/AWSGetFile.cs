using Amazon.S3;
using Amazon.S3.Transfer;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Amazon;

namespace ayehu.Sdk.AWSS3
{
    public class AWSGetFile : IActivity
    {
        public string AccessKey;
        public string SecretKey;
        public string Bucket;
        public string File_Path;
        public string Key;
        public string keyRegion;
        RegionEndpoint regionEndpoint;
        public ICustomActivityResult Execute()
        {

            var message = string.Empty;
            switch (keyRegion)
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
            TransferUtility fileTransferUtility = new TransferUtility(new AmazonS3Client(AccessKey, SecretKey, regionEndpoint));
            fileTransferUtility.Download(File_Path + "\\" + Key, Bucket, Key);
            message = "Success";
            return this.GenerateActivityResult(message);
        }
    }
}
