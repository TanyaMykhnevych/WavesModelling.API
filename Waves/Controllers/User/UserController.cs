using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;
using Waves.Services.Constants;
using Waves.Services.Enums;
using Waves.Services.Exceptions.User;
using Waves.Services.Services.Models.User;
using Waves.Services.Stores.User;

namespace Waves.WebAPI.Controllers.User
{
    [Route("api/[controller]")]
    [Authorize(Policy = nameof(AppFeatures.FullAccess))]
    public class UserController : Controller
    {
        private readonly IUserStore _store;
        public UserController(IUserStore store)
        {
            _store = store;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Int32 id)
        {
            return Ok(await _store.GetUserById(id));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]CreateUserModel model)
        {
            model.RoleId = ReservedConstants.SUPER_ADMIN_ROLE_ID;
            try
            {
                return Ok(await _store.CreateUserAsync(model));
            }
            catch (EmailAlreadyTakenException)
            {
                return BadRequest(_AddModelStateError(FieldNamesConstants.EMAIL, ErrorMessagesConstants.EMAIL_ALREADY_TAKEN));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateUserModel model)
        {
            if (model.Id == ReservedConstants.SUPER_USER_ID)
            {
                return BadRequest(_AddModelStateError(FieldNamesConstants.ERROR, ErrorMessagesConstants.MODIFY_SUPER_USER_ERROR));
            }

            try
            {
                return Ok(await _store.UpdateUserAsync(model));
            }
            catch (InvalidUserPasswordException)
            {
                return BadRequest(_AddModelStateError(FieldNamesConstants.PASSWORD, ErrorMessagesConstants.INVALID_PASSWORD));
            }
            catch (EmailAlreadyTakenException)
            {
                return BadRequest(_AddModelStateError(FieldNamesConstants.EMAIL, ErrorMessagesConstants.EMAIL_ALREADY_TAKEN));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DeactivateUser(Int32 id)
        {
            if (id == ReservedConstants.SUPER_USER_ID)
            {
                return BadRequest(_AddModelStateError(FieldNamesConstants.ERROR, ErrorMessagesConstants.DELETE_SUPER_USER_ERROR));
            }

            await _store.DeactivateUser(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Int32 id)
        {
            if (id == ReservedConstants.SUPER_USER_ID)
            {
                return BadRequest(_AddModelStateError(FieldNamesConstants.ERROR, ErrorMessagesConstants.DELETE_SUPER_USER_ERROR));
            }

            await _store.DeleteUser(id);
            return Ok();
        }

        private ModelStateDictionary _AddModelStateError(String field, String error)
        {
            ModelStateDictionary modelState = new ModelStateDictionary();
            modelState.TryAddModelError(field, error);
            return modelState;
        }
    }
}
