using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Text;
using System.Data;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
    public class customActivity : IActivity
    {
        public string TheValue;
        public ICustomActivityResult Execute()
        {

            if (string.IsNullOrEmpty(TheValue.Trim()))
            {
                throw new Exception("Value is missing or empty");
            }

            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");
            DataRow dr = dt.NewRow();

            int i;
            string result = string.Empty;
            for (i = 0; i < TheValue.Length; i++)
            {
                result = result + TheValue[i] + ' ';
            }

            dt.Rows.Add(result.Trim());
            return this.GenerateActivityResult(dt);
        }
    }
}
