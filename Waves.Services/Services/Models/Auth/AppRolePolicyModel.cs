using System;
using System.Collections.Generic;

namespace Waves.Services.Services.Models.Auth
{
    public class AppRolePolicyModel
    {
        public String PolicyName { get; set; }
        public const String CLAIM_TYPE = "sstng";
        public IEnumerable<String> Claims { get; set; }

        public AppRolePolicyModel(String policyName, params String[] claims)
        {
            PolicyName = policyName;
            Claims = claims;
        }
    }
}
