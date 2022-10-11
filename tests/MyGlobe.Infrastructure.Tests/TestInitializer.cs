using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyGlobe.Infrastructure.Persistence;
using NUnit.Framework;
using Serilog;

namespace MyGlobe.Infrastructure.Tests
{
    [SetUpFixture]
    public class TestInitializer
    {
        public static IServiceProvider ServiceProvider;
        
        [OneTimeSetUp]
        public void Init()
        {
            
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            var services = new ServiceCollection();
            services.AddInfrastructure(config);
            ServiceProvider = services.BuildServiceProvider();
            
            InitDB();
        }
        
        private void InitDB()
        {
            var context = ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            context.Database.EnsureDeleted();
        }
    }
}