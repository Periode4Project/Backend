using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.DatabaseRepositories
{
    /// <summary>
    /// Provides database connection capabilities
    /// </summary>
    public static class DatabaseConnectionRepository
    {
        /// <summary>
        /// return MySQL connection from connection string
        /// </summary>
        /// <returns> MySQL Connection </returns>
        public static IDbConnection Connect()
        {
            string connectionstring = $@"Server={Config.Database.Host};
                                        Port = {Config.Database.Port};
                                        Database = {Config.Database.Database};
                                        Uid = {Config.Database.Username};
                                        Pwd = {Config.Database.Password};
                                        UseAffectedRows = True;";

            return new MySqlConnection(connectionstring);
        }
    }
}
