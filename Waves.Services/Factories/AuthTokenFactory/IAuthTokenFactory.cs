using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Waves.Services.Factories.AuthTokenFactory
{
    public interface IAuthTokenFactory
    {
        JwtSecurityToken CreateToken(String accessCode, IEnumerable<Claim> businessClaims);
        JwtSecurityToken CreateToken(String accessCode, SymmetricSecurityKey secret, String issuer, String audience, IEnumerable<Claim> businessClaims);
    }
}
