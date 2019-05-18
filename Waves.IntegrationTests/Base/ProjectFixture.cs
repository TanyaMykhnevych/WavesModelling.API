using Microsoft.EntityFrameworkCore;
using System;
using Waves.Domain;

namespace Waves.IntegrationTests.Base
{
    public class ProjectFixture : BaseFixture, IDisposable
    {
        public ProjectFixture() : base()
        {
            using (WavesDbContext context = new WavesDbContext(DbOptions))
            {
                _AddTestData(context);
            }
        }

        public void Dispose()
        {
            using (var context = new WavesDbContext(DbOptions))
            {
                context.Projects.RemoveRange(context.Projects);
                context.AppUsers.RemoveRange(context.AppUsers);
                context.AppRoles.RemoveRange(context.AppRoles);
                context.SaveChanges();
            }
        }

        private void _AddTestData(WavesDbContext context)
        {
            _AddUsers(context);
            _AddProjects(context);
        }

        private void _AddUsers(WavesDbContext context)
        {
            context.Database.ExecuteSqlCommand(@"                
SET IDENTITY_INSERT AppRoles ON;
INSERT INTO AppRoles (Id, IsActive, Name) VALUES (1, 'true', 'Test');
INSERT INTO AppRoles (Id, IsActive, Name) VALUES (2, 'true', 'OneMoreTest');
SET IDENTITY_INSERT AppRoles OFF;");


            context.Database.ExecuteSqlCommand(@"                
SET IDENTITY_INSERT AspNetUsers ON;
INSERT INTO AspNetUsers (Id, Email, RoleId, CreatedOn, ModifiedOn, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, IsActive) 
VALUES (1, 'test@gmail.com', 1, GETDATE(), GETDATE(), 'false', 'false', 'false', 'false', '5', 'true');
INSERT INTO AspNetUsers (Id, Email, RoleId, CreatedOn, ModifiedOn, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, IsActive)
VALUES (2, 'user@gmail.com', 2, GETDATE(), GETDATE(), 'false', 'false', 'false', 'false', '5', 'true');
SET IDENTITY_INSERT AspNetUsers OFF;");
        }

        private void _AddProjects(WavesDbContext context)
        {
            context.Database.ExecuteSqlCommand(@"                
SET IDENTITY_INSERT Projects ON;
INSERT INTO Projects (Id, UserId, Name, IsDeleted, CreatedOn, ModifiedOn) VALUES (1, 1, 'Test', 'false', GETDATE(), GETDATE());
INSERT INTO Projects (Id, UserId, Name, IsDeleted, CreatedOn, ModifiedOn) VALUES (2, 1, 'OneMoreTest', 'true', GETDATE(), GETDATE());
INSERT INTO Projects (Id, UserId, Name, IsDeleted, CreatedOn, ModifiedOn) VALUES (3, 1, 'new project', 'true', GETDATE(), GETDATE());
INSERT INTO Projects (Id, UserId, Name, IsDeleted, CreatedOn, ModifiedOn) VALUES (4, 1, '123', 'false', GETDATE(), GETDATE());
INSERT INTO Projects (Id, UserId, Name, IsDeleted, CreatedOn, ModifiedOn) VALUES (5, 1, 'waves', 'false', GETDATE(), GETDATE());
INSERT INTO Projects (Id, UserId, Name, IsDeleted, CreatedOn, ModifiedOn) VALUES (6, 2, 'difration', 'false', GETDATE(), GETDATE());
INSERT INTO Projects (Id, UserId, Name, IsDeleted, CreatedOn, ModifiedOn) VALUES (7, 2, 'Marinara', 'false', GETDATE(), GETDATE());
SET IDENTITY_INSERT Projects OFF;");

        }
    }
}
