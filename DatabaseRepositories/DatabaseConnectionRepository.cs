using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.DatabaseRepositories
{
    public static class DatabaseConnectionRepository
    {
        static ConfigFile databaseConfig = Config.Database;
        public static IDbConnection Connect()
        {
            string connectionstring = $@"Server={databaseConfig.Host};
                                        Port = {databaseConfig.Port};
                                        Database = {databaseConfig.Database};
                                        Uid = {databaseConfig.Username};
                                        Pwd = {databaseConfig.Password};
                                        UseAffectedRows = True;";

            return new MySqlConnection(connectionstring);
        }
    }
}
