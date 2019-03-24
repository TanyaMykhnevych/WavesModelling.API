using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Waves.Services.Services.Models.Auth;

namespace Waves.Services.Factories.AuthTokenFactory
{
    public class AuthTokenFactory : IAuthTokenFactory
    {
        public JwtSecurityToken CreateToken(String email, IEnumerable<Claim> businessClaims)
        {
            return CreateToken(email, AuthOptions.GetSymmetricSecurityKey(), AuthOptions.ISSUER, AuthOptions.AUDIENCE, businessClaims);
        }

        public JwtSecurityToken CreateToken(String email, SymmetricSecurityKey secret, String issuer, String audience, IEnumerable<Claim> businessClaims)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            claims.AddRange(businessClaims);

            SigningCredentials signinCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: signinCredentials);

            return jwtSecurityToken;
        }
    }
}
