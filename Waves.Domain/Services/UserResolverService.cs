using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Waves.Domain.Services
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string GetUser()
        {
            return _context.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
