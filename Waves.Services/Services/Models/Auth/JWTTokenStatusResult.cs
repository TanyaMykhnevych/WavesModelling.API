using System;
using System.Collections.Generic;

namespace Waves.Services.Services.Models.Auth
{
    public class JWTTokenStatusResult
    {
        public String Token { get; internal set; }
        public Boolean IsAuthorized { get; internal set; }
        public IEnumerable<String> Features { get; internal set; }
    }
}
