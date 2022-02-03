using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.IO;
using System;
using System.Web.UI;
using System.Web.Script.Serialization;

namespace Ayehu.Sdk.ActivityCreation
{
	public class  CustomActivity: IActivity
	{
		public string tableVariable;

		public ICustomActivityResult Execute()
		{
			System.IO.StringReader sr = new System.IO.StringReader(tableVariable);

			DataSet ds = new DataSet();
			ds.ReadXml(sr);
			
			DataTable dt = new DataTable();
			dt = ds.Tables[0];
			
			System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
			List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
			Dictionary<string, object> row;

			foreach (DataRow dr in dt.Rows)
			{
				row = new Dictionary<string, object>();
			
				foreach (DataColumn col in dt.Columns)
				{
					row.Add(col.ColumnName, dr[col]);
				}
			
				rows.Add(row);
			}
			
			return this.GenerateActivityResult(serializer.Serialize(rows));
		}
	}
}
