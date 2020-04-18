using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;

namespace ActivitiesAyehu
{
    public class NetAppCreateLun : IActivity
    {
        public string IP, Username, Password;

        public string OsType, Vserver, Path, SizeMb;
        public bool SpaceReserved;

        public ICustomActivityResult Execute()
        {
            var creds = new ZapiCredentials()
            {
                ip = IP,
                username = Username,
                password = Password
            };

            var request = new CreateLunRequest
            {
                osType = OsType,
                vserver = Vserver,
                path = Path,
                sizeMb = long.Parse(SizeMb),
                spaceReserved = SpaceReserved
            };

            var c = new ConcreteCmodeClient();

            var ret = c.createLun(creds, request);
            return this.GenerateActivityResult("Success");
        }
    }
}