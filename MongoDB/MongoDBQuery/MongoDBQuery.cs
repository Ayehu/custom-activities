using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
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

                var query = BsonSerializer.Deserialize<BsonDocument>(MongoDBQuery);
                var queryDoc = new QueryDocument(query);

                var dbResult = collection.Find(query).ToList();
                var dt = ToDataTable(dbResult);

                return this.GenerateActivityResult(dt);
            }
            catch (Exception ex)
            {
                return this.GenerateActivityResult(ex.ToString());
            }
        }

        public DataTable ToDataTable(List<BsonDocument> collection)
        {
            if (collection != null && collection.Count > 0)
            {
                var dt = new DataTable("resultSet");
                foreach (BsonDocument doc in collection)
                {
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
                }

                return dt;
            }

            return null;
        }
    }
}
