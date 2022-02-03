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
		public string columnType;
		public string columnList;

		public ICustomActivityResult Execute()
		{
			System.IO.StringReader sr = new System.IO.StringReader(sourceTable);

			DataSet ds = new DataSet();
			ds.ReadXml(sr);

			DataTable dt = new DataTable();
			dt = ds.Tables[0];

			DataTable resultTable = new DataTable("resultSet");
			int columnIndex = 0;
			int rowCount = 0;
			string columnName = String.Empty;

			if(columnList.Contains(","))
			{
				string[] columns = columnList.Split(',');

				for(int i = 0; i < columns.Length; i ++)
				{
					columns[i] = Regex.Replace(columns[i], @"^\s+|\s+$|\s+(?=\s)", "");

					if(columnType == "Number" && !columns[i].All(char.IsDigit))
					{
						throw new Exception("Must specify column numbers when using \"Number\" option.");
					}

					if(columnType == "Name")
					{
						columnIndex = dt.Columns[columns[i]].Ordinal;
					}
					else
					{
						columnIndex = Int32.Parse(columns[i]) - 1;
					}

					columnName = dt.Columns[columnIndex].ColumnName;

					resultTable.Columns.Add(columnName);

					foreach(DataRow dr in dt.Rows)
					{
						if(i == 0)
						{
							resultTable.Rows.Add(resultTable.NewRow());
						}

						resultTable.Rows[rowCount][columnName] = dr.ItemArray[columnIndex].ToString();

						rowCount ++;
					}

					columnName = String.Empty;
					rowCount = 0;
				}

				return this.GenerateActivityResult(resultTable);
			}
			else
			{
				if(columnType == "Number" && !columnList.All(char.IsDigit))
				{
					throw new Exception("Must specify column numbers when using \"Number\" option.");
				}

				if(columnType == "Name")
				{
					columnIndex = dt.Columns[columnList].Ordinal;
				}
				else
				{
					columnIndex = Int32.Parse(columnList) - 1;
				}

				columnName = dt.Columns[columnIndex].ColumnName;

				resultTable.Columns.Add(columnName);

				foreach(DataRow dr in dt.Rows)
				{
					resultTable.Rows.Add(resultTable.NewRow());

					resultTable.Rows[rowCount][columnName] = dr.ItemArray[columnIndex].ToString();

					rowCount ++;
				}

				return this.GenerateActivityResult(resultTable);
			}
		}
	}
}