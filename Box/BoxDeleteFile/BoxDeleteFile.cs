using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Box.V2.Config;
using Box.V2.JWTAuth;
using System.Threading.Tasks;

namespace ayehu.BoxDeleteFile
{
    public class DeleteFile : IActivityAsync
    {
        public string FileID;
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

            await adminClient.FilesManager.DeleteAsync(id: FileID);
            Message = "Success";
            return this.GenerateActivityResult(Message);
        }
    }
}
