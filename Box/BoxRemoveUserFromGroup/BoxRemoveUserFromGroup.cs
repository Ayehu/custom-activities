using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Box.V2.Config;
using Box.V2.JWTAuth;

namespace ActivitiesAyehu
{
    public class BoxRemoveUserFromGroup : IActivity
    {
        public string UserId;
        public string ClientId;
        public string ClientSecret;
        public string EntrepriseId;
        public string Passphrase;
        public string JwtPublicKey;
        public string PrivateKey;

        public string UserIdToBeRemoved, GroupId;

        public ICustomActivityResult Execute()
        {
            var result = RemoveUserFromGroup();

            return this.GenerateActivityResult(result);
        }

        private string RemoveUserFromGroup()
        {
            var boxConfig = new BoxConfig(ClientId, ClientSecret, EntrepriseId, PrivateKey,
                Passphrase, JwtPublicKey);
            var boxJWT = new BoxJWTAuth(boxConfig);

            var adminToken = boxJWT.UserToken(UserId);
            var client = boxJWT.AdminClient(adminToken);

            var membersResult = client.GroupsManager.GetAllGroupMembershipsForGroupAsync(GroupId);

            membersResult.Wait();

            string memberToRemove = null;
            foreach (var member in membersResult.Result.Entries)
                if (member.User.Login == UserIdToBeRemoved)
                    memberToRemove = member.Id;

            if (memberToRemove != null)
                client.GroupsManager.DeleteGroupMembershipAsync(memberToRemove);

            return "Success";
        }
    }
}
