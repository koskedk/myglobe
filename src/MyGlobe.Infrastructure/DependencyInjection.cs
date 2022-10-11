using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyGlobe.Domain;
using MyGlobe.Infrastructure.Persistence;

namespace MyGlobe.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                o => o.UseSqlServer(GetSqlConnection(configuration))
            );
            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            return services;
        }

        private static string GetInMemoryConnection(IConfiguration configuration)
        {
            return Guid.NewGuid().ToString();
        }

        private static SqliteConnection GetSqliteConnection(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("sqliteConnection");
                return new SqliteConnection(connectionString);
        }
        private static string GetSqlConnection(IConfiguration configuration)
        {
            return configuration.GetConnectionString("liveConnection");
        }
    }
}