using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;

namespace ActivitiesAyehu
{
    public class NetAppCreateSnapmirror : IActivity
    {
        public string IP, Username, Password;

        public string SourceVolume, SourceVserver, SourceCluster, DestinationVServer, DestinationVolume;

        public ICustomActivityResult Execute()
        {
            var creds = new ZapiCredentials()
            {
                ip = IP,
                username = Username,
                password = Password
            };

            var request = new CreateSnapmirrorRequest
            {
                sourceVserver = SourceVserver,
                sourceVolume = SourceVolume,
                sourceCluster = SourceCluster,
                destinationVserver = DestinationVServer,
                destinationVolume = DestinationVolume
            };

            var c = new ConcreteCmodeClient();

            var ret = c.createSnapmirror(creds, request);
            return this.GenerateActivityResult("Success");
        }
    }
}