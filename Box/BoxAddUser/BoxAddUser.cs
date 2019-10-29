using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Box.V2.Config;
using Box.V2.JWTAuth;
using Box.V2.Models;

namespace ActivitiesAyehu
{
    public class BoxAddUser : IActivity
    {
        public string UserId;
        public string ClientId;
        public string ClientSecret;
        public string EntrepriseId;
        public string Passphrase;
        public string JwtPublicKey;
        public string PrivateKey;

        public string UserName;
        public string Login;

        public ICustomActivityResult Execute()
        {
            var result = AddUser();

            return this.GenerateActivityResult(result);
        }

        private string AddUser()
        {
            var boxConfig = new BoxConfig(ClientId, ClientSecret, EntrepriseId, PrivateKey,
               Passphrase, JwtPublicKey);
            
            var boxJWT = new BoxJWTAuth(boxConfig);
            
            var adminToken = boxJWT.UserToken(UserId);
            var client = boxJWT.AdminClient(adminToken);

            var userRes = client.UsersManager.CreateEnterpriseUserAsync(new BoxUserRequest()
            {
                Name = UserName,
                Login  = Login
            });

            userRes.Wait();

            if (userRes.Exception != null)
                return userRes.Exception.Message;

            return "Success";
        }
    }
}
