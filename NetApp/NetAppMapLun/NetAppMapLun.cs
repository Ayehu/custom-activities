using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;

namespace ActivitiesAyehu
{
    public class NetAppMapLun : IActivity
    {
        public string IP, Username, Password;

        public string Vserver, Path, LunId, Igroup;

        public ICustomActivityResult Execute()
        {
            var creds = new ZapiCredentials()
            {
                ip = IP,
                username = Username,
                password = Password
            };

            var c = new ConcreteCmodeClient();

            var ret = c.lunMap(creds, Vserver, Path, int.Parse(LunId), Igroup);
            return this.GenerateActivityResult("Success");
        }
    }
}