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


        public string UserId = null;
        public string NewPassword = null;

        public ICustomActivityResult Execute()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
        | SecurityProtocolType.Tls11
        | SecurityProtocolType.Tls12
        | SecurityProtocolType.Ssl3;
            var api = new ZendeskApi(Domain, Username, ApiToken, "");

            var success=api.Users.SetUsersPassword(long.Parse(UserId), NewPassword);
            var result=success?"Success":"Fail";
            return this.GenerateActivityResult(SuccessResult(result));

        }
      
        static DataTable SuccessResult(string result)
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result", typeof(string));
            dt.Rows.Add(result);
            return dt;
        }

    }



}
