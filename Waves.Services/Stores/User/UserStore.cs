using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waves.Domain;
using Waves.Domain.Models.User;
using Waves.Entities.Models.User;
using Waves.Services.Constants;
using Waves.Services.Exceptions.Base;
using Waves.Services.Exceptions.User;
using Waves.Services.Services.Models.User;

namespace Waves.Services.Stores.User
{
    public class UserStore : IUserStore
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly WavesDbContext _context;

        public UserStore(IMapper mapper, WavesDbContext context, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        public async Task<AppUserDTO> GetUserById(Int32 id)
        {
            return _mapper.Map<AppUserDTO>(_context.AppUsers.Include(c => c.Role)
                                                            .FirstOrDefault(c => c.Id == id));
        }

        public async Task<AppUserDTO> GetUserByEmail(String email)
        {
            return _mapper.Map<AppUserDTO>(_context.AppUsers.Include(c => c.Role)
                                                            .FirstOrDefault(c => String.Equals(c.Email, email)));
        }

        public async Task<AppUserDTO> CreateUserAsync(CreateUserModel model)
        {
            AppUser existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                throw new EmailAlreadyTakenException();
            }

            AppUser user = _mapper.Map<AppUser>(model);
            user.IsActive = true;
            IdentityResult addUserResult = await _userManager.CreateAsync(user, model.Password);

            _ValidateIdentityResult(addUserResult);

            return _mapper.Map<AppUserDTO>(await GetUserById(user.Id));
        }

        public async Task<AppUserDTO> UpdateUserAsync(UpdateUserModel model)
        {
            List<String> errors = new List<String>();
            Boolean result = _ValidatePasswords(model, out errors);

            if (!result)
            {
                throw new InvalidUserPasswordException(String.Join(CommonConstants.SPACE, errors));
            }

            AppUser existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null && existingUser.Id != model.Id)
            {
                throw new EmailAlreadyTakenException();
            }

            AppUser user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            _mapper.Map(model, user);

            IdentityResult updateUserResult = await _userManager.UpdateAsync(user);
            _ValidateIdentityResult(updateUserResult);

            if (!String.IsNullOrEmpty(model.NewPassword))
            {
                IdentityResult changePasswordsResult = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
                if (!changePasswordsResult.Succeeded)
                {
                    throw new InvalidUserPasswordException(String.Join(CommonConstants.SPACE, errors));
                }
            }

            return await GetUserById(user.Id);
        }

        public async Task DeactivateUser(Int32 userId)
        {
            AppUser userToDeactivate = await _userManager.FindByIdAsync(userId.ToString());
            if (userToDeactivate == null)
            {
                throw new UserNotFoundException();
            }

            userToDeactivate.IsActive = false;

            IdentityResult updateUserResult = await _userManager.UpdateAsync(userToDeactivate);
            _ValidateIdentityResult(updateUserResult);
        }

        public async Task DeleteUser(Int32 userId)
        {
            AppUser userToDelete = await _userManager.FindByIdAsync(userId.ToString());
            IdentityResult deleteUserResult = await _userManager.DeleteAsync(userToDelete);

            _ValidateIdentityResult(deleteUserResult);
        }

        private void _ValidateIdentityResult(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                String errorsMessage = result.Errors
                                         .Select(er => er.Description)
                                         .Aggregate((i, j) => i + CommonConstants.SEMICOLON + j);
                throw new CustomBaseException(errorsMessage);
            }
        }

        private Boolean _ValidatePasswords(UpdateUserModel model, out List<String> errors)
        {
            errors = new List<String>();
            if (String.IsNullOrEmpty(model.Password) &&
                String.IsNullOrEmpty(model.NewPassword) &&
                String.IsNullOrEmpty(model.ConfirmPassword))
            {
                return true;
            }

            if (String.IsNullOrEmpty(model.Password) ||
                String.IsNullOrEmpty(model.NewPassword) ||
                String.IsNullOrEmpty(model.ConfirmPassword))
            {
                errors.Add(ErrorMessagesConstants.NOT_ALL_PASS_FIELDS_FILLED);
            }

            if (!model.NewPassword.Equals(model.ConfirmPassword))
            {
                errors.Add(ErrorMessagesConstants.PASSWORDS_DO_NOT_MATCH);
            }

            return errors.Any() ? false : true;
        }
    }
}
