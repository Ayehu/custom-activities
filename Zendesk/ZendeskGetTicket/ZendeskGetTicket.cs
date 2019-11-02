using System.Data;
using System.Linq;
using System.Net;
using ZendeskApi_v2;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
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
            return this.GenerateActivityResult(SuccessResult(res.Ticket));

        }

       
        private DataTable SuccessResult(object o)
        {
            DataTable dt = new DataTable("resultSet");

            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            var filter = new string[] { "CollaboratorIds", "Tags", "CustomFields", "Via" };
            o.GetType().GetProperties().ToList().ForEach(f =>
            {
                try
                {
                    if (!filter.Contains(f.Name))
                    {
                        f.GetValue(o, null);
                        dt.Columns.Add(f.Name, f.PropertyType);
                        dt.Rows[0][f.Name] = f.GetValue(o, null);
                    }
                }
                catch { }
            });
            return dt;
        }

    }



}
