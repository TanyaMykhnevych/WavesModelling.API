using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Waves.Entities.Models;
using Waves.Services.Models;
using Waves.Services.Models.Shared;

namespace Waves.Services.Stores
{
    public interface IProjectStore
    {
        Task<ItemListModel<ProjectDTO>> GetAsync(ProjectSearchParametersModel parameters);
        Task<ProjectDTO> GetByIdAsync(Int32 projectId);
        Task<ProjectDTO> AddOrUpdateAsync(ProjectDTO project);
        Task<ProjectDTO> SetIsActive(Int32 id, Boolean isActive);
        Task DeleteAsync(Int32 projectId);
    }
}
