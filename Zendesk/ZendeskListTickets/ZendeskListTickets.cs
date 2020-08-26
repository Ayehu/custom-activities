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
        public string Page = null;
        public string SortBy = null;
        public string OrderBy = null;
        public string Type = null;
        public string Priority = null;
        public string Status = null;
        public string Query = null;
        private ZendeskApi api = null;
        private string Term = null;
        private long TotalPage = 1;

        public ICustomActivityResult Execute()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                   | SecurityProtocolType.Tls11
                                                   | SecurityProtocolType.Tls12
                                                   | SecurityProtocolType.Ssl3;
            api = new ZendeskApi(Domain, Username, ApiToken, "");

            if(Type == "all")
            {
                Type = null;
            }

            if(Priority == "all")
            {
                Priority = null;
            }

            if(Status == "all")
            {
                Status = null;
            }

            var termType = string.IsNullOrEmpty(Type) ? "" : "ticket_type:" + Type + " ";
            var termPriority = string.IsNullOrEmpty(Priority) ? "" : "priority:" + Priority + " ";
            var termStatus = string.IsNullOrEmpty(Status) ? "" : "status:" + Status + " ";
            var termSortBy = string.IsNullOrEmpty(SortBy) ? "" : "&sort_by=" + SortBy + " ";
            var termOrderBy = string.IsNullOrEmpty(OrderBy) ? "" : "&order_by=" + OrderBy + " ";
            
            Term = (Query + " " + termStatus + termPriority + termType + termSortBy + termOrderBy).Trim();
            
            var pageRes = api.Search.SearchFor<Ticket>(Term);
            TotalPage = pageRes.TotalPages;

            var res = api.Search.SearchFor<Ticket>(Term, page: 10);
            var tickets = GetTickets();

            return this.GenerateActivityResult(ItemsToDatatable(tickets));
        }

        private List<Ticket> GetTickets()
        {
            var page = int.Parse(string.IsNullOrEmpty(Page) ? "1" : Page);
            var tickets = new List<Ticket>();
            
            for (var i = (page - 1) * 10 + 1; i <= page * 10; i++)
            {
                if (i > TotalPage)
                    break;
                
                var res = api.Search.SearchFor<Ticket>(Term, page: i);
                tickets.AddRange(res.Results);
            }

            return tickets;
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

            if (mergedTable == null)
            {
                mergedTable = new DataTable("resultSet");
                mergedTable.Columns.Add("Result", typeof(string));
                mergedTable.Rows.Add("0");
            }

            return mergedTable;
        }
    }
}