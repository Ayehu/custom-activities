using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.IO;
using Box.V2.Config;
using Box.V2.JWTAuth;
using Box.V2.Models;
using System;
using System.Threading.Tasks;

namespace Ayehu.Sdk.Box
{
    public class CopyFile : IActivityAsync
    {
        public string FolderID;
        public string FileID;
        public string Name;
        public string Version;
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
            var requestParams = new BoxFileRequest()
            {
                Id = FileID,
                Parent = new BoxRequestEntity()
                {
                    Id = FolderID
                },
                Name = Name
            };
            BoxFile fileCopy = await adminClient.FilesManager.CopyAsync(requestParams);
            Message = "Success";
            return this.GenerateActivityResult(Message);
        }
    }
}
