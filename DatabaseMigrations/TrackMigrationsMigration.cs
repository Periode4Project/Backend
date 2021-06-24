using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SailingBackend.DatabaseMigrations
{
    /// <summary>
    /// Migration Class
    /// </summary>
    public static class TrackMigrationsMigration
    {
        /// <summary>
        /// Static Migration
        /// </summary>
        public static DatabaseMigration DatabaseMigration { get; set; } = new DatabaseMigration
        {
            Queries = new List<Query> { }
        };
        static TrackMigrationsMigration()
        {
            DatabaseMigration.MigrationName = "TrackMigrations";
            DatabaseMigration.Queries.Add(new Query 
            { 
                SqlQuery = @"
                CREATE TABLE Migrations
                (
                    MigrationId INTEGER NOT NULL AUTO_INCREMENT,
                    MigrationName VARCHAR(50) NOT NULL,
                    PRIMARY KEY(MigrationId)
                )
                ", 
                Params = new { } 
            });
            DatabaseMigration.Queries.Add(new Query 
            {
                SqlQuery = @$"INSERT INTO Migrations (MigrationName) VALUES (@MIGRATIONNAME)",
                Params = new { @MIGRATIONNAME = DatabaseMigration.MigrationName }
            });
        }
    }
}
