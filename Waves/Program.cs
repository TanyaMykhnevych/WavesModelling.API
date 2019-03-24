using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Waves.Services.Extensions;

namespace Waves
{
    public class Program
    {
        public static void Main(String[] args)
        {
            IWebHost host = BuildWebHost(args);
            EnsureDatabaseInitialized(host);
            host.Run();

        }
        public static IWebHost BuildWebHost(String[] args)
        {
            String rootPath = Directory.GetCurrentDirectory();
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseContentRoot(rootPath)
                .Build();
        }


        public static void EnsureDatabaseInitialized(IWebHost host)
        {
            using (IServiceScope serviceScope = host.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                DatabaseInitializer.EnsureDatabaseInitialized(serviceScope);
            }
        }
    }
}
