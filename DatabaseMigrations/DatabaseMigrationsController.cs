using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.DatabaseMigrations
{
    public static class DatabaseMigrationsController
    {
        static List<DatabaseMigration> DatabaseMigrations = new List<DatabaseMigration> { };

        static DatabaseMigrationsController()
        {
            DatabaseMigrations.Add(TrackMigrationsMigration.DatabaseMigration);
            DatabaseMigrations.Add(CreateActivitiesMigration.DatabaseMigration);
            DatabaseMigrations.Add(CreateUsersMigration.DatabaseMigration);
            DatabaseMigrations.Add(CreateReviewsMigration.DatabaseMigration);
            DatabaseMigrations.Add(CreateSuggestionsMigration.DatabaseMigration);
            DatabaseMigrations.Add(AddAdminFlagToUsersMigration.DatabaseMigration);
        }
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

    public class DatabaseMigration
    {
        public int MigrationId { get; set; }
        public string MigrationName { get; set; }
        public List<Query> Queries { get; set; }
    }

    public class Query
    {
        public string SqlQuery { get; set; }
        public object Params { get; set; }
    }
}
