using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NpgsqlTypes;
using Serilog;
using Serilog.Sinks.PostgreSQL;
using VertexMVC.Extensions;

namespace VertexMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Log.Logger = new LoggerConfiguration().
            Enrich.FromLogContext().
            WriteTo.Console().
            //WriteTo.PostgreSQL(config.GetConnectionString("default"), "Logs", columnWriters).
            CreateLogger();

            try
            {
                var iWebHost = CreateHostBuilder(args).Build();
                Log.Information("Application starting");
                iWebHost.Run();
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseSerilog()
                    .UseStartup<Startup>();
                    webBuilder.UseUrls("http://*:" + Environment.GetEnvironmentVariable("PORT"));
                });
    }
}
