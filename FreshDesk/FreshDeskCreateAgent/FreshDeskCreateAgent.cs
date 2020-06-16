using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ActivitiesAyehu
{
    public class FreshDeskCreateAgent: IActivity
    {
        public string fdDomain, apiKey;
        public string email, agentName, language, group_ids, role_ids, skill_ids, ticket_scope;
        public bool occasional;

        public ICustomActivityResult Execute()
        {
            string apiPath = "/api/v2/agents";

            var body = new JObject();
            body["name"] = agentName;
            body["email"] = email;
            body["occasional"] = occasional;
            body["language"] = language;
            body["ticket_scope"] = int.Parse(ticket_scope.Split(' ')[0]);
            if (group_ids != null)
            {
                var groups = new JArray();
                foreach (var g in group_ids.Split(','))
                    if (g != "") groups.Add(Int64.Parse(g));
                body["group_ids"] = groups;

            }

            if (role_ids != null)
            {
                var roles = new JArray();
                foreach (var r in role_ids.Split(','))
                    if (r != "") roles.Add(Int64.Parse(r));
                body["role_ids"] = roles; // Account Administrator - 65000002992, Administrator - 65000002993, supervisor - 65000002994, agent - 65000002995
            }

            if (skill_ids != null)
            {
                var skills = new JArray();
                foreach (var r in skill_ids.Split(','))
                    if (r != "") skills.Add(Int64.Parse(r));
                body["skill_ids"] = skills;
            }

            var bodyStr = JsonConvert.SerializeObject(body);

            var ret = MakeHttpRequest(apiPath, "POST", bodyStr);

            return this.GenerateActivityResult("Success");
        }

        private string MakeHttpRequest(string apiPath, string method, string body = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://" + fdDomain + ".freshdesk.com" + apiPath);
            request.ContentType = "application/json";
            request.Method = method;
            string authInfo = apiKey + ":X";
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;

            Stream dataStream;
            if (body != null)
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(body);
                request.ContentLength = byteArray.Length;
                dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
            }
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseStr = reader.ReadToEnd();

            return responseStr;
        }
    }
}
