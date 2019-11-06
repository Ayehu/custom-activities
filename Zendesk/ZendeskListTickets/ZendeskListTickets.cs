using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using ZendeskApi_v2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ZendeskApi_v2.Models.Tickets;
namespace Ayehu.Sdk.ActivityCreation
{
    public class ActivityClass : IActivity
    {
        public string Domain = null;
        public string Username = null;
        public string ApiToken = null;


        public ICustomActivityResult Execute()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                   | SecurityProtocolType.Tls11
                                                   | SecurityProtocolType.Tls12
                                                   | SecurityProtocolType.Ssl3;
            var api = new ZendeskApi(Domain, Username, ApiToken, "");
            var tickets = new List<Ticket>();
            long totalPage = 1;
            for (int currentPage = 1; currentPage <= 10; currentPage++)
            {
                IList<Ticket> pageTickets = null;
                var res = api.Tickets.GetAllTickets(100,currentPage);
                pageTickets = res.Tickets;
                tickets.AddRange(pageTickets);
                totalPage = res.TotalPages;
                if (currentPage == totalPage)
                    break;
            }

            var dt = ItemsToDatatable(tickets);
            return this.GenerateActivityResult(dt);
        }
        private DataTable ItemsToDatatable(IEnumerable<object> items)
        {
            DataTable mergedTable = null;

            foreach (var item in items)
            {
                var json = JsonConvert.SerializeObject(item);
                var jObject = JObject.Parse(json);
                var dt = new DataTable("resultSet");
                var row = dt.NewRow();
                dt.Rows.Add(row);
                foreach (var pair in jObject)
                {
                    dt.Columns.Add(pair.Key);
                    dt.Rows[0][pair.Key] = pair.Value.ToString();
                }
                if (mergedTable == null)
                    mergedTable = dt;
                else
                {
                    mergedTable.Merge(dt, true, MissingSchemaAction.Add);
                }
            }

            return mergedTable;
        }
    }



}
