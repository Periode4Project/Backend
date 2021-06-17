using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.DatabaseMigrations
{
    public static class CreateActivitiesMigration
    {
        public static DatabaseMigration DatabaseMigration { get; set; } = new DatabaseMigration
        {
            Queries = new List<Query> { }
        };
        static CreateActivitiesMigration()
        {
            DatabaseMigration.MigrationName = "CreateActivities";
            DatabaseMigration.Queries.Add(new Query 
            {
                SqlQuery = @"CREATE TABLE Activities(
                ActivityID INTEGER NOT NULL AUTO_INCREMENT,
                ActivityImage VARCHAR(255) NOT NULL,
                ActivityName VARCHAR(50) NOT NULL,
                ActivityDesc VARCHAR(1000) NOT NULL,
                ActivityType VARCHAR(30) NOT NULL,
                City VARCHAR(50) NOT NULL,
                Address VARCHAR(100) NOT NULL,
                Lat DOUBLE DEFAULT 0,
                Lng DOUBLE DEFAULT 0,
                EntranceFee DOUBLE DEFAULT 0,
                PRIMARY KEY(ActivityID)
                )"
            });
            DatabaseMigration.Queries.Add(new Query
            {
                SqlQuery = @$"INSERT INTO Migrations (MigrationName) VALUES (@MIGRATIONNAME)",
                Params = new { @MIGRATIONNAME = DatabaseMigration.MigrationName }
            });
        }
    }
}
