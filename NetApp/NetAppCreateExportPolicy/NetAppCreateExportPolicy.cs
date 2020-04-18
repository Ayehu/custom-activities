using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;

namespace ActivitiesAyehu
{
    public class NetAppCreateExportPolicy : IActivity
    {
        public string IP, Username, Password;

        public string PolicyName, Vserver;

        public ICustomActivityResult Execute()
        {
            var creds = new ZapiCredentials()
            {
                ip = IP,
                username = Username,
                password = Password
            };

            var request = new ExportPolicyRequest()
            {
                policyName = PolicyName,
                vserver = Vserver
            };

            var c = new ConcreteCmodeClient();

            var ret = c.createExportPolicy(creds, request);
            return this.GenerateActivityResult("");
        }
    }
}