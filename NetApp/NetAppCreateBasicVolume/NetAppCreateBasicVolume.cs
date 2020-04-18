using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;

namespace ActivitiesAyehu
{
    public class NetAppCreateBasicVolume : IActivity
    {
        public string IP, Username, Password;

        public string Volume, Vserver, SizeMb, VolumeType, Aggregate, ExportPolicy;

        public ICustomActivityResult Execute()
        {
            var creds = new ZapiCredentials()
            {
                ip = IP,
                username = Username,
                password = Password
            };

            var request = new CreateVolumeRequest
            {
                volumeName = Volume,
                vserver = Vserver,
                sizeMb = long.Parse(SizeMb),
                volumeType = VolumeType,
                aggregate = Aggregate,
                exportPolicy = ExportPolicy
            };

            var c = new ConcreteCmodeClient();

            var ret = c.createVolume(creds, request);
            return this.GenerateActivityResult("Success");
        }
    }
}