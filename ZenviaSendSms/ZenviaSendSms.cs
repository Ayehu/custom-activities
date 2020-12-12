using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string endpointURL;
		public string username;
		public string password;

		public string vFrom;
        public string vTo;
        public string schedule;
        public string msg;
        public string id;
        public string aggregateId;
        public string flashSms;
		public string callbackOption;

		public ICustomActivityResult Execute()
		{
			string apiURL = endpointURL;
			string contentType = "application/json;charset=UTF-8";
			string accept = "application/json";
			string method = "POST";

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL);
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Accept = accept;
				httpWebRequest.Headers.Add("Authorization", "Basic " + System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password)));
				httpWebRequest.Method = method;
				
				Dictionary<string, string> parm = new Dictionary<string, string>();
				if(vFrom != "")
					parm.Add("from", vFrom);
				if(vTo != "")
					parm.Add("to", vTo);
				if(schedule != "")
					parm.Add("schedule", schedule);
				
				if(msg != "")
					parm.Add("msg", msg);
				if(id != "")
					parm.Add("id", id);
				if(aggregateId != "")
					parm.Add("aggregateId", aggregateId);
				if(flashSms != "")
					parm.Add("flashSms", flashSms);
				if(callbackOption != "")
					parm.Add("callbackOption", callbackOption);
				
				IDictionary<string, Dictionary<string,string>> parm2 = new Dictionary<string, Dictionary<string,string>>();
				parm2.Add("sendSmsRequest",parm);
			
				ASCIIEncoding encoding = new ASCIIEncoding();
				Byte[] bytes = encoding.GetBytes(JsonConvert.SerializeObject( parm2 ));

				Stream newStream = httpWebRequest.GetRequestStream();
				newStream.Write(bytes, 0, bytes.Length);
				newStream.Close();

				var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

				using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					var response = streamReader.ReadToEnd();

					JObject jsonResults = JObject.Parse(response);
					JObject sendSmsResponse = (JObject) jsonResults["sendSmsResponse"];

					DataTable dt = new DataTable("resultSet");
					
					var sendSmsResponseData = sendSmsResponse.ToString();
					var res = ExposeJson(JObject.Parse(sendSmsResponseData))
								.ToDictionary(q => q.Key, q => q.Value);
					dt.Merge(GetDataTable(res));
					return this.GenerateActivityResult(dt);
				}
			}
			catch(WebException e)
			{
				throw new Exception(e.Message);
			}
		}

		private IDictionary<string, string> ExposeJson(JObject jObject, string append = "")
		{
			var result = new Dictionary<string, string>();

			foreach (var jProperty in jObject.Properties())
			{
				var jToken = jProperty.Value;

				if (jToken.Type == JTokenType.Object)
				{
					var nested_result = ExposeJson(jToken as JObject, jProperty.Name + "_");
					result = result.Concat(nested_result).ToDictionary(q => q.Key, q => q.Value);
				}
				else if (jToken.Type != JTokenType.Array)
				{
					result.Add(append + jProperty.Name, jProperty.Value.ToString());
				}
			}

			return result;
		}

		private DataTable GetDataTable(IReadOnlyDictionary<string, string> columns)
		{
			DataTable dt = new DataTable("resultSet");
			dt.Rows.Add(dt.NewRow());

			foreach (var col in columns)
			{
				dt.Columns.Add(col.Key);
				dt.Rows[0][col.Key] = col.Value;
			}

			return dt;
		}
	}
}