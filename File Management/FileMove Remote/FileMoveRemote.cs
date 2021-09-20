using System;
using System.IO;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using SimpleImpersonation;

namespace Ayehu.Sdk.ActivityCreation
{
   public class FileCopyRemote : IActivity
    {
        public string SourcePath;
        public string DestinationPath;
        public string Username;
        public string Password;
        public string Overwrite = "yes";

        public ICustomActivityResult Execute()
        {
          var overwrite = Overwrite.ToLower().Equals("yes");
            if (string.IsNullOrEmpty(Username))
            {
                File.Move(SourcePath, DestinationPath);
            }
            else
            {
                var networkUser = Username.Split('\\');
                if (networkUser.Length < 2) throw new Exception("username must be in the \"Domain\\Username\" format");
                
                var userCredentials = new UserCredentials(networkUser[0], networkUser[1], Password);
                Impersonation.RunAsUser(userCredentials, LogonType.NewCredentials, () =>
                {
                    File.Move(SourcePath, DestinationPath);
                });
            }

            return this.GenerateActivityResult("Success");
        }
   }
}