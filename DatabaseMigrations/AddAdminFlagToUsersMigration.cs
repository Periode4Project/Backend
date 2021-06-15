using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.DatabaseMigrations
{
    public static class AddAdminFlagToUsersMigration
    {
        public static DatabaseMigration DatabaseMigration { get; set; } = new DatabaseMigration
        {
            Queries = new List<Query> { }
        };

        static AddAdminFlagToUsersMigration()
        {
            DatabaseMigration.MigrationName = "AddAdminFlagToUsers";
            DatabaseMigration.Queries.Add(new Query
            {
                SqlQuery = @"ALTER TABLE Users
                             ADD IsAdmin BOOL DEFAULT False",
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
