using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;

namespace ActivitiesAyehu
{
    public class NetAppAddIgroupInitiator : IActivity
    {
        public string IP, Username, Password;

        public string IgroupName, Vserver, Initiator;
        public bool Force;

        public ICustomActivityResult Execute()
        {
            var creds = new ZapiCredentials()
            {
                ip = IP,
                username = Username,
                password = Password
            };

            var request = new AddOrRemoveIgroupInitiatorRequest
            {
                vserver = Vserver,
                igroupName = IgroupName,
                force = Force,
                initiator = Initiator
            };

            var c = new ConcreteCmodeClient();

            var ret = c.addIgroupInitiator(creds, request);
            return this.GenerateActivityResult("Success");
        }
    }
}