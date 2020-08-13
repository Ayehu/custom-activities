using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Linq;

namespace Ayehu.Sdk.ActivityCreation
{
    public class ActivityClass : IActivity
    {
        public string MongoServer = "";
        public string UseDNSSeedList = "";
        public string Username = "";
        public string Password = "";
        public string DBName = "";
        public string CollectionName = "";
        public string MongoDBQuery = "";

        public ICustomActivityResult Execute()
        {
            try
            {
                var userCredentials = string.Empty;
                var mongoPrefix = "mongodb";
                if (UseDNSSeedList == "Yes")
                {
                    mongoPrefix += "+srv";
                }
                if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
                {
                    userCredentials = string.Format("{0}:{1}@", Username, Password);
                }

                var client = new MongoClient(string.Format("{0}://{1}{2}/{3}?retryWrites=true&w=majority", mongoPrefix, userCredentials, MongoServer, DBName));
                var database = client.GetDatabase(DBName);
                var collection = database.GetCollection<BsonDocument>(CollectionName);

                var formattedJSON = FormatJSON(MongoDBQuery);
                var command = new JsonCommand<BsonDocument>(MongoDBQuery);
                var commandResult = database.RunCommand(command);

                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
                var cursorResult = commandResult.ToJson(jsonWriterSettings);
                var dt = ToDataTable(cursorResult);

                return this.GenerateActivityResult(dt);
            }
            catch (Exception ex)
            {
                return this.GenerateActivityResult(ex.ToString());
            }
        }

        public string FormatJSON(string json)
        {
            return json.Replace('\'', '\"').Replace("\"", "\\\"");
        }

        public DataTable ToDataTable(string mongoJSON)
        {
            var jsonResults = JObject.Parse(mongoJSON);
            var mongoResult = jsonResults["cursor"].First.First; // First object with first batch
            var dt = new DataTable("resultSet");

            int itemsCount = mongoResult.Count();
            int rowCount = 0;

            for (int i = 0; i < itemsCount; i++)
            {
                dt.Rows.Add(dt.NewRow());

                var mongoObj = JObject.Parse(mongoResult[i].ToString());

                foreach (JProperty property in mongoObj.Properties())
                {
                    if (!dt.Columns.Contains(property.Name))
                    {
                        dt.Columns.Add(property.Name);
                    }

                    dt.Rows[rowCount][property.Name] = property.Value;
                }

                rowCount++;
            }

            return dt;
        }
    }
}
