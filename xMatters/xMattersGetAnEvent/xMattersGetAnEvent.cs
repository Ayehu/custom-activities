using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Net;
using System.IO;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;

namespace xMatters.GetAnEvents
{
    class xMattersGetAnEvents : IActivity
    {
        public string emailAddress;
        public string password;
        public string domainxmatters;
        public string eventId;
        public ICustomActivityResult Execute()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            NetworkCredential myCredentials = new NetworkCredential("", "", "");
            myCredentials.UserName = emailAddress;
            myCredentials.Password = password;
            string Message = string.Empty;
            string url = "https://" + domainxmatters + ".xmatters.com/api/xm/1/events/" + eventId;
            WebRequest myWebRequest = WebRequest.Create(url);
            myWebRequest.Credentials = myCredentials;
            myWebRequest.Method = "GET";
            WebResponse myWebResponse = myWebRequest.GetResponse();
            var getsponse = myWebResponse.GetResponseStream();
            StreamReader reader = new StreamReader(getsponse);
            string responseFromServer = reader.ReadToEnd();
            RootObject e = JsonConvert.DeserializeObject<RootObject>(responseFromServer);
            DataTable dtb = new DataTable();
            dtb.Columns.Add("Id");
            dtb.Columns.Add("Name");
            dtb.Columns.Add("EventType");
            dtb.Columns.Add("SystemEventType");
            dtb.Columns.Add("FloodControl");
            dtb.Columns.Add("SubmitterId");
            dtb.Columns.Add("Recipients-Data-Id");
            dtb.Columns.Add("Priority");
            dtb.Columns.Add("Incident");
            dtb.Columns.Add("ExpirationInMinutes");
            dtb.Columns.Add("NotificationAuditCount");
            dtb.Columns.Add("OverrideDeviceRestrictions");
            dtb.Columns.Add("EscalationOverride");
            dtb.Columns.Add("BypassPhoneIntro");
            dtb.Columns.Add("RequirePhonePassword");
            dtb.Columns.Add("VoiceMailOptions-Leave");
            dtb.Columns.Add("EventId");
            dtb.Columns.Add("Created");
            dtb.Columns.Add("Terminated");
            dtb.Columns.Add("Status");
            dtb.Columns.Add("Links-Self");
            dtb.Columns.Add("ResponseCountsEnabled");
            dtb.Rows.Add(e.id, e.name, e.eventType, e.systemEventType, e.floodControl, e.submitter.id, e.recipients.data[0].id, e.priority, e.incident, e.expirationInMinutes, e.notificationAuditCount, e.overrideDeviceRestrictions, e.escalationOverride, e.bypassPhoneIntro, e.requirePhonePassword, e.voicemailOptions, e.eventId, e.created, e.terminated, e.status, e.links.self, e.responseCountsEnabled);
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

    public class Owner
    {
        public string id { get; set; }
        public string targetName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string recipientType { get; set; }
        public Links2 links { get; set; }
    }

    public class Provider
    {
        public string id { get; set; }
    }

    public class Datum2
    {
        public string id { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public string targetName { get; set; }
        public string deviceType { get; set; }
        public string description { get; set; }
        public string testStatus { get; set; }
        public bool externallyOwned { get; set; }
        public bool defaultDevice { get; set; }
        public string priorityThreshold { get; set; }
        public int sequence { get; set; }
        public int delay { get; set; }
        public Owner owner { get; set; }
        public Links3 links { get; set; }
        public bool targeted { get; set; }
        public string recipientType { get; set; }
        public string status { get; set; }
        public Provider provider { get; set; }
    }

    public class Links4
    {
        public string self { get; set; }
    }

    public class Recipients
    {
        public int count { get; set; }
        public int total { get; set; }
        public List<Datum2> data { get; set; }
        public Links4 links { get; set; }
    }

    public class VoicemailOptions
    {
        public int retry { get; set; }
        public int every { get; set; }
        public string leave { get; set; }
    }

    public class Links5
    {
        public string self { get; set; }
    }

    public class RootObject
    {
        public string id { get; set; }
        public string name { get; set; }
        public string eventType { get; set; }
        public string systemEventType { get; set; }
        public bool floodControl { get; set; }
        public Submitter submitter { get; set; }
        public Recipients recipients { get; set; }
        public string priority { get; set; }
        public string incident { get; set; }
        public int expirationInMinutes { get; set; }
        public int notificationAuditCount { get; set; }
        public bool overrideDeviceRestrictions { get; set; }
        public bool escalationOverride { get; set; }
        public bool bypassPhoneIntro { get; set; }
        public bool requirePhonePassword { get; set; }
        public VoicemailOptions voicemailOptions { get; set; }
        public string eventId { get; set; }
        public DateTime created { get; set; }
        public DateTime terminated { get; set; }
        public string status { get; set; }
        public Links5 links { get; set; }
        public bool responseCountsEnabled { get; set; }
    }
}
