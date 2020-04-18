using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;
using System.Data;
using NetApp;

namespace ActivitiesAyehu
{
    public class NetAppGetObject : IActivity
    {
        public string IP, Username, Password;

        public string ObjectRequestXml;

        public ICustomActivityResult Execute()
        {
            var creds = new ZapiCredentials()
            {
                ip = IP,
                username = Username,
                password = Password
            };

            DataTable resultTable = null;

            switch (NetappInt.objectNameFromGetObjectRequest(ObjectRequestXml))
            {
                case "Export Policies":
                    resultTable = NetappInt.ProcessGetExportPoliciesRequest(ObjectRequestXml, creds);
                    break;
                case "CIFS Servers":
                    resultTable = NetappInt.ProcessGetCifsServersRequest(ObjectRequestXml, creds);
                    break;
                case "Aggregates":
                    resultTable = NetappInt.ProcessGetAggregatesRequest(ObjectRequestXml, creds);
                    break;
                case "Volumes":
                    resultTable = NetappInt.ProcessGetVolumesRequest(ObjectRequestXml, creds);
                    break;
                case "Snapmirrors":
                    resultTable = NetappInt.ProcessGetSnapmirrorRequest(ObjectRequestXml, creds);
                    break;
                case "Luns":
                    resultTable = NetappInt.ProcessGetLunsRequest(ObjectRequestXml, creds);
                    break;
                case "Lun Maps":
                    resultTable = NetappInt.ProcessGetLunMapsRequest(ObjectRequestXml, creds);
                    break;
                case "Initiator Groups":
                    resultTable = NetappInt.ProcessGetIGroupsRequest(ObjectRequestXml, creds);
                    break;
                case "Vserver Peers":
                    resultTable = NetappInt.ProcessGetVserverPeerRequest(ObjectRequestXml, creds);
                    break;
                case "Cluster Peers":
                    resultTable = NetappInt.ProcessGetClusterPeerRequest(ObjectRequestXml, creds);
                    break;
                case "Snapshots":
                    resultTable = NetappInt.ProcessGetSnapshotRequest(ObjectRequestXml, creds);
                    break;
                case "Lifs":
                    resultTable = NetappInt.ProcessGetLifsRequest(ObjectRequestXml, creds);
                    break;
                default:
                    break;
            }

            return this.GenerateActivityResult(resultTable);
        }
    }
}