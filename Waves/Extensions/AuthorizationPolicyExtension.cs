using Microsoft.AspNetCore.Authorization;
using System;
using Waves.Services.Services.Models.Auth;
using Waves.Services.Services.RolePolicyService;

namespace Waves.WebAPI.Extensions
{
    public static class AuthorizationPolicyExtension
    {
        public static void AddRolePolicies(this AuthorizationOptions opt, IRolePolicyService service,
            Action<AuthorizationPolicyBuilder, AppRolePolicyModel> configureFunc = null)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (configureFunc == null)
            {
                configureFunc = DefaultConfigurePolicyFunc;
            }

            foreach (AppRolePolicyModel model in service.GetRolePolicies())
            {
                opt.AddPolicy(model.PolicyName, policy => configureFunc(policy, model));
            }
        }
        private static void DefaultConfigurePolicyFunc(AuthorizationPolicyBuilder policy, AppRolePolicyModel model)
        {
            policy.RequireClaim(AppRolePolicyModel.CLAIM_TYPE, model.Claims);
        }
    }
}
