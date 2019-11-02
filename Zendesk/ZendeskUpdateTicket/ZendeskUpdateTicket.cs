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
        public string GroupId =null;
        public string Status = null;
        public ICustomActivityResult Execute()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
        | SecurityProtocolType.Tls11
        | SecurityProtocolType.Tls12
        | SecurityProtocolType.Ssl3;
            var api = new ZendeskApi(Domain, Username, ApiToken,"");
            var ticket = new Ticket();
            Comment comment = null;
            if(!string.IsNullOrEmpty(Comment))
            {
                comment = new Comment();
                comment.Body = Comment;
            }
            if (!string.IsNullOrEmpty(Subject))
                ticket.Subject = Subject;
            if (!string.IsNullOrEmpty(Type))
                ticket.Type = Type;
            if (!string.IsNullOrEmpty(Priority))
                ticket.Priority = Priority;
            if (!string.IsNullOrEmpty(GroupId))
                ticket.GroupId = long.Parse(GroupId);
            if (!string.IsNullOrEmpty(Status))
                ticket.Status = Status;
            var res=api.Tickets.UpdateTicket(ticket,comment);
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
