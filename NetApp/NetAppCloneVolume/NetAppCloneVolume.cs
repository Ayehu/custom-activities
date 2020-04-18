using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;

namespace ActivitiesAyehu
{
    public class NetAppCloneVolume : IActivity
    {
        public string IP, Username, Password;

        public string Volume, Vserver, ParentSnapshot, ParentVolume;

        public ICustomActivityResult Execute()
        {
            var creds = new ZapiCredentials()
            {
                ip = IP,
                username = Username,
                password = Password
            };

            var request = new CloneVolumeRequest();
            request.volumeName = Volume;
            request.vserver = Vserver;
            request.parentSnapshot = ParentSnapshot;
            request.parentVolume = ParentVolume;

            var c = new ConcreteCmodeClient();

            var ret = c.cloneVolume(creds, request);
            return this.GenerateActivityResult("");
        }
    }
}