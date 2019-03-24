using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Waves.Domain;
using Waves.Domain.Identity;
using Waves.Services.Services.Models.Auth;

namespace Waves.Services.Services.RolePolicyService
{
    public class RolePolicyService : IRolePolicyService
    {
        private readonly WavesDbContext _context;

        public RolePolicyService(WavesDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AppRolePolicyModel> GetRolePolicies()
        {
            IEnumerable<String> features = _context.AppFeatures.Select(f => f.Name);

            foreach (String name in features)
            {
                yield return new AppRolePolicyModel(name, name);
            }
        }

        public IEnumerable<Claim> TransformFeaturesToClaims(IEnumerable<AppFeature> features)
        {
            return features.Select(x => { return new Claim(AppRolePolicyModel.CLAIM_TYPE, x.Name); });
        }
    }
}
