using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Text;
using System.Data;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
    public class  CustomActivity: IActivity
    {
        public ICustomActivityResult Execute()
        {  
        	return this.GenerateActivityResult(Guid.NewGuid().ToString());
        }
    }
}