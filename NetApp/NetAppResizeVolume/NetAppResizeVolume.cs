using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;

namespace ActivitiesAyehu
{
    public class NetAppResizeVolume : IActivity
    {
        public string IP, Username, Password;

        public string Volume, Vserver, NewSizeMb;

        public ICustomActivityResult Execute()
        {
            var creds = new ZapiCredentials()
            {
                ip = IP,
                username = Username,
                password = Password
            };

            var request = new ResizeVolumeRequest();
            request.volumeName = Volume;
            request.vserver = Vserver;
            request.newSizeMb = long.Parse(NewSizeMb);

            var c = new ConcreteCmodeClient();

            var ret = c.resizeVolume(creds, request);
            return this.GenerateActivityResult("Success");
        }
    }
}