using System;
using System.IO;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using SimpleImpersonation;

namespace Ayehu.Sdk.ActivityCreation
{
	public class FileExistRemote: IActivity
	{
		// Input fields from activity configuration.
		public string Path;
		public string Username;
		public string Password;
		private string Result;

		public ICustomActivityResult Execute()
		{
			// No username was specified, and so we will treat "Path" like a local (non-network) folder.
			if(string.IsNullOrEmpty(Username))
			{
				// Store "True" or "False" in "Result" string based on result of "Directory.Exists".
				Result = Directory.Exists(Path).ToString();
			}
			// Username was specified, so treat "Path" like a network folder.
			else
			{
				// Split "Username" at the backslash (\) into seprate elements of the "networkUser" array.
				var networkUser = Username.Split('\\');
				
				// If "networkUser" array has fewer than two (2) elements, throw an exception.
				if(networkUser.Length < 2)
				{
					throw new Exception("Username must be in the \"Domain\\Username\" format.");
				}

				// Store a new credentials object.
				var userCredentials = new UserCredentials(networkUser[0], networkUser[1], Password);
				
				// Use "SimpleImpersonation" library to run "Directory.Exists" as the user specified in the "Username" field.
				Impersonation.RunAsUser(userCredentials, LogonType.NewCredentials, () => {
					// Store "True" or "False" in "Result" string based on result of "Directory.Exists".
					Result = Directory.Exists(Path).ToString();
				});
			}

			// Folder was not found with local or network methods above, so try another method.
			if(Result == "False")
			{
				// Attempt a "isReadOnly" test on the folder as a secondary test.
				try
				{
					// Create "DirectoryInfo" object "di".
					DirectoryInfo di = new DirectoryInfo(Path);

					// No username was specified, and so we will treat "Path" like a local (non-network) folder.
					if(string.IsNullOrEmpty(Username))
					{
						// Store result of "IsReadOnly" into "isReadOnly" boolean.
						bool isReadOnly = di.Attributes.HasFlag(FileAttributes.ReadOnly);
					}
					// Username was specified, so treat "Path" like a network folder.
					else
					{
						// Split "Username" at the backslash (\) into seprate elements of the "networkUser" array.
						var networkUser = Username.Split('\\');
						
						// Store a new credentials object.
						var userCredentials = new UserCredentials(networkUser[0], networkUser[1], Password);
					 
						// Use "SimpleImpersonation" library to run "IsReadOnly" as the user specified in the "Username" field.
						Impersonation.RunAsUser(userCredentials, LogonType.NewCredentials, () => {
							bool isReadOnly = di.Attributes.HasFlag(FileAttributes.ReadOnly);
						});
					}
				}
				// An exception occurred, throw an error.
				catch(Exception e)
				{
					throw new Exception(e.Message);
				}
			}

			// Return "Result" string, containing either "True" or "False".
			return this.GenerateActivityResult(Result);
		}
	}
}