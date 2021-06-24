using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.DatabaseMigrations
{
    /// <summary>
    /// Migration Class
    /// </summary>
    public static class CreateReviewsMigration
    {
        /// <summary>
        /// Static Migration
        /// </summary>
        public static DatabaseMigration DatabaseMigration { get; set; } = new DatabaseMigration 
        { 
            Queries = new List<Query> { } 
        };
        static CreateReviewsMigration()
        {
            DatabaseMigration.MigrationName = "AddReviews";
            DatabaseMigration.Queries.Add(new Query
            {
                SqlQuery = @"
                CREATE TABLE Reviews
                (
                    ReviewID INTEGER NOT NULL AUTO_INCREMENT,
                    ReviewTitle VARCHAR(100) NOT NULL,
                    Rating INTEGER NOT NULL,
                    ReviewDESC VARCHAR(1000) NOT NULL,
                    ReviewWriter INTEGER NOT NULL,
                    Activity INTEGER NOT NULL,
                    PRIMARY KEY(ReviewID),
                    FOREIGN KEY(ReviewWriter) REFERENCES Users(UserID),
                    FOREIGN KEY(Activity) REFERENCES Activities(ActivityID)
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
