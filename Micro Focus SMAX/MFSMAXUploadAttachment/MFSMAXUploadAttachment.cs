using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string executablePath;
		public string instanceURL;
		public string tenantID;
		public string username;
		public string password;
		public string recordType;
		public string recordNumber;
		public string filePath;

		public ICustomActivityResult Execute()
		{
			if(!File.Exists(executablePath))
			{
				throw new Exception("Executable Path not found! Please correctly identify location of mfsmaxupload.exe and try again.");
			}

			string commandString = "\"" + executablePath + "\" '" + username + "' " +
									"'" + password + "' '" + instanceURL + "' '" + tenantID + "' " +
									"'" + recordNumber + "' '" + recordType + "' '" + filePath + "'";

			ProcessStartInfo processInfo = new ProcessStartInfo();

			processInfo.FileName = @"powershell.exe";
			
			processInfo.Arguments = commandString;

			processInfo.RedirectStandardOutput = true;
			
			processInfo.UseShellExecute = false;
			
			processInfo.CreateNoWindow = true;

			Process process = new Process();
			
			process.StartInfo = processInfo;
			process.Start();

			var outputStandard = process.StandardOutput.ReadToEnd();

			if(String.IsNullOrEmpty(outputStandard))
			{
				throw new Exception("Error encountered.");
			}
			else
			{
				return this.GenerateActivityResult("Success");
			}
		}
	}
}