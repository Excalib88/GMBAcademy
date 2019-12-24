using System;
using Microsoft.EntityFrameworkCore;
using GMBAcademy.DataAccess.Contexts;
using GMBAcademy.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GMBAcademy.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(builder =>
            {
                builder.EnableSensitiveDataLogging(true);

                builder.UseNpgsql(configuration.GetConnectionString("Db"),
                    x => x.MigrationsAssembly(
                            "GMBAcademy.DataAccess.Migrations")
                        .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            });
            services
                .AddScoped<IDbRepository, DbRepository>(provider =>
                    new DbRepository(provider.GetRequiredService<DataContext>()));
            return services;
        }
    }
}
