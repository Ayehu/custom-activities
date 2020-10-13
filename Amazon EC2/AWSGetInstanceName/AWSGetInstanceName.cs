using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string accessKey;
		public string secretKey;
		public string region;
		public string instanceID;

		public ICustomActivityResult Execute()
		{
			ProcessStartInfo processInfo = new ProcessStartInfo();

			processInfo.FileName = @"powershell.exe";
			
			processInfo.Arguments = string.Format("aws ec2 describe-instances --instance-ids {0}", instanceID);
			
			processInfo.RedirectStandardOutput = true;
			
			processInfo.UseShellExecute = false;
			
			processInfo.CreateNoWindow = true;
			
			processInfo.EnvironmentVariables.Add("AWS_ACCESS_KEY_ID", accessKey);
			processInfo.EnvironmentVariables.Add("AWS_SECRET_ACCESS_KEY", secretKey);
			processInfo.EnvironmentVariables.Add("AWS_DEFAULT_REGION", region);

			Process process = new Process();
			
			process.StartInfo = processInfo;
			process.Start();

			var outputStandard = process.StandardOutput.ReadToEnd();

			if(String.IsNullOrEmpty(outputStandard))
			{
				throw new Exception("An error was encountered.  Please ensure that all input parameters are correct.");
			}
			else
			{
				JObject jsonResults = JObject.Parse(outputStandard);

				string tagsJson = jsonResults["Reservations"][0]["Instances"][0]["Tags"].ToString();

				JArray tagsJsonArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(tagsJson);

				string instanceName = "";

				foreach(var item in tagsJsonArray)
				{
					if(item["Key"].ToString() == "Name")
					{
						instanceName = item["Value"].ToString();
					}
				}

				if(String.IsNullOrEmpty(instanceName))
				{
					throw new Exception("Instance does not have a name.");
				}
				else
				{
					return this.GenerateActivityResult(instanceName);
				}
			}
		}
	}
}