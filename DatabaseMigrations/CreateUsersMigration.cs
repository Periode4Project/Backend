using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.DatabaseMigrations
{
    public static class CreateUsersMigration
    {
        public static DatabaseMigration DatabaseMigration { get; set; } = new DatabaseMigration
        {
            Queries = new List<Query> { }
        };

        static CreateUsersMigration()
        {
            DatabaseMigration.MigrationName = "CreateUsers";
            DatabaseMigration.Queries.Add(new Query
            {
                SqlQuery = @"CREATE TABLE Users(
                UserID INTEGER NOT NULL AUTO_INCREMENT,
                Email VARCHAR(50) NOT NULL,
                FullName VARCHAR(40) NOT NULL,
                Password VARCHAR(50) NOT NULL,
                PRIMARY KEY(UserID),
                UNIQUE (Email)
                )",
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
