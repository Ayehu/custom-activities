using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Box.V2.Config;
using Box.V2.JWTAuth;
using Box.V2.Models.Request;
using Box.V2.Models;
using System;
using Box.V2;

namespace ActivitiesAyehu
{
    public class BoxAddUserToGroup : IActivity
    {
        public string UserId;
        public string ClientId;
        public string ClientSecret;
        public string EntrepriseId;
        public string Passphrase;
        public string JwtPublicKey;
        public string PrivateKey;

        public string UserIdToBeAdded, GroupName;

        public ICustomActivityResult Execute()
        {
            var result = AddUserToGroup();

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

        private string AddUserToGroup()
        {
            var boxConfig = new BoxConfig(ClientId, ClientSecret, EntrepriseId, PrivateKey,
                Passphrase, JwtPublicKey);
            var boxJWT = new BoxJWTAuth(boxConfig);

            var adminToken = boxJWT.UserToken(UserId);
            var client = boxJWT.AdminClient(adminToken);

            var groupId = GetGroupIdByGroupName(client, GroupName);

            if (groupId == null)
                return "Group not found.";

            var usersRes = client.UsersManager.GetEnterpriseUsersAsync();
            usersRes.Wait();

            foreach (var user in usersRes.Result.Entries)
            {
                if (user.Login == UserIdToBeAdded)
                {
                    var memberResult = client.GroupsManager.AddMemberToGroupAsync(new BoxGroupMembershipRequest
                    {
                        User = new BoxRequestEntity { Id = user.Id },
                        Group = new BoxGroupRequest { Id = groupId }
                    });

                    memberResult.Wait();

                    memberResult.Wait();
                    if (memberResult.Exception != null)
                        return memberResult.Exception.Message;

                    return "Success";
                }
            }
            return "User Not Found";
        }
    }
}
