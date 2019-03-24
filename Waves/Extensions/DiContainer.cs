using Waves.Services.Stores.User;
using Microsoft.Extensions.DependencyInjection;
using Waves.Domain.Services;
using Waves.Services.Factories.AuthTokenFactory;
using Waves.Services.Services.RolePolicyService;
using Waves.Services.Services.TransactionService;
using Waves.Services.Services.UserAuthorizationService;
using Waves.Services.Builders.QueryBuilders;
using Waves.Services.Stores;

namespace Waves.WebAPI.Extensions
{
    public static class DiContainer
    {
        public static void AddCustomComponents(this IServiceCollection services)
        {
            //factories
            services.AddTransient<IAuthTokenFactory, AuthTokenFactory>();

            //services
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IRolePolicyService, RolePolicyService>();
            services.AddTransient<BaseAuthorizationService, AppUserAuthorizationService>();
            services.AddTransient<UserResolverService>();

            services.AddTransient<IUserStore, UserStore>();
            services.AddTransient<IProjectStore, ProjectStore>();

            services.AddTransient<IProjectSearchQueryBuilder, ProjectSearchQueryBuilder>();
        }
    }
}
