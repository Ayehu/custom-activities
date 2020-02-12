using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Net;
using System.IO;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;

namespace xMatters.GetEvents
{
    class xMattersGetEvents : IActivity
    {
        public string emailAddress;
        public string passX;
        public string domainxmatters;
        public string priority;
        public string status;
        public ICustomActivityResult Execute()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            NetworkCredential myCredentials = new NetworkCredential("", "", "");
            myCredentials.UserName = emailAddress;
            myCredentials.Password = passX;
            string url = "https://" + domainxmatters + ".xmatters.com/api/xm/1/events?priority=" + priority + "&status=" + status;
            WebRequest myWebRequest = WebRequest.Create(url);
            myWebRequest.Credentials = myCredentials;
            myWebRequest.Method = "GET";
            WebResponse myWebResponse = myWebRequest.GetResponse();
            var getsponse = myWebResponse.GetResponseStream();
            StreamReader reader = new StreamReader(getsponse);
            string responseFromServer = reader.ReadToEnd();
            EventsRespondse eventsList = JsonConvert.DeserializeObject<EventsRespondse>(responseFromServer);
            DataTable dtb = new DataTable();
            dtb.Columns.Add("Id");
            dtb.Columns.Add("Name");
            dtb.Columns.Add("EventType");
            dtb.Columns.Add("SystemEventType");
            dtb.Columns.Add("FloodControl");
            dtb.Columns.Add("SubmitterId");
            dtb.Columns.Add("SubmitterTargetName");
            dtb.Columns.Add("SubmitterFirstName");
            dtb.Columns.Add("SubmitterLastName");
            dtb.Columns.Add("SubmitterRecipientType");
            dtb.Columns.Add("SubmitterRecipientLink-Self");
            dtb.Columns.Add("Priority");
            dtb.Columns.Add("Incident");
            dtb.Columns.Add("OverrideDeviceRestrictions");
            dtb.Columns.Add("EscalationOverride");
            dtb.Columns.Add("BypassPhoneIntro");
            dtb.Columns.Add("RequirePhonePassword");
            dtb.Columns.Add("EventId");
            dtb.Columns.Add("Created");
            dtb.Columns.Add("Terminated");
            dtb.Columns.Add("Status");
            dtb.Columns.Add("Links-Self");
            dtb.Columns.Add("ResponseCountsEnabled");
            foreach (var i in eventsList.data)
            {
                dtb.Rows.Add(i.id, i.name, i.eventType, i.systemEventType, i.floodControl, i.submitter.id, i.submitter.targetName, i.submitter.firstName, i.submitter.lastName, i.submitter.recipientType, i.submitter.links.self, i.priority, i.incident, i.overrideDeviceRestrictions, i.escalationOverride, i.bypassPhoneIntro, i.requirePhonePassword, i.eventId, i.created, i.terminated, i.status, i.links.self, i.responseCountsEnabled);
            }
            return this.GenerateActivityResult(dtb);
        }
    }
    public class Links
    {
        public string self { get; set; }
    }

    public class Submitter
    {
        public string id { get; set; }
        public string targetName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string recipientType { get; set; }
        public Links links { get; set; }
    }

    public class Links2
    {
        public string self { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public string name { get; set; }
        public string eventType { get; set; }
        public string systemEventType { get; set; }
        public bool floodControl { get; set; }
        public Submitter submitter { get; set; }
        public string priority { get; set; }
        public string incident { get; set; }
        public bool overrideDeviceRestrictions { get; set; }
        public bool escalationOverride { get; set; }
        public bool bypassPhoneIntro { get; set; }
        public bool requirePhonePassword { get; set; }
        public string eventId { get; set; }
        public DateTime created { get; set; }
        public DateTime terminated { get; set; }
        public string status { get; set; }
        public Links2 links { get; set; }
        public bool responseCountsEnabled { get; set; }
    }

    public class Links3
    {
        public string self { get; set; }
    }

    public class EventsRespondse
    {
        public int count { get; set; }
        public int total { get; set; }
        public List<Datum> data { get; set; }
        public Links3 links { get; set; }
    }
}
