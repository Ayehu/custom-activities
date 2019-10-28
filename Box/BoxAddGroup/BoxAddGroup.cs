using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Box.V2.Config;
using Box.V2.JWTAuth;
using Box.V2.Models.Request;

namespace ActivitiesAyehu
{
    public class BoxAddGroup : IActivity
    {
        public string UserId;
        public string ClientId;
        public string ClientSecret;
        public string EntrepriseId;
        public string Passphrase;
        public string JwtPublicKey;
        public string PrivateKey;

        public string GroupName;

        public ICustomActivityResult Execute()
        {
            var result = AddGroup();

            return this.GenerateActivityResult(result);
        }

        private string AddGroup()
        {
            var boxConfig = new BoxConfig(ClientId, ClientSecret, EntrepriseId, PrivateKey,
                Passphrase, JwtPublicKey);
            var boxJWT = new BoxJWTAuth(boxConfig);

            var adminToken = boxJWT.UserToken(UserId);
            var client = boxJWT.AdminClient(adminToken);

            client.GroupsManager.CreateAsync(new BoxGroupRequest()
            {
                Name = GroupName
            });

            return "Success";
        }
    }
}
