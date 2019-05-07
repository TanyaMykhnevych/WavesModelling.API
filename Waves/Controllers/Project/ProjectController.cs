using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Authorize(Policy = nameof(AppFeatures.FullAccess))]
        public async Task<IActionResult> Get([FromQuery]ProjectSearchParametersModel parameters)
        {
            parameters.UserId = await _GetCurrentUserId();
            return Ok(await _projectStore.GetAsync(parameters));
        }

        [HttpGet("{id}")]
        [Authorize(Policy = nameof(AppFeatures.FullAccess))]
        public async Task<IActionResult> Get(Int32 id)
        {
            return Ok(await _projectStore.GetByIdAsync(id));
        }

        [HttpGet("shared/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetShared(Int32 id)
        {
            return Ok(await _projectStore.GetByIdSharedAsync(id));
        }

        [HttpPost]
        [Authorize(Policy = nameof(AppFeatures.FullAccess))]
        public async Task<ActionResult> Post([FromBody]ProjectDTO project)
        {

            project.UserId = await _GetCurrentUserId();
            return Ok(await _projectStore.AddOrUpdateAsync(project));
        }

        [HttpPut("{id}")]
        [Authorize(Policy = nameof(AppFeatures.FullAccess))]
        public async Task<ActionResult> ChangeIsActive(Int32 id, [FromBody]DeactivateProjectModel model)
        {
            return Ok(await _projectStore.SetIsActiveAsync(id, model.IsActive));
        }

        [HttpPatch("{id}")]
        [Authorize(Policy = nameof(AppFeatures.FullAccess))]
        public async Task<ActionResult> Share(Int32 id, [FromBody]ShareProjectModel model)
        {
            return Ok(await _projectStore.ShareAsync(id, model.IsShared));
        }

        private async Task<Int32?> _GetCurrentUserId()
        {
            String email = _userManager.GetUserId(User);
            return (await _userStore.GetUserByEmail(email))?.Id;
        }
    }
}
