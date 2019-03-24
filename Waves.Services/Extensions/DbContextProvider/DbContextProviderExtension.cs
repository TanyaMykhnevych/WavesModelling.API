using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Waves.Domain;

namespace Waves.Services.Extensions.DbContextProvider
{
    public static class DbContextProviderExtension
    {
        public static void AddWavesDbContext(this IServiceCollection services, String connection)
        {
            services.AddDbContext<WavesDbContext>(provider => provider.UseSqlServer(connection));
        }
    }
}
