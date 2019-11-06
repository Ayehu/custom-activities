using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Box.V2.Config;
using Box.V2.JWTAuth;
using Box.V2;

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

        public string UserIdToBeRemoved, GroupName;

        public ICustomActivityResult Execute()
        {
            var result = RemoveUserFromGroup();

            return this.GenerateActivityResult(result);
        }

        private string GetGroupIdByGroupName(BoxClient client, string groupName)
        {
            var groupsRes = client.GroupsManager.GetAllGroupsAsync();

            groupsRes.Wait();

            foreach (var g in groupsRes.Result.Entries)
            {
                if (g.Name == groupName)
                    return g.Id;
            }
            return null;
        }

        private string RemoveUserFromGroup()
        {
            var boxConfig = new BoxConfig(ClientId, ClientSecret, EntrepriseId, PrivateKey,
                Passphrase, JwtPublicKey);
            var boxJWT = new BoxJWTAuth(boxConfig);

            var adminToken = boxJWT.UserToken(UserId);
            var client = boxJWT.AdminClient(adminToken);

            var groupId = GetGroupIdByGroupName(client, GroupName);

            if (groupId == null)
                return "Group not found.";

            var membersResult = client.GroupsManager.GetAllGroupMembershipsForGroupAsync(groupId);

            membersResult.Wait();

            foreach (var member in membersResult.Result.Entries)
                if (member.User.Login == UserIdToBeRemoved)
                {
                    var res = client.GroupsManager.DeleteGroupMembershipAsync(member.Id);

                    res.Wait();
                    if (res.Exception != null)
                        return res.Exception.Message;

                    return "Success";
                }

            return "User Not Found";
        }
    }
}
