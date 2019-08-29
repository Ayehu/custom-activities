using System;
using System.IO;
using System.Threading.Tasks;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;

namespace ExampleActivity
{
    public class MyActivity : IActivityAsync
    {
        public string sourcePath;
        
        public async Task<ICustomActivityResult> Execute()
        {
            try
            {
                int count = 0;

                // Read in the specified file.
                // ... Use async StreamReader method.
                using (StreamReader reader = new StreamReader(sourcePath))
                {
                    string v = await reader.ReadToEndAsync();

                    // ... Process the file data somehow.
                    count += v.Length;

                    // ... A slow-running computation.
                    //     Dummy code.
                   for (int i = 0; i < 10000; i++)
                    {
                        int x = v.GetHashCode();
                        if (x == 0)
                        {
                            count--;
                        }
                    }
                }

                return this.GenerateActivityResult(count.ToString());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
