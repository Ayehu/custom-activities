using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
     public class  CustomActivity: IActivity
     {
          public string jsonString;

          public ICustomActivityResult Execute()
          {
               var decoded = Regex.Unescape(jsonString);

               return this.GenerateActivityResult(decoded);
          }
     }
}