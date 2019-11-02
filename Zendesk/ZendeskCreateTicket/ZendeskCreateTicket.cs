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


        public string Comment = null;
        public string Subject = null;
        public string Type = null;
        public string Priority = null;

        public ICustomActivityResult Execute()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
        | SecurityProtocolType.Tls11
        | SecurityProtocolType.Tls12
        | SecurityProtocolType.Ssl3;
            var api = new ZendeskApi(Domain, Username, ApiToken,"");
            var ticket = new Ticket();
            ticket.Comment = new Comment();
            ticket.Comment.Body = Comment;
            ticket.Subject = Subject;
            ticket.Type = Type;
            ticket.Priority = Priority;
            var res = api.Tickets.CreateTicket(ticket);
            var id = res.Ticket.Id;
            return this.GenerateActivityResult(SuccessResult(id.Value));

        }

       
        private DataTable SuccessResult(long id)
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result", typeof(string));
            dt.Rows.Add(id);
            return dt;
        }

    }



}
