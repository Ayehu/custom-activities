using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;

namespace ActivitiesAyehu
{
    public class NetAppDeleteIgroup : IActivity
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

            var request = new DeleteIgroupRequest
            {
                igroupName = IgroupName,
                vserver = Vserver,
                force = Force
            };

            var c = new ConcreteCmodeClient();

            var ret = c.deleteIgroup(creds, request);
            return this.GenerateActivityResult("Success");
        }
    }
}