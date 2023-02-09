using System;
using BackgroundJob.Data;
using Hangfire;
using Hangfire.MySql;
using Microsoft.EntityFrameworkCore;

namespace BackgroundJob
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterService(this IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
        {
            //Logging
            services.AddLogging();

            //Database
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            //Hangfire
            services.AddHangfire(x => x.UseStorage(new MySqlStorage(
                    connectionString,
                    new MySqlStorageOptions
                    {
                        QueuePollInterval = TimeSpan.FromSeconds(10),
                        JobExpirationCheckInterval = TimeSpan.FromHours(1),
                        CountersAggregateInterval = TimeSpan.FromMinutes(5),
                        PrepareSchemaIfNecessary = true,
                        DashboardJobListLimit = 25000,
                        TransactionTimeout = TimeSpan.FromMinutes(1),
                        TablesPrefix = "Hangfire",
                    })));
            services.AddHangfireServer();

            return services;
        }
    }
}