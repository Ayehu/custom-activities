using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string host;

		public ICustomActivityResult Execute()
		{
			ProcessStartInfo processInfo = new ProcessStartInfo();

			processInfo.FileName = @"powershell.exe";
			
			processInfo.Arguments = string.Format("Resolve-DnsName -Name {0} | ConvertTo-Json", host);
			
			processInfo.RedirectStandardError = true;
			processInfo.RedirectStandardOutput = true;
			
			processInfo.UseShellExecute = false;
			
			processInfo.CreateNoWindow = true;

			Process process = new Process();
			
			process.StartInfo = processInfo;
			process.Start();

			var outputError = process.StandardError.ReadToEnd();
			var outputStandard = process.StandardOutput.ReadToEnd();

			if(outputError != "")
			{
				throw new Exception(outputError);
			}
			else
			{
				outputStandard = "{ \"root\": " + outputStandard + " }";

				JObject jsonResults = JObject.Parse(outputStandard);
				JArray resultArray = (JArray)jsonResults["root"];
				int resultCount = resultArray.Count;

				DataTable dt = new DataTable("resultSet");

				for(int i = 0; i < resultCount; i ++)
				{
					dt.Rows.Add(dt.NewRow());

					JObject resultDetails = JObject.Parse(jsonResults["root"][i].ToString());

					foreach(JProperty property in resultDetails.Properties())
					{
						if(!dt.Columns.Contains(property.Name))
						{
							dt.Columns.Add(property.Name);
						}

						dt.Rows[i][property.Name] = property.Value;
					}
				}

				return this.GenerateActivityResult(dt);
			}
		}
	}
}