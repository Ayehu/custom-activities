using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ZendeskApi_v2;
using ZendeskApi_v2.Models.Users;
namespace Ayehu.Sdk.ActivityCreation
{
    public class ActivityClass : IActivity
    {
        public string Domain = null;
        public string Username = null;
        public string ApiToken = null;

        public string UserType = null;

        public ICustomActivityResult Execute()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
        | SecurityProtocolType.Tls11
        | SecurityProtocolType.Tls12
        | SecurityProtocolType.Ssl3;
            var api = new ZendeskApi(Domain, Username, ApiToken, "");
            var users = new List<User>();
            long totalPage = 1;
            GroupUserResponse res = null;
            for (int currentPage = 1; currentPage <= 1000; currentPage++)
            {
                if (UserType == "admin")
                    res = api.Users.GetAllAdmins(100, currentPage);
                else if (UserType == "agent")
                    res = api.Users.GetAllAgents(100, currentPage);
                else if (UserType == "enduser")
                    res = api.Users.GetAllEndUsers(100, currentPage);
                else
                    res = api.Users.GetAllUsers(100, currentPage);
                totalPage = res.TotalPages;
                users.AddRange(res.Users);
                if (currentPage == totalPage)
                    break;
            }
            var dt = ItemsToDatatable(users);
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
