using System;
using System.IO;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using SimpleImpersonation;

namespace Ayehu.Sdk.ActivityCreation {
  public class FolderExistRemote: IActivity {
    public string SourcePath;
    public string Username;
    public string Password;


    public ICustomActivityResult Execute() {
      if (string.IsNullOrEmpty(Username)) {
        Directory.Exists(SourcePath);
        Console.WriteLine("The Folder does Exist", SourcePath);
      } else {
        var networkUser = Username.Split('\\');
        if (networkUser.Length < 2) throw new Exception("username must be in the \"Domain\\Username\" format");

        var userCredentials = new UserCredentials(networkUser[0], networkUser[1], Password);
        Impersonation.RunAsUser(userCredentials, LogonType.NewCredentials, () => {
        if (Result == "False") {
            try {
              FileInfo fi = new FileInfo(SourcePath);
              if (fi.Exists) {
                fi.Delete();
              } else {
                var networkUser = Username.Split('\\');
                var userCredentials = new UserCredentials(networkUser[0], networkUser[1], Password);
                Impersonation.RunAsUser(userCredentials, LogonType.NewCredentials, () =>{
                  try {
                    FileInfo fi = new FileInfo(SourcePath);
                    if (fi.Exists) {
                      fi.Delete();
                    }
                  }
                  catch(Exception e) {
                    Console.WriteLine(e.Message);
                  }

        });
      }
    }
  }
}