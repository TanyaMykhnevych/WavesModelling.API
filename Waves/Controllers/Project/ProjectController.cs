using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Waves.Domain.Models.User;
using Waves.Entities.Models;
using Waves.Services.Enums;
using Waves.Services.Models;
using Waves.Services.Stores;
using Waves.Services.Stores.User;

namespace Waves.WebAPI.Controllers.Project
{
    [Route("api/[controller]")]
    [Authorize(Policy = nameof(AppFeatures.FullAccess))]
    public class ProjectController : Controller
    {
        private readonly IProjectStore _projectStore;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore _userStore;

        public ProjectController(IProjectStore projectStore, UserManager<AppUser> userManager, IUserStore userStore)
        {
            _projectStore = projectStore;
            _userManager = userManager;
            _userStore = userStore;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]ProjectSearchParametersModel parameters)
        {
            return Ok(await _projectStore.GetAsync(parameters));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int32 id)
        {
            return Ok(await _projectStore.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]ProjectDTO project)
        {

            project.UserId = await _GetCurrentUserId();
            return Ok(await _projectStore.AddOrUpdateAsync(project));
        }

        private async Task<Int32?> _GetCurrentUserId()
        {
            String email = _userManager.GetUserId(User);
            return (await _userStore.GetUserByEmail(email))?.Id;
        }
    }
}
