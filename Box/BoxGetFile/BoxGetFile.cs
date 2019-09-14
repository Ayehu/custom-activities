using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Box.V2.Config;
using Box.V2.JWTAuth;
using System.IO;
using System.Threading.Tasks;

namespace ayehu.BoxGetFile
{
    public class GetFile : IActivityAsync
    {
        public string FileID;
        public string FilePath;
        public string Name;
        public string USER_ID;
        public string CLIENT_ID;
        public string CLIENT_SECRET;
        public string ENTERPRISE_ID;
        public string JWT_PRIVATE_KEY_PASSWORD;
        public string JWT_PUBLIC_KEY_ID;
        public string PRIVATE_KEY;
        public async Task<ICustomActivityResult> Execute()
        {
            var Message = string.Empty;
            var boxConfig = new BoxConfig(CLIENT_ID, CLIENT_SECRET, ENTERPRISE_ID, PRIVATE_KEY, JWT_PRIVATE_KEY_PASSWORD, JWT_PUBLIC_KEY_ID);
            var boxJWT = new BoxJWTAuth(boxConfig);
            var adminToken = boxJWT.UserToken(USER_ID);
            var adminClient = boxJWT.AdminClient(adminToken);
            Stream fileContents = await adminClient.FilesManager.DownloadAsync(FileID);
            using (Stream file = File.Create(FilePath))
            {
                byte[] buffer = new byte[8 * 1024];
                int len;
                while ((len = fileContents.Read(buffer, 0, buffer.Length)) > 0)
                {
                    file.Write(buffer, 0, len);
                }
            }
            Message = "Success";
            return this.GenerateActivityResult(Message);
        }
    }
}
