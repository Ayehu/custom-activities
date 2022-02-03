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
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string accessKey;
		public string password;
		public string region;
		public string diskSize;
		public string volumeID;

		public ICustomActivityResult Execute()
		{
			ProcessStartInfo processInfo = new ProcessStartInfo();

			processInfo.FileName = @"powershell.exe";
			
			processInfo.Arguments = string.Format("aws ec2 modify-volume --size {0} --volume-id {1}", diskSize, volumeID);
			
			processInfo.RedirectStandardError = true;
			processInfo.RedirectStandardOutput = true;
			
			processInfo.UseShellExecute = false;
			
			processInfo.CreateNoWindow = true;
			
			processInfo.EnvironmentVariables.Add("AWS_ACCESS_KEY_ID", accessKey);
			processInfo.EnvironmentVariables.Add("AWS_SECRET_ACCESS_KEY", password);
			processInfo.EnvironmentVariables.Add("AWS_DEFAULT_REGION", region);

			Process process = new Process();
			
			process.StartInfo = processInfo;
			process.Start();

			var outputError = process.StandardError.ReadToEnd();
			var outputStandard = process.StandardOutput.ReadToEnd();

			if(outputStandard == "" && outputError == "")
			{
				return this.GenerateActivityResult("Success");
			}
			else
			{
				throw new Exception(outputError);
			}
		}
	}
}