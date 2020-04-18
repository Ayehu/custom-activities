using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;

namespace ActivitiesAyehu
{
    public class NetAppCreateIgroup : IActivity
    {
        public string IP, Username, Password;

        public string IgroupName, Vserver, OsType, IgroupType;

        public ICustomActivityResult Execute()
        {
            var creds = new ZapiCredentials()
            {
                ip = IP,
                username = Username,
                password = Password
            };

            var request = new CreateIgroupRequest
            {
                igroupName = IgroupName,
                igroupType = IgroupType,
                osType = OsType,
                vserver = Vserver
            };

            var c = new ConcreteCmodeClient();

            var ret = c.createIgroup(creds, request);
            return this.GenerateActivityResult("Success");
        }
    }
}