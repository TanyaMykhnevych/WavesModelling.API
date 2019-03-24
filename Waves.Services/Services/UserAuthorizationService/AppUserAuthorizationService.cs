using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Waves.Domain;
using Waves.Domain.Identity;
using Waves.Domain.Models.User;
using Waves.Services.Enums;
using Waves.Services.Extensions.Enums;
using Waves.Services.Factories.AuthTokenFactory;
using Waves.Services.Services.Models.Auth;
using Waves.Services.Services.RolePolicyService;

namespace Waves.Services.Services.UserAuthorizationService
{
    public class AppUserAuthorizationService : BaseAuthorizationService
    {
        private readonly WavesDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRolePolicyService _policyService;
        private readonly SignInManager<AppUser> _signInManager;
        public AppUserAuthorizationService(IAuthTokenFactory tokenFactory, UserManager<AppUser> userManager,
            WavesDbContext context, IRolePolicyService policyService, SignInManager<AppUser> signInManager) : base(tokenFactory)
        {
            _context = context;
            _userManager = userManager;
            _policyService = policyService;
            _signInManager = signInManager;
        }

        public override async Task<IEnumerable<Claim>> GetUserClaimsAsync(AuthSignInModel model)
        {
            AppRole userRole = _context.AppUsers.Include(u => u.Role)
                                                .Where(x => x.Email == model.Email)
                                                .FirstOrDefault()?.Role;

            if (userRole == null || !userRole.IsActive)
            {
                return new List<Claim>();
            }

            List<AppFeature> features = _context.AppRoleFeatures
                                                .Include(f => f.AppFeature)
                                                .Where(f => f.AppRoleId == userRole.Id)
                                                .Select(f => f.AppFeature)
                                                .ToList();

            if (features.Select(f => f.Name).Contains(EnumsExtensions.GetDescription(AppFeatures.FullAccess)))
            {
                features = _context.AppFeatures.ToList();
            }

            return _policyService.TransformFeaturesToClaims(features);
        }

        public async override Task<Boolean> VerifyUserAsync(AuthSignInModel model)
        {
            AppUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return false;
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            return result.Succeeded;
        }
    }
}
