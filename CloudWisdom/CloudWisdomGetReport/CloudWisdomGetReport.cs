using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Data;
using System.IO;
using System.Net;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string username;
		public string password;
		public string reportID;
		public string startDate;
		public string endDate;
		public string reportType;

		public ICustomActivityResult Execute()
		{
			string encodedCredentials = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
			string apiURL = "https://us.cloudwisdom.virtana.com/cbs/report/ec2Recommendation/recommendedType";
			string contentType = "application/json";
			string accept = "application/json";
			string method = "POST";
			string jsonBody = "{ \"reportId\": \"" + reportID + "\", \"startDate\": \"" + startDate + "\", \"endDate\": \"" + endDate + "\", \"savingsPeriod\": \"month\", \"perfStatistic\": \"m_perc95\", \"instanceConstraints\": [], \"cpuConstraint\": { \"cpuBasis\": \"vcpu\", \"maxUtil\": 95, \"rule\": \"dynamic\", \"fixedFloor\": 2 }, \"memoryConstraint\": { \"maxUtil\": 95, \"defaultValue\": 60, \"rule\": \"dynamic\", \"fixedFloor\": 2 } }";

			try
			{
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL);
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Accept = accept;
				httpWebRequest.Headers.Add("Authorization", "Basic " + encodedCredentials);
				httpWebRequest.Method = method;

				using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					streamWriter.Write(jsonBody);
					streamWriter.Flush();
					streamWriter.Close();

					var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

					if(httpResponse.StatusCode.ToString() == "OK")
					{
						using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
						{
							var responseString = streamReader.ReadToEnd();

							JObject jsonResults = JObject.Parse(responseString);
							
							JArray recommendations = (JArray)jsonResults["data"]["recommendations"];

							int recommendationCount = recommendations.Count;

							if(recommendationCount == 0)
							{
								return this.GenerateActivityResult("Empty");
							}
							else
							{
								DataTable dt = new DataTable("resultSet");

								if(reportType == "Simple (EC2)")
								{
									dt.Rows.Add(dt.NewRow());

									dt.Columns.Add("elementId");
									dt.Columns.Add("elementType");
									dt.Columns.Add("name");
									dt.Columns.Add("currentType");
									dt.Columns.Add("proposedType");
									dt.Columns.Add("saving");

									for(int i = 0; i < recommendationCount; i ++)
									{
										dt.Rows[i]["elementId"] = (string)jsonResults["data"]["recommendations"][i]["elementId"];
										dt.Rows[i]["elementType"] = (string)jsonResults["data"]["recommendations"][i]["elementType"];
										dt.Rows[i]["name"] = (string)jsonResults["data"]["recommendations"][i]["name"];
										dt.Rows[i]["currentType"] = (string)jsonResults["data"]["recommendations"][i]["currentType"]["instanceType"];
										dt.Rows[i]["proposedType"] = (string)jsonResults["data"]["recommendations"][i]["proposedType"]["instanceType"];
										dt.Rows[i]["saving"] = (string)jsonResults["data"]["recommendations"][i]["saving"]["saving"];

										if(i < recommendationCount - 1)
										{
											dt.Rows.Add(dt.NewRow());
										}
									}
								}
								else
								{
									for(int i = 0; i < recommendationCount; i ++)
									{
										dt.Rows.Add(dt.NewRow());

										JObject recommendationDetails = JObject.Parse(jsonResults["data"]["recommendations"][i].ToString());

										foreach(JProperty property in recommendationDetails.Properties())
										{
											if(!dt.Columns.Contains(property.Name))
											{
												dt.Columns.Add(property.Name);
											}

											dt.Rows[i][property.Name] = property.Value;
										}
									}
								}

								return this.GenerateActivityResult(dt);
							}
						}
					}
					else
					{
						return this.GenerateActivityResult("Error (" + httpResponse.StatusCode.ToString() + ")");
					}
				}
			}
			catch(WebException e)
			{
				return this.GenerateActivityResult("Error (" + e.Message + ")");
			}
		}
	}
}