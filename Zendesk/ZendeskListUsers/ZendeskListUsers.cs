using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
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
            IList<User> users = null;
            if (UserType == "admin")
                users = api.Users.GetAllAdmins().Users;
            else if (UserType == "agent")
                users = api.Users.GetAllAgents().Users;
            else
                users = api.Users.GetAllUsers().Users;

            DataTable mergedTable = null;
            foreach (var user in users)
            {
                var dt = SuccessResult(user);
                if (mergedTable == null)
                    mergedTable = dt;
                else
                {
                    mergedTable.Merge(dt, true, MissingSchemaAction.Add);
                }
            }
            return this.GenerateActivityResult(mergedTable);

        }
        static DataTable SuccessResult(User o)
        {
            DataTable dt = new DataTable("resultSet");

            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dt.Columns.Add("Id");
            dt.Rows[0]["Id"] = o.Id.Value;
            var filter = new string[] { "Abilities", "CustomFields", "Photo", "Tags" };
            o.GetType().GetProperties().ToList().ForEach(f =>
            {
                try
                {
                    if (!filter.Contains(f.Name))
                    {
                        var value = f.GetValue(o, null);
                        if (value != null)
                        {
                            dt.Columns.Add(f.Name, f.PropertyType);
                            dt.Rows[0][f.Name] = f.GetValue(o, null);
                        }
                    }
                }
                catch { }
            });
            return dt;
        }
    }



}
