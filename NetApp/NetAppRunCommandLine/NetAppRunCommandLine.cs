using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;

namespace ActivitiesAyehu
{
    public class NetAppRunCommandLine : IActivity
    {
        public string IP, Username, Password;

        public string Command;

        public ICustomActivityResult Execute()
        {
            var creds = new ZapiCredentials()
            {
                ip = IP,
                username = Username,
                password = Password
            };

            var c = new ConcreteCmodeClient();

            var ret = c.runCli(creds, Command);

            return this.GenerateActivityResult(ret);
        }
    }
}