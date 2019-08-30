using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.IO;
using Box.V2.Config;
using Box.V2.JWTAuth;
using Box.V2.Models;
using System;

namespace Ayehu.Sdk.Box
{
    public class CopyFile : IActivity
    {
        public string FolderID;
        public string FileID;
        public string Name;
        public string Version;
        public string USER_ID ;
        public string CLIENT_ID;
        public string CLIENT_SECRET;
        public string ENTERPRISE_ID ;
        public string JWT_PRIVATE_KEY_PASSWORD;
        public string JWT_PUBLIC_KEY_ID ;
        public string PRIVATE_KEY;
        public ICustomActivityResult Execute()
        {
            var Message = string.Empty;
            try
            {
                var privateKey = File.ReadAllText(PRIVATE_KEY);
                var boxConfig = new BoxConfig(CLIENT_ID, CLIENT_SECRET, ENTERPRISE_ID, privateKey, JWT_PRIVATE_KEY_PASSWORD, JWT_PUBLIC_KEY_ID);
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
                //if (string.IsNullOrEmpty(fileCopy.Id))
                //{
                //    result = "Can not copy file";
                //}
                //else
                //{
                //    result = "File is copied with id " + fileCopy.Id;
                //}

            }
            catch (Exception ex)
            {
                Message = "Copy Error";
            }
            return this.GenerateActivityResult(Message);
        }
    }
}
