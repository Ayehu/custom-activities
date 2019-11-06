using System;
using System.Net;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Collections.Generic;
using System.Data;
using ZendeskApi_v2;
using ZendeskApi_v2.Models.Tickets;

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
            var res = api.Tickets.Delete(long.Parse(TicketId));
            return this.GenerateActivityResult(SuccessResult());

        }

       
        private DataTable SuccessResult()
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result", typeof(string));
            dt.Rows.Add("Success");
            return dt;
        }

    }



}
