using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Waves.Domain.Identity;
using Waves.Services.Services.Models.Auth;

namespace Waves.Services.Services.RolePolicyService
{
    public interface IRolePolicyService
    {
        IEnumerable<AppRolePolicyModel> GetRolePolicies();
        IEnumerable<Claim> TransformFeaturesToClaims(IEnumerable<AppFeature> features);
    }
}
