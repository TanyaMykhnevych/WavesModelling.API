using Microsoft.EntityFrameworkCore;
using System;
using Waves.Domain;

namespace Waves.IntegrationTests.Base
{
    public class DatabaseFixture : BaseFixture, IDisposable
    {
        public DatabaseFixture() : base()
        {
            using (var context = new WavesDbContext(DbOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
        }

        public void Dispose()
        {
            using (var context = new WavesDbContext(DbOptions))
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
