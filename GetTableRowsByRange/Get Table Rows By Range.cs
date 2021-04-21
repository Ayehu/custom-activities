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
		public string intervalMode;
		public int startRow;
		public int interval;
		
		public ICustomActivityResult Execute()
		{
			int length = 0;
			int rowCount = 0;
			int sourceRowCount = 0;

			startRow --;

			System.IO.StringReader sr = new System.IO.StringReader(sourceTable);
			DataSet ds = new DataSet();
			ds.ReadXml(sr);

			DataTable dt = new DataTable();
			dt = ds.Tables[0];
			
			DataTable rt = dt.Clone();

			sourceRowCount = dt.Rows.Count;

			if(intervalMode == "Length")
			{
				if((startRow + interval) > sourceRowCount)
				{
					length = (interval - sourceRowCount);
				} 
				else if(sourceRowCount < interval)
				{
					length = sourceRowCount;
				} 
				else 
				{
					length = interval;
				}
			}
			else if(intervalMode == "End Row")
			{
				length = interval - startRow;
			}
			
			foreach(DataRow row in dt.Rows)
			{
				if((rowCount >= startRow) && (rowCount < (startRow + length)))
				{
					rt.ImportRow(row);
				}
				
				if(rowCount > (startRow + length))
				{
					break;
				}

				rowCount ++;
			}
			
			return this.GenerateActivityResult(rt);
		}
	}
}