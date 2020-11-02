using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
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
		public string sourceColumn;
		public string sourceValue;
		public string targetColumn;

		public ICustomActivityResult Execute()
		{
			System.IO.StringReader sr = new System.IO.StringReader(sourceTable);

			DataSet ds = new DataSet();

			ds.ReadXml(sr);

			DataTable dt = new DataTable();

			dt = ds.Tables[0];
			
			int columnIndex = dt.Columns[targetColumn].Ordinal;

			string result = string.Empty;
			
			foreach(DataRow dr in dt.Rows)
			{
				for(int i = 0; i < dt.Columns.Count; i++)
				{
					if(dt.Columns[i].ColumnName.ToString() == sourceColumn)
					{
						if(dr.ItemArray[i].ToString() == sourceValue)
						{
							result = dr.ItemArray[columnIndex].ToString();
						}
					}
				}
			}

			if(string.IsNullOrEmpty(result))
			{
				throw new Exception("Not found.");
			}
			else
			{
				return this.GenerateActivityResult(result);
			}
		}
	}
}