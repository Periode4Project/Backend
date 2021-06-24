using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.DatabaseMigrations
{
    /// <summary>
    /// Migration Class
    /// </summary>
    public static class CreateSuggestionsMigration
    {
        /// <summary>
        /// Static Migration
        /// </summary>
        public static DatabaseMigration DatabaseMigration { get; set; } = new DatabaseMigration
        {
            Queries = new List<Query> { }
        };

        static CreateSuggestionsMigration()
        {
            DatabaseMigration.MigrationName = "CreateSuggestions";
            DatabaseMigration.Queries.Add(new Query
            {
                SqlQuery = @"
                CREATE TABLE Suggestions
                (
                    SuggestionID INTEGER NOT NULL AUTO_INCREMENT,
                    SuggesterID INTEGER NOT NULL,
                    ActivityIdea VARCHAR(50) NOT NULL,
                    ActivityLocation VARCHAR(50) NOT NULL,
                    ActivityDesc VARCHAR(1000) NOT NULL,
                    PRIMARY KEY(SuggestionID),
                    FOREIGN KEY(SuggesterID) REFERENCES Users(UserID)
                )
                ",
                Params = new { }
            });
            DatabaseMigration.Queries.Add(new Query
            {
                SqlQuery = @$"INSERT INTO Migrations (MigrationName) VALUES (@MIGRATIONNAME)",
                Params = new { MIGRATIONNAME = DatabaseMigration.MigrationName }
            });
        }
    }
}
