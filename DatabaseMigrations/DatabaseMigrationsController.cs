using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.DatabaseMigrations
{
    /// <summary>
    /// Handle Database Migrations
    /// </summary>
    public static class DatabaseMigrationsController
    {
        /// <summary>
        /// List of database migrations, used in LoadMigrations
        /// </summary>
        static List<DatabaseMigration> DatabaseMigrations = new List<DatabaseMigration> { };

        /// <summary>
        /// Constructor to fill mugrations list
        /// </summary>
        static DatabaseMigrationsController()
        {
            DatabaseMigrations.Add(TrackMigrationsMigration.DatabaseMigration);
            DatabaseMigrations.Add(CreateActivitiesMigration.DatabaseMigration);
            DatabaseMigrations.Add(CreateUsersMigration.DatabaseMigration);
            DatabaseMigrations.Add(CreateReviewsMigration.DatabaseMigration);
            DatabaseMigrations.Add(CreateSuggestionsMigration.DatabaseMigration);
            DatabaseMigrations.Add(AddAdminFlagToUsersMigration.DatabaseMigration);
        }
        /// <summary>
        /// Load Migrations 
        /// </summary>
        public static void LoadMigrations()
        {
            int executedMigrations = 0;
            using IDbConnection connection = DatabaseRepositories.DatabaseConnectionRepository.Connect();
                foreach (DatabaseMigration databaseMigration in DatabaseMigrations)
                {
                    if (!DoesMigrationExist(databaseMigration.MigrationName))
                    {
                        foreach (Query query in databaseMigration.Queries)
                        {
                            try
                            {
                                Console.WriteLine(query.SqlQuery);
                                connection.Execute(sql: query.SqlQuery, param: query.Params);
                                executedMigrations++;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                }
            Console.WriteLine($"{executedMigrations} Migrations were executed.");
        }
        /// <summary>
        /// Checks if migration exists or not
        /// </summary>
        /// <param name="migrationName"> Migration name </param>
        /// <returns> bool exists </returns>
        static bool DoesMigrationExist(string migrationName)
        {
            using IDbConnection connection = DatabaseRepositories.DatabaseConnectionRepository.Connect();
            try
            {
                bool doesMigrationExist = connection.ExecuteScalar<bool>(sql: @"SELECT COUNT(1) FROM Migrations WHERE MigrationName=@MIGRATIONNAME", param: new { @MIGRATIONNAME = migrationName });
                return doesMigrationExist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }
    }

    /// <summary>
    /// Database Migration
    /// </summary>
    public class DatabaseMigration
    {
        /// <summary>
        /// Migration ID
        /// </summary>
        public int MigrationId { get; set; }
        /// <summary>
        /// Migration Name
        /// </summary>
        public string MigrationName { get; set; }
        /// <summary>
        /// Database Queries
        /// </summary>
        public List<Query> Queries { get; set; }
    }

    /// <summary>
    /// Database Query
    /// </summary>
    public class Query
    {
        /// <summary>
        /// SqlQuery
        /// </summary>
        public string SqlQuery { get; set; }
        /// <summary>
        /// Anonymous typed object containing parameters
        /// </summary>
        public object Params { get; set; }
    }
}
