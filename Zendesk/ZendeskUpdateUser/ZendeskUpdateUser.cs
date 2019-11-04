using System;
using System.Net;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Collections.Generic;
using System.Data;
using ZendeskApi_v2;
using ZendeskApi_v2.Models.Users;

namespace Ayehu.Sdk.ActivityCreation
{
    public class ActivityClass : IActivity
    {
        public string Domain = null;
        public string Username = null;
        public string ApiToken = null;

        public string UserId = null;
        public string Email = null;
        public string Active = null;
        public string Name = null;
        public string Phone = null;
        public string Role = null;
        public string Verified = null;

        public ICustomActivityResult Execute()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
        | SecurityProtocolType.Tls11
        | SecurityProtocolType.Tls12
        | SecurityProtocolType.Ssl3;
            var api = new ZendeskApi(Domain, Username, ApiToken, "");
            var user = new User();
            user.Id = long.Parse(UserId);
            if (!string.IsNullOrEmpty(Email))
                user.Email = Email;
            if (!string.IsNullOrEmpty(Name))
                user.Name = Name;
            if (!string.IsNullOrEmpty(Phone))
                user.Phone = Phone;
            if (!string.IsNullOrEmpty(Role))
                user.Role = Role;
            if (!string.IsNullOrEmpty(Verified))
                user.Verified = bool.Parse(Verified);
            if (!string.IsNullOrEmpty(Active))
                user.Active = bool.Parse((Active));

            var res = api.Users.UpdateUser(user);
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
