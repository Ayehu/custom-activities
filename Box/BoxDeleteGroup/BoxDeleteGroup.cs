using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using Docker.DotNet;
using System.Collections.Generic;
using System.IO;
using Box.V2.Config;
using Box.V2.JWTAuth;

namespace ActivitiesAyehu
{
    public class BoxDeleteGroup : IActivity
    {
        public string UserId;
        public string ClientId;
        public string ClientSecret;
        public string EntrepriseId;
        public string Passphrase;
        public string JwtPublicKey;
        public string PrivateKey;

        public string GroudId;

        public ICustomActivityResult Execute()
        {
            var result = DeleteGroup();

            return this.GenerateActivityResult(result);
        }

        private string DeleteGroup()
        {
            var boxConfig = new BoxConfig(ClientId, ClientSecret, EntrepriseId, PrivateKey,
                Passphrase, JwtPublicKey);
            var boxJWT = new BoxJWTAuth(boxConfig);

            var adminToken = boxJWT.UserToken(UserId);
            var client = boxJWT.AdminClient(adminToken);

            client.GroupsManager.DeleteAsync(GroudId);

            return "Success";
        }
    }
}
