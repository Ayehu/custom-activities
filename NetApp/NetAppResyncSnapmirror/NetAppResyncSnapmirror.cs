using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;

namespace ActivitiesAyehu
{
    public class NetAppResyncSnapmirror : IActivity
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

            var request = new ResyncSnapmirrorRequest
            {
                destinationVolume = DestinationVolume,
                destinationVserver = DestinationVserver
            };

            var c = new ConcreteCmodeClient();

            var ret = c.resyncSnapmirror(creds, request);
            return this.GenerateActivityResult("Success");
        }
    }
}