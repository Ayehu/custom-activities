using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;

namespace ActivitiesAyehu
{
    public class NetAppCreateExportRule : IActivity
    {
        public string IP, Username, Password;

        public string PolicyName, Vserver, SuperuserRule, ClientMatch, RoRule, RwRule;

        public ICustomActivityResult Execute()
        {
            var creds = new ZapiCredentials()
            {
                ip = IP,
                username = Username,
                password = Password
            };

            var request = new ExportRuleRequest()
            {
                policyName = PolicyName,
                superuserRule = SuperuserRule,
                clientMatch = ClientMatch,
                roRule = RoRule,
                rwRule = RwRule,
                vserver = Vserver
            };

            var c = new ConcreteCmodeClient();

            var ret = c.createExportRule(creds, request);
            return this.GenerateActivityResult("Success");
        }
    }
}