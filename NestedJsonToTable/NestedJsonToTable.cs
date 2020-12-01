using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Linq;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string jsonVariable;

		public ICustomActivityResult Execute()
		{
			DataTable dt = new DataTable("resultSet");

			var res = ExposeJson(JObject.Parse(jsonVariable)).ToDictionary(q => q.Key, q => q.Value);

			dt.Merge(GetDataTable(res));

			return this.GenerateActivityResult(dt);
		}

		private IDictionary<string, string> ExposeJson(JObject jObject, string append = "")
    	{
		    var result = new Dictionary<string, string>();

		    foreach (var jProperty in jObject.Properties())
		    {
				var jToken = jProperty.Value;

				if (jToken.Type == JTokenType.Object)
				{
				    var nested_result = ExposeJson(jToken as JObject, jProperty.Name + "_");
				    result = result.Concat(nested_result).ToDictionary(q => q.Key, q => q.Value);
				}
				else if (jToken.Type != JTokenType.Array)
				{
				    result.Add(append + jProperty.Name, jProperty.Value.ToString());
				}
	    	}

		    return result;
		}

		private DataTable GetDataTable(IReadOnlyDictionary<string, string> columns)
		{
		    DataTable dt = new DataTable("resultSet");
		    dt.Rows.Add(dt.NewRow());

		    foreach (var col in columns)
		    {
				dt.Columns.Add(col.Key);
				dt.Rows[0][col.Key] = col.Value;
		    }

		    return dt;
		}
	}
}