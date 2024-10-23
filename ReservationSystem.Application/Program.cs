using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReservationSystem.Business.Services;
using ReservationSystem.Core.Models;
using ReservationSystem.Root;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReservationSystem.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            string directory = Directory.GetCurrentDirectory();
            string dbFilePath = $"{directory}\\contact-types.json";

            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var dbInitializer = services.GetRequiredService<IDbInitializeService>();
                    dbInitializer.CreateDatabase();
                    dbInitializer.SeedData(dbFilePath);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error ocurrer while creating database");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
