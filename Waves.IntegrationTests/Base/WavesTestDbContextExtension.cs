using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Waves.Domain;

namespace Waves.IntegrationTests.Base
{
    public static class WavesTestDbContextExtension
    {
        public static void AddTestWavesDbContext(this IServiceCollection services, string connection)
        {
            services.AddDbContext<WavesDbContext>(provider => provider.UseSqlServer(connection), ServiceLifetime.Transient);
        }
    }
}
