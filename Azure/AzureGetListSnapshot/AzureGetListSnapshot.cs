using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net;

namespace AzureGetListSnapshot
{
    public static class ConvertToDataTable
    {
        public static DataTable ToDataTable<T>(this List<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
    class AzureGetListSnapshot : IActivity
    {
        public class Snapshot
        {
            public List<Value> value { get; set; }
        }
        public class Value
        {
            public string name { get; set; }
            public string id { get; set; }
            public string type { get; set; }
            public string location { get; set; }
            public Sku sku { get; set; }
            public Properties properties { get; set; }
        }
        public class CreationData
        {
            public string createOption { get; set; }
            public string sourceResourceId { get; set; }
            public string sourceUniqueId { get; set; }
        }
        public class Properties
        {
            public CreationData creationData { get; set; }
            public long diskSizeGB { get; set; }
            public bool incremental { get; set; }
            public string timeCreated { get; set; }
            public string provisioningState { get; set; }
            public string diskState { get; set; }
            public long diskSizeBytes { get; set; }
            public string uniqueId { get; set; }
        }
        public class Sku
        {
            public string name { get; set; }
            public string tier { get; set; }
        }
        public string tenantId;
        public string clientId;
        public string clientSecret;
        public string subscriptionId;
        public ICustomActivityResult Execute()
        {
            var table = new DataTable();
            string authContextURL = "https://login.windows.net/" + tenantId;
            var authenticationContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authContextURL);
            var credential = new ClientCredential(clientId, clientSecret);
            var result = authenticationContext.AcquireTokenAsync(resource: "https://management.azure.com/", clientCredential: credential).Result;
            if (result == null)
            {
                return this.GenerateActivityResult("Failed to obtain the JWT token");
            }
            string token = result.AccessToken;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://management.azure.com/subscriptions/" + subscriptionId + "/providers/Microsoft.Compute/snapshots?api-version=2019-03-01");
            request.Method = "GET";
            request.Headers["Authorization"] = "Bearer " + token;
            request.ContentType = "application/json";
            FileStream fs = null;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                var jsonContent = sr.ReadToEnd();
                Snapshot sn = JsonConvert.DeserializeObject<Snapshot>(jsonContent);
                table = sn.value.ToDataTable();
            }
            catch (Exception ex)
            {
                return this.GenerateActivityResult(ex.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
            return this.GenerateActivityResult(table);
        }
    }
}