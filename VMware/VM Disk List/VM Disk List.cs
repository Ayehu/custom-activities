using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity: IActivity
	{
		private const string POWERCLI_NAME = "VMware.VimAutomation.Core";

		public string HostName = "";
		public string UserName = "";
		public string Password = "";
		public string vmName;

		public ICustomActivityResult Execute()
		{
			DataTable dataTable = new DataTable("resultSet");

			string Command = "Get-HardDisk -VM '" + vmName + "'";

			using (PowerShellProcessInstance instance = new PowerShellProcessInstance(new Version(4, 0), null, null, false))
			{
				using (var runspace = RunspaceFactory.CreateOutOfProcessRunspace(new TypeTable(new string[0]), instance))
				{
					runspace.Open();

					using (PowerShell powerShellInstance = PowerShell.Create(RunspaceMode.NewRunspace))
					{
						powerShellInstance.Runspace = runspace;

						// --------------- 
						ExecuteScript(powerShellInstance, "Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope Process -Force ");

						// --------------- 
						var version = ExecuteScript(powerShellInstance, @"$PSVersionTable.PSVersion");
						var element = version.First();
						var powershellVersion = element.BaseObject as System.Version;
						// System.Diagnostics.Trace.WriteLine($"=== Locally installed Powershell version: {powershellVersion.ToString()}");

						// Snapins cmdlets could be not installed
						// https://github.com/PowerShell/PowerShell/issues/6135
						var pssapinInstalled = ExecuteScript(powerShellInstance, @"Get-Command | where { $_.Name -eq 'Get-PSSnapin'}");
						
						if (pssapinInstalled.Any() == true)
						{
							// Check if SnapIn already loaded
							var loadedSnapins = ExecuteScript(powerShellInstance, "Get-PSSnapin");

							if (loadedSnapins.Any(item => item.ToString().StartsWith(POWERCLI_NAME, StringComparison.OrdinalIgnoreCase)) == true)
							{
								// Already loaded
							}
							else
							{
								// Check if could be loaded
								var registedSnapins = ExecuteScript(powerShellInstance, "Get-PSSnapin -Registered");
								if (registedSnapins.Any(item => item.ToString().StartsWith(POWERCLI_NAME, StringComparison.OrdinalIgnoreCase)) == true)
								{
									// Load SnapIn
									ExecuteScript(powerShellInstance, "Add-PSSnapin -Name '" + POWERCLI_NAME + "'");
								}
								else
								{
									// VMware.VimAutomation.Core Snapin is not installed - so may be it in modules ?
									LoadWithModules(powerShellInstance);
								}
							}
						}
						else
						{
							LoadWithModules(powerShellInstance);
						}

						// Normalization command that will handle incorrect certificates 
						ExecuteScript(powerShellInstance, @"Set-PowerCLIConfiguration -DefaultVIServerMode Single -InvalidCertificateAction Ignore -Scope Session  -Confirm:$false");

						// Fix case where Username send domain\username to just username
						if (UserName.Contains("\\"))
						{
							UserName = UserName.Substring(UserName.LastIndexOf("\\") + 1);
						}

						// Connect
						var connectionInfo = ExecuteScript(powerShellInstance, "Connect-VIServer -Server '" + HostName + "' -User '" + UserName + "' -Password '" + Password + "' -ErrorAction Continue", "Username is: " + UserName + " Password: " + Password + " for host: " + HostName);

						// Actual command
						if (string.IsNullOrEmpty(Command) == false)
						{
							var commandResult = ExecuteScript(powerShellInstance, Command);

							commandResult.ToList().ForEach(item =>
							{
								var row = dataTable.NewRow();

								item.Properties.ToList().ForEach(details =>
								{
									if (dataTable.Columns.Contains(details.Name) == false)
									{
										dataTable.Columns.Add(details.Name);
									}

									row[details.Name] = details.Value;
								});

								if (row.ItemArray.Any() == true)
								{
									dataTable.Rows.Add(row);
								}
							});
						}
						else
						{
							// No command provided - nothing to do
						}
					}

					runspace.Close();
					runspace.Dispose();
				}
			}

			return this.GenerateActivityResult(dataTable);
            //return this.GenerateActivityResult("Success");
		}

		private IEnumerable<PSObject> ExecuteScript(PowerShell session, string script, string additionalData = "")
		{
			session.AddScript(script);

			var result = session.Invoke();

			if ((session.HadErrors == true) && (session.Streams.Error.Count > 0))
			{
				var errorMessage = session.Streams.Error
													.Select(error => error.Exception.Message)
													.Aggregate(string.Empty, (accum, item) => accum + item + "\n");

				errorMessage += "\n" + additionalData;

				session.Commands.Clear();
				session.Streams.ClearStreams();

				throw new ApplicationException("Error encountered during execution!\nAdditional information:\n" + errorMessage);
			}

			session.Commands.Clear();
			session.Streams.ClearStreams();

			return result;
		}

		private void LoadWithModules(PowerShell powerShellInstance)
		{
			var loadedModules = ExecuteScript(powerShellInstance, "Get-Module");
			
			if (loadedModules.Any(item => item.ToString().StartsWith(POWERCLI_NAME, StringComparison.OrdinalIgnoreCase)) == true)
			{
				// Module already loaded for this session
			}
			else
			{
				var availableModules = ExecuteScript(powerShellInstance, "Get-Module -ListAvailable");
				
				if (availableModules.Any(item => item.ToString().StartsWith(POWERCLI_NAME, StringComparison.OrdinalIgnoreCase)) == true)
				{
					// Module exist - we should load it
					ExecuteScript(powerShellInstance, "Import-Module -Name '" + POWERCLI_NAME + "'");
				}
				else
				{
					// Module does not exist at all
					throw new ApplicationException("Module '" + POWERCLI_NAME + "' does not exist! Not installed?");
				}
			}
		}
	}
}