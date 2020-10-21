using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.IO;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string sourceTable;

		public ICustomActivityResult Execute()
		{
			System.IO.StringReader sr = new System.IO.StringReader(sourceTable);

			DataSet ds = new DataSet();

			ds.ReadXml(sr);

			DataTable dt = new DataTable();

			dt = ds.Tables[0];

			int rowCount = 0;
						
			foreach(DataRow dr in dt.Rows)
			{
				for(int i = 0; i < dt.Columns.Count; i++)
				{
					dt.Rows[rowCount][i] = Regex.Replace(dr.ItemArray[i].ToString(), @"^\s+|\s+$|\s+(?=\s)", "");
				}

				rowCount ++;
			}

			return this.GenerateActivityResult(dt);
		}
	}
}