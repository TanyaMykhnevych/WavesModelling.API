using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Waves.Domain;
using Waves.Domain.Identity;
using Waves.Domain.Models.User;

namespace Waves.Services.Extensions.DbContextProvider
{
    public static class DatabaseIdentityExtension
    {
        public static void SetupIdentity(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            IdentityBuilder builder = services.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType, typeof(WavesRole), builder.Services);
            builder.AddEntityFrameworkStores<WavesDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });
        }
    }
}
