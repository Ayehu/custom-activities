using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string PowershellTimeOut;
		public string HostName;
		public string UserName;
		public string Password;
		public string PsrPort;
		public string UriType;
		public string ScriptCode;
		public string ScriptPath;
		public int HasParams = 0;
		public string TableAsString;
		public string dateFormat;

		public ICustomActivityResult Execute()
		{
			ScriptCode = @"
			$User = Get-WinEvent -Computer localhost -FilterHashtable @{Logname='Security';ID=4672} -MaxEvents 1 | select @{N='User';E={$_.Properties[1].Value}} | format-table -HideTableHeaders
			$Date = Get-WinEvent -Computer localhost -FilterHashtable @{Logname='Security';ID=4672} -MaxEvents 1 | Select -ExpandProperty TimeCreated
			$Date2 = Out-String -InputObject $Date
			$Date3 = [DateTime]$Date2
			$OutputFormat = """ + dateFormat + @"""
			$DateFinal = ($Date3).ToString($OutputFormat)
			Write-Output '[ { ""DateTime"": ""' $DateFinal '"", ""Username"": ""' $User '"" } ]'
			";

			string output = String.Empty;

			try
			{
				if(string.IsNullOrEmpty(HostName))
				{
					throw new Exception("Host value is empty.");
				}
				if(HostName.ToLower().Equals("localhost") || HostName.ToLower().Equals("127.0.0.1"))
				{
					output = ExecuteLocal(ScriptPath, ScriptCode, HasParams, TableAsString);

					if(output.Contains("<Result>"))
					{
						output = ExtractString(output, "Result");

						if(output.Contains("[") && output.Contains("]"))
						{
							output = "{ \"root\": " + output + " }";
						}
						else
						{
							output = "{ \"root\": [ " + output + " ] }";
						}

						JObject jsonResults = JObject.Parse(output);
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

								dt.Rows[i][property.Name] = Regex.Replace(property.Value.ToString(), @"^\s+|\s+$|\s+(?=\s)", "");
							}
						}

						return this.GenerateActivityResult(dt);
					}
					else
					{
						throw new Exception("No page files found.");
					}
				}
				else
				{
					output = ExecuteRemote(PowershellTimeOut, HostName, UserName, Password, PsrPort, UriType, ScriptCode, ScriptPath, HasParams.ToString(), TableAsString);

                    if(output.Contains("<Result>"))
					{
						output = ExtractString(output, "Result");

						if(output.Contains("[") && output.Contains("]"))
						{
							output = "{ \"root\": " + output + " }";
						}
						else
						{
							output = "{ \"root\": [ " + output + " ] }";
						}

						JObject jsonResults = JObject.Parse(output);
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
					else
					{
						throw new Exception("No login sessions found.");
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}

		private string ExecuteRemote(string PowershellTimeOut, string HostName, string UserName, string Password, string PsrPort, string UriType, string ScriptCode, string ScriptPath, string HasParams, string TableAsString)
		{
			string Argument = string.Empty;
			string sTxtResult;
			Process myProcess = new Process();

			try
			{
				Argument = PowershellTimeOut + " " + (string.IsNullOrEmpty(HostName) == false ? System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(HostName)) : "Null") + " ";
				Argument = Argument + (string.IsNullOrEmpty(UserName) == false ? System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(UserName)) : "Null") + " ";
				Argument = Argument + (string.IsNullOrEmpty(Password) == false ? System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Password)) : "Null") + " ";
				Argument = Argument + (string.IsNullOrEmpty(PsrPort) == false ? System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(PsrPort)) : "Null") + " ";
				Argument = Argument + (string.IsNullOrEmpty(UriType) == false ? System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(UriType)) : "Null") + " ";
				Argument = Argument + (string.IsNullOrEmpty(ScriptCode) == false ? System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(ScriptCode)) : "Null") + " ";
				Argument = Argument + (string.IsNullOrEmpty(ScriptPath) == false ? System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(ScriptPath)) : "Null") + " ";
				Argument = Argument + (string.IsNullOrEmpty(HasParams) == false ? System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(HasParams)) : "Null") + " ";
				Argument = Argument + (string.IsNullOrEmpty(TableAsString) == false ? System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(TableAsString)) : "Null") + " ";

				Argument = Argument.TrimEnd();
				myProcess.StartInfo.FileName = @"AyehuPowerShellAgent.exe";
				myProcess.StartInfo.Arguments = Argument;
				System.Security.SecureString sstr = new System.Security.SecureString();
				myProcess.StartInfo.UseShellExecute = false;
				myProcess.StartInfo.CreateNoWindow = true;
				myProcess.StartInfo.RedirectStandardInput = true;
				myProcess.StartInfo.RedirectStandardOutput = true;
				myProcess.StartInfo.RedirectStandardError = true;
				myProcess.Start();
				StreamWriter sIn = myProcess.StandardInput;
				StreamReader sOut = myProcess.StandardOutput;
				StreamReader sErr = myProcess.StandardError;

				sIn.AutoFlush = true;
				sIn.Write(("exit" + System.Environment.NewLine));
				string err = "";
				sTxtResult = sOut.ReadToEnd();

				if(((string.IsNullOrEmpty(sTxtResult) == true) && (string.IsNullOrEmpty(err) == false)))
				{
					if(err.Contains("Program\' is not recognized as an internal or external command"))
					{
						err = (err + ("\r\n" + ("\r\n" + ("Phrases with spaces should be encapsulated with double quotes." + "\r\n"))));
					}

					throw new Exception(err);
				}

				myProcess.WaitForExit(60000);
				double timetowait = 60;
				DateTime exittime;
				exittime = DateTime.Now.AddSeconds(timetowait);
				
				if(!myProcess.HasExited)
				{
					myProcess.Kill();
				}

				sIn.Close();
				sOut.Close();
				sErr.Close();
				myProcess.Close();

				if(sTxtResult.ToLower().IndexOf("error: ") == 0)
				{
					 throw new Exception(sTxtResult.Substring(7));
				}
			}
			catch(ThreadAbortException e)
			{
				throw e;
			}
			catch(Exception e)
			{
				throw e;
			}

			return sTxtResult;
		}

		private string ExecuteLocal(string ScriptPath, string ScriptCode, int HasParams, string TableAsString)
		{
			StringWriter sw = new StringWriter();
			DataTable dt = new DataTable("resultSet");
			dt.Columns.Add("Result", typeof(String));

			try
			{
				if(string.IsNullOrEmpty(ScriptCode) == false)
				{
					ScriptCode = ScriptCode.Replace("\t", "\r\n");
				}


				if(string.IsNullOrEmpty(ScriptPath) == false)
				{
					if(File.Exists(ScriptPath))
					{
						ScriptCode = File.ReadAllText(ScriptPath);
					}
					else
					{
						throw new Exception("File not found");
					}
				}

				InitialSessionState iss = InitialSessionState.CreateDefault();
				PSSnapInException warning;

				string[] MyArray = ScriptCode.Split(new string[] { "\r\n" }, StringSplitOptions.None);
				
				foreach (string item in MyArray)
				{
					if(item.ToLower().Contains("add-pssnapin"))
					{
						iss.ImportPSSnapIn(item.Substring(item.ToLower().IndexOf("add-pssnapin") + 12).Trim(), out warning);
						ScriptCode = ScriptCode.Replace(item, "");
					}
				}
				
				Collection<PSObject> results = null;
				
				using (PowerShellProcessInstance instance = new PowerShellProcessInstance(new Version(4, 0), null, null, false))
				{
					using (var runspace = RunspaceFactory.CreateOutOfProcessRunspace(new TypeTable(new string[0]), instance))
					{
						runspace.Open();

						using (Pipeline pipeline = runspace.CreatePipeline())
						{
							if(HasParams == 1 && string.IsNullOrEmpty(TableAsString) == false)
							{
								CommandParameter param;
								DataTable dtParams = new DataTable();
								System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
								
								using (MemoryStream stream = new MemoryStream())
								{
									byte[] allBytes = enc.GetBytes(TableAsString);
									stream.Write(allBytes, 0, allBytes.Length);
									stream.Position = 0;
									dtParams.ReadXml(stream);
								}
								
								Command myCommand = new Command(ScriptCode, true);
								
								foreach (DataRow row in dtParams.Rows)
								{
									param = new CommandParameter(row[0].ToString(), row[1]);
									myCommand.Parameters.Add(param);
								}
								
								pipeline.Commands.Add(myCommand);
								pipeline.Commands.Add("Out-String");
							}
							else
							{
								pipeline.Commands.AddScript(ScriptCode);
								pipeline.Commands.Add("Out-String");
							}
							
							results = pipeline.Invoke();
						}
					}
				}

				StringBuilder stbuilder = new StringBuilder();
				bool isStartLine = true;
				string cmdResult = string.Empty;
				
				foreach (PSObject obj in results)
				{
					if(isStartLine)
					{
						cmdResult = ClearString(obj.ToString());
						isStartLine = false;
					}
					else
					{
						cmdResult = obj.ToString();
					}
					
					dt.Rows.Add(cmdResult);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}

			dt.WriteXml(sw, XmlWriteMode.WriteSchema, false);
			
			return sw.ToString();
		}

		private string ClearString(string Result)
		{
			Result = Result.Trim();

			if(Result.StartsWith("\r\n"))
            {
				Result = Result.Replace("\r\n", "");
            }

			if(Result.StartsWith("\t"))
            {
				Result = Result.Replace("\t", "");
            }

			if(Result.StartsWith("\n"))
            {
				Result = Result.Replace("\n", "");
            }

			return Result.Trim();
		}

		private string ExtractString(string s, string tag)
		{
			var startTag = "<" + tag + ">";
			int startIndex = s.IndexOf(startTag) + startTag.Length;
			int endIndex = s.IndexOf("</" + tag + ">", startIndex);
			
			return s.Substring(startIndex, endIndex - startIndex);
		}
	}
}