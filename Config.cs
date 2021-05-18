using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SailingBackend
{
    public static class Config
    {
        public static readonly DatabaseConfig config = GetDatabaseConfig();

        public static DatabaseConfig GetDatabaseConfig()
        {
            DatabaseConfig databaseConfig = new DatabaseConfig()
            {
                Username = "root",
                Password = "root",
                Database = "sailing",
                Host = "127.0.0.1",
                Port = 3306
            };

            if (!File.Exists(@"config.json"))
            {
                string json = System.Text.Json.JsonSerializer.Serialize(databaseConfig);
                using (StreamWriter outFile = new StreamWriter(@"config.json"))
                {
                    outFile.Write(json);
                }
            }
            using (StreamReader file = File.OpenText(@"config.json"))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                databaseConfig = (DatabaseConfig)serializer.Deserialize(file, typeof(DatabaseConfig));
            }
            return databaseConfig;
        }
    }
}
