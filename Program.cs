using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SailingBackend.DatabaseMigrations;

namespace SailingBackend
{
    /// <summary>
    /// Default program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Default entrypoint
        /// </summary>
        /// <param name="args"> console arguments </param>
        public static void Main(string[] args)
        {
            if (args.Contains("--migrate"))
                DatabaseMigrationsController.LoadMigrations();
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Default Hostbuilder
        /// </summary>
        /// <param name="args"> entrypoint args </param>
        /// <returns> IHostBuilder </returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
