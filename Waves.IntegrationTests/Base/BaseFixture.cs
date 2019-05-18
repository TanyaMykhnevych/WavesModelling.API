using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Waves.Domain;
using Waves.Services.Extensions.DbContextProvider;
using Waves.WebAPI.Extensions;

namespace Waves.IntegrationTests.Base
{
    public class BaseFixture
    {
        public DbContextOptions<WavesDbContext> DbOptions { get; private set; } //in memory non-relation database

        protected ServiceProvider ServiceProvider { get; private set; }

        public BaseFixture()
        {
            var config = new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();

            if (ServiceProvider == null)
            {
                ResetServiceProvider();
            }

            ConfigureDbOptions(config);
        }

        private void ConfigureDbOptions(IConfigurationRoot config)
        {
            DbOptions = new DbContextOptionsBuilder<WavesDbContext>()
                 .UseSqlServer(config.GetConnectionString("MsSQLConnection"))
                    .Options;            
        }

        public void ResetServiceProvider()
        {
            var config = new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTestWavesDbContext(config.GetConnectionString("MsSQLConnection"));
            serviceCollection.AddCustomComponents();
            serviceCollection.SetupIdentity();
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
