using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Box.V2.Config;
using Box.V2.JWTAuth;

namespace ActivitiesAyehu
{
    public class BoxDeleteUser : IActivity
    {
        public string UserId;
        public string ClientId;
        public string ClientSecret;
        public string EntrepriseId;
        public string Passphrase;
        public string JwtPublicKey;
        public string PrivateKey;

        public string UserIdToDelete;

        public ICustomActivityResult Execute()
        {
            var result = DeleteUser();

            return this.GenerateActivityResult(result);
        }

        private string DeleteUser()
        {
            var boxConfig = new BoxConfig(ClientId, ClientSecret, EntrepriseId, PrivateKey,
                Passphrase, JwtPublicKey);
            var boxJWT = new BoxJWTAuth(boxConfig);

            var adminToken = boxJWT.UserToken(UserId);
            var client = boxJWT.AdminClient(adminToken);

            var usersRes = client.UsersManager.GetEnterpriseUsersAsync();
            usersRes.Wait();

            foreach (var user in usersRes.Result.Entries)
            {
                if (user.Login == UserIdToDelete)
                {
                    var delUserRes = client.UsersManager.DeleteEnterpriseUserAsync(user.Id, false, false);

                    delUserRes.Wait();

                    return "Success";
                }
            }
            return "User Not Found";
        }
    }
}
