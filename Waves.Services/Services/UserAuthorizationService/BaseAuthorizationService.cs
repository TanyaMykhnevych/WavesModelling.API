using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Waves.Services.Factories.AuthTokenFactory;
using Waves.Services.Services.Models.Auth;

namespace Waves.Services.Services.UserAuthorizationService
{
    public abstract class BaseAuthorizationService
    {
        private readonly IAuthTokenFactory _tokenFactory;
        public BaseAuthorizationService(IAuthTokenFactory tokenFactory)
        {
            _tokenFactory = tokenFactory;
        }
        public async Task<JWTTokenStatusResult> GenerateTokenAsync(AuthSignInModel model)
        {
            Boolean status = await VerifyUserAsync(model);
            if (!status)
            {
                return new JWTTokenStatusResult() { Token = null, IsAuthorized = false };
            }

            IEnumerable<Claim> claims = await GetUserClaimsAsync(model);
            JwtSecurityToken token = _tokenFactory.CreateToken(model.Email.ToString(), claims);
            return new JWTTokenStatusResult()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                IsAuthorized = true,
                Features = claims.Select(x => x.Value)
            };
        }

        public abstract Task<IEnumerable<Claim>> GetUserClaimsAsync(AuthSignInModel model);
        public abstract Task<Boolean> VerifyUserAsync(AuthSignInModel model);
    }
}
