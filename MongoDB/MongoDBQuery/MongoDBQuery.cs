using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Data;

namespace Ayehu.Sdk.ActivityCreation
{
    public class ActivityClass : IActivity
    {
        public string MongoServer = "";
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
                if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
                {
                    userCredentials = string.Format("{0}:{1}@", Username, Password);
                }

                var client = new MongoClient(string.Format("mongodb+srv://{0}{1}/{2}?retryWrites=true&w=majority", userCredentials, MongoServer, DBName));
                var database = client.GetDatabase(DBName);
                var collection = database.GetCollection<BsonDocument>(CollectionName);

                var formattedJSON = FormatJSON(MongoDBQuery);
                var command = new JsonCommand<BsonDocument>(MongoDBQuery);
                var commandResult = database.RunCommand(command);

                var dt = ToDataTable(commandResult);

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

        public DataTable ToDataTable(BsonDocument doc)
        {
            if (doc != null)
            {
                var dt = new DataTable("resultSet");
                foreach (BsonElement elm in doc.Elements)
                {
                    if (!dt.Columns.Contains(elm.Name))
                    {
                        dt.Columns.Add(new DataColumn(elm.Name));
                    }
                }

                var dr = dt.NewRow();
                foreach (BsonElement elm in doc.Elements)
                {
                    dr[elm.Name] = elm.Value;
                }
                dt.Rows.Add(dr);

                return dt;
            }

            return null;
        }
    }
}
