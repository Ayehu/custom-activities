using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System;

namespace Ayehu.Sdk.ActivityCreation
{

    public class ReadFile : IActivityAsync
    {

        public string path;

        public async System.Threading.Tasks.Task<ICustomActivityResult> Execute()
        {
           
            if (System.IO.File.Exists(path) == false)
                throw new Exception("File not found");

            return this.GenerateActivityResult(Convert.ToBase64String(System.IO.File.ReadAllBytes(path)));

        }

    }
}
