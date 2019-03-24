using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Waves.Services.Services.Models.Auth;
using Waves.Services.Services.UserAuthorizationService;

namespace Waves.WebAPI.Controllers.Auth
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly BaseAuthorizationService _authorizationService;
        public AuthController(BaseAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        [HttpPost]
        [AllowAnonymous]
        [Route("token")]
        public async Task<IActionResult> Login([FromBody]AuthSignInModel model)
        {
            JWTTokenStatusResult result = await _authorizationService.GenerateTokenAsync(model);
            if (!result.IsAuthorized) { return NotFound(); }

            return Ok(result);
        }
    }
}
