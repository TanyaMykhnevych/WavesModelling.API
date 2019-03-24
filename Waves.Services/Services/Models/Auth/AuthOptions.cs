using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Waves.Services.Services.Models.Auth
{
    public class AuthOptions
    {
        public const String ISSUER = "Waves.API";
        public const String AUDIENCE = "Waves";
        private const String SECRET_KEY = "4HqoFK424mTaaV3rOWq3uBy0z3JVc8Yh";
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));
        }
    }
}
