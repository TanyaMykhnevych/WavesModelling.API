using System;
using System.Threading.Tasks;
using Waves.Entities.Models.User;
using Waves.Services.Services.Models.User;

namespace Waves.Services.Stores.User
{
    public interface IUserStore
    {
        Task<AppUserDTO> GetUserById(Int32 id);
        Task<AppUserDTO> GetUserByEmail(String email);
        Task<AppUserDTO> CreateUserAsync(CreateUserModel userModel);
        Task<AppUserDTO> UpdateUserAsync(UpdateUserModel userModel);
        Task DeactivateUser(Int32 userId);
        Task DeleteUser(Int32 userId);
    }
}
