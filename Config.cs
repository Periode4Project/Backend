﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                string json = JsonConvert.SerializeObject(databaseConfig, Formatting.Indented);
                using (StreamWriter outFile = new StreamWriter(@"config.json"))
                {
                    outFile.Write(json);
                }
            }
            using (StreamReader file = File.OpenText(@"config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                databaseConfig = (DatabaseConfig)serializer.Deserialize(file, typeof(DatabaseConfig));
            }
            return databaseConfig;
        }
    }
}
