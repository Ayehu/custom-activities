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
		public string table1;
		public string table2;
		public string mode;

		public ICustomActivityResult Execute()
		{
			System.IO.StringReader sr1 = new System.IO.StringReader(table1);
			DataSet ds1 = new DataSet();
			ds1.ReadXml(sr1);
			DataTable dt1 = new DataTable();
			dt1 = ds1.Tables[0];
			RemoveEmptyRows(dt1);

			System.IO.StringReader sr2 = new System.IO.StringReader(table2);
			DataSet ds2 = new DataSet();
			ds2.ReadXml(sr2);
			DataTable dt2 = new DataTable();
			dt2 = ds2.Tables[0];
			RemoveEmptyRows(dt2);

			if(mode == "table1")
			{
				var tableUnique1 = dt1.AsEnumerable().Except(dt2.AsEnumerable(), DataRowComparer.Default);
				DataTable tableResult1 = tableUnique1.CopyToDataTable<DataRow>();

				return this.GenerateActivityResult(tableResult1);
			}
			else if(mode == "table2")
			{
				var tableUnique1 = dt2.AsEnumerable().Except(dt1.AsEnumerable(), DataRowComparer.Default);
				DataTable tableResult1 = tableUnique1.CopyToDataTable<DataRow>();

				return this.GenerateActivityResult(tableResult1);
			}
			else
			{
				var tableUnique1 = dt1.AsEnumerable().Except(dt2.AsEnumerable(), DataRowComparer.Default);
				DataTable tableResult1 = tableUnique1.CopyToDataTable<DataRow>();

				var tableUnique2 = dt2.AsEnumerable().Except(tableResult1.AsEnumerable(), DataRowComparer.Default);
				DataTable tableResult2 = tableUnique2.CopyToDataTable<DataRow>();

				DataTable tableResult3 = tableResult1;
				tableResult3.Merge(tableResult2);

				return this.GenerateActivityResult(tableResult3);
			}
		}

		private void RemoveEmptyRows(DataTable source)
		{
			for(int i = source.Rows.Count; i >= 1; i --)
			{
				DataRow currentRow = source.Rows[i - 1];
			
				foreach (var colValue in currentRow.ItemArray)
				{
					if(!string.IsNullOrEmpty(colValue.ToString()))
					{
						break;
					}

					source.Rows[i - 1].Delete();
				}
			}
		}
	}
}