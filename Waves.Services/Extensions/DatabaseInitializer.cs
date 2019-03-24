using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using Waves.Domain;

namespace Waves.Services.Extensions
{
    public static class DatabaseInitializer
    {
        public static void EnsureDatabaseInitialized(IServiceScope serviceScope)
        {
            WavesDbContext context = serviceScope.ServiceProvider.GetRequiredService<WavesDbContext>();
            Boolean isFirstLaunch = !(context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists();
            context.Database.Migrate();
            if (isFirstLaunch)
            {
                AddTestData(context);
            }
            context.Dispose();
        }

        public static void AddTestData(WavesDbContext context)
        {
            AddIdentityData(context);
        }

        public static void AddIdentityData(WavesDbContext context)
        {
            context.Database.ExecuteSqlCommand($@"
                    SET IDENTITY_INSERT appfeatures ON;
                    INSERT INTO appfeatures (Id, Name, Description) VALUES (1, 'FullAccess', 'Full Access');
                    SET IDENTITY_INSERT appfeatures OFF;");

            context.Database.ExecuteSqlCommand($@"
                    SET IDENTITY_INSERT approles ON;
                    INSERT INTO approles (Id, Name, isActive) VALUES (1, 'SuperAdmin', 'true');
                    SET IDENTITY_INSERT approles OFF;");

            context.Database.ExecuteSqlCommand($@"
                    SET IDENTITY_INSERT approlefeatures ON;
                    INSERT INTO approlefeatures (Id, CreatedOn, ModifiedOn, AppRoleId, AppFeatureId) VALUES (1, GETDATE(), GETDATE(), 1,  1);
                    SET IDENTITY_INSERT approlefeatures OFF;");

            // password for superuser: 123456
            context.Database.ExecuteSqlCommand($@"
                    SET IDENTITY_INSERT aspnetusers ON;
                    INSERT INTO aspnetusers (Id, CreatedOn, ModifiedOn, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, FirstName, LastName, IsActive, RoleId) VALUES 
                    (1, GETDATE(), GETDATE(), 'superuser@gmail.com', 'SUPERUSER@GMAIL.COM', 'superuser@gmail.com', 'SUPERUSER@GMAIL.COM', 'true', 'AQAAAAEAACcQAAAAEIUEA9TSyuVATZj+snuxTMC4ZKk/jIcgJwa1M/aY/SBH1b9W4Nn7qMwLBTebRBvboA==', '123456789', 'true', 'false', 'false', '0', 'Super', 'User', 'true', '1');
                    SET IDENTITY_INSERT aspnetusers OFF;");
        }
    }
}
