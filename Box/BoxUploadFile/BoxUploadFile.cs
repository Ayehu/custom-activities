using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Box.V2.Config;
using Box.V2.JWTAuth;
using Box.V2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ayehu.BoxUploadFile
{
    public class UploadFile : IActivityAsync
    {
        public string FolderID;
        public string NameFile;
        public string FilePath;
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

            using (FileStream fileStream = new FileStream(FilePath, FileMode.Open))
            {
                BoxFileRequest requestParams = new BoxFileRequest()
                {
                    Name = NameFile,
                    Parent = new BoxRequestEntity() { Id = FolderID }
                };
                BoxFile file = await adminClient.FilesManager.UploadAsync(requestParams, fileStream);
                Message = "Success";
            }
            return this.GenerateActivityResult(Message);
        }
    }
}
