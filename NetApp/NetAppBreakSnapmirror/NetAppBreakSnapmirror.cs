using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;

namespace ActivitiesAyehu
{
    public class NetAppBreakSnapmirror : IActivity
    {
        public string IP, Username, Password;

        public string DestinationVolume, DestinationVserver;

        public ICustomActivityResult Execute()
        {
            var creds = new ZapiCredentials()
            {
                ip = IP,
                username = Username,
                password = Password
            };

            var request = new BreakSnapmirrorRequest
            {
                destinationVolume = DestinationVolume,
                destinationVserver = DestinationVserver
            };

            var c = new ConcreteCmodeClient();

            var ret = c.breakSnapmirror(creds, request);
            return this.GenerateActivityResult("Success");
        }
    }
}