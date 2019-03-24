using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Waves.Domain.Identity;
using Waves.Domain.Models;
using Waves.Domain.Models.Base;
using Waves.Domain.Models.User;
using Waves.Domain.Services;

namespace Waves.Domain
{
    public class WavesDbContext : IdentityDbContext<AppUser, WavesRole, Int32>
    {
        private readonly UserResolverService _userService;
        public const String CreatedOn = "CreatedOn";
        public const String ModifiedOn = "ModifiedOn";
        public WavesDbContext(DbContextOptions<WavesDbContext> options, UserResolverService userService = null) : base(options)
        {
            _userService = userService;
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppFeature> AppFeatures { get; set; }
        public DbSet<AppRoleFeature> AppRoleFeatures { get; set; }

        public DbSet<Isle> Isles { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<Oscillator> Oscillators { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Sea> Seas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            _ConfigureCreatedOnProperty(builder);

            builder.Entity<AppRole>()
                   .HasIndex(r => r.Name)
                   .IsUnique();

            builder.Entity<AppUser>()
                   .HasOne(u => u.Role);

            builder.Entity<AppFeature>()
                   .HasMany(f => f.AppRoles);

            builder.Entity<AppRole>()
                   .HasMany(f => f.AppFeatures);
        }

        public override Int32 SaveChanges()
        {
            _SetUtcFormat();
            return base.SaveChanges();
        }

        public override Task<Int32> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            _SetUtcFormat();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void _SetUtcFormat()
        {
            IEnumerable<EntityEntry> modifiedEntries = ChangeTracker.Entries()
               .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

            DateTime now = DateTime.UtcNow;
            foreach (EntityEntry entry in modifiedEntries)
            {
                IBaseEntity entity = entry.Entity as IBaseEntity;
                if (entity == null) { continue; }

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedOn = now;
                }

                entity.ModifiedOn = now;
            }
        }


        private static void _ConfigureCreatedOnProperty(ModelBuilder builder)
        {
            List<Type> modelTypes = typeof(WavesDbContext).GetProperties()
                                     .Where(x => x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                                     .Select(x => x.PropertyType.GetGenericArguments().First())
                                     .ToList();

            foreach (Type modelType in modelTypes)
            {
                PropertyInfo key = modelType.GetProperties().FirstOrDefault(x => x.Name.Equals(CreatedOn));
                if (key == null) continue;

                builder.Entity(modelType)
                            .Property(key.Name)
                            .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
            }
        }
    }
}
