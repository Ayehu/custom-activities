using System.Data;
using System.Linq;
using System.Net;
using ZendeskApi_v2;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Ayehu.Sdk.ActivityCreation
{
    public class ActivityClass : IActivity
    {
        public string Domain = null;
        public string Username = null;
        public string ApiToken = null;


        public string TicketId = null;

        public ICustomActivityResult Execute()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
        | SecurityProtocolType.Tls11
        | SecurityProtocolType.Tls12
        | SecurityProtocolType.Ssl3;
            var api = new ZendeskApi(Domain, Username, ApiToken,"");
            var res = api.Tickets.GetTicket(long.Parse(TicketId));
            var json = JsonConvert.SerializeObject(res.Ticket);
            var jObject = Linq.JObject.Parse(json);
            var dt = new DataTable("resultSet");
            var row = dt.NewRow();
            dt.Rows.Add(row);
            foreach (var pair in jObject)
            {
                dt.Columns.Add(pair.Key);
                dt.Rows[0][pair.Key] = pair.Value.ToString();
            }
            return this.GenerateActivityResult(dt);

        }


    }



}
