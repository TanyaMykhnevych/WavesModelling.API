using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waves.Domain;
using Waves.Domain.Models;
using Waves.Entities.Models;
using Waves.Services.Builders.QueryBuilders;
using Waves.Services.Models;
using Waves.Services.Models.Shared;
using Waves.Services.Services.TransactionService;

namespace Waves.Services.Stores
{
    public class ProjectStore : IProjectStore
    {
        private readonly IMapper _mapper;
        private readonly WavesDbContext _context;
        private readonly ITransactionService _transactionService;
        private readonly IProjectSearchQueryBuilder _queryBuilder;

        public ProjectStore(IMapper mapper, WavesDbContext context, ITransactionService transactionService, IProjectSearchQueryBuilder queryBuilder)
        {
            _mapper = mapper;
            _context = context;
            _transactionService = transactionService;
            _queryBuilder = queryBuilder;
        }

        public async Task<ItemListModel<ProjectDTO>> GetAsync(ProjectSearchParametersModel parameters)
        {
            IQueryable<Project> query = _queryBuilder.SetBaseProjectsInfo()
                                                     .SetUserId(parameters.UserId)
                                                     .SetProjectId(parameters.ProjectId)
                                                     .SetSearchTerm(parameters.SearchTerm)
                                                     .SetIsActive(parameters.IsActive)
                                                     .OrderByCreatedDesc()
                                                     .Build();

            Int32 totalCount = await query.CountAsync();

            if (parameters.Page != 0)
            {
                query = query.Skip((parameters.Page - 1) * parameters.PerPage);
            }

            query = query.Take(parameters.PerPage);

            return new ItemListModel<ProjectDTO>
            {
                Items = _mapper.Map<List<ProjectDTO>>(query.ToList()),
                TotalCount = totalCount
            };
        }

        public async Task<ProjectDTO> GetByIdAsync(Int32 projectId)
        {
            Project model = _queryBuilder.SetBaseProjectsInfo()
                                         .SetProjectId(projectId)
                                         .Build()
                                         .FirstOrDefault();

            return _mapper.Map<ProjectDTO>(model);
        }

        public async Task<ProjectDTO> GetByIdSharedAsync(Int32 projectId)
        {
            Project model = _queryBuilder.SetBaseProjectsInfo()
                                         .SetProjectId(projectId)
                                         .SetIsActive(true)
                                         .SetIsShared(true)
                                         .Build()
                                         .FirstOrDefault();

            return _mapper.Map<ProjectDTO>(model);
        }

        public async Task<ProjectDTO> AddOrUpdateAsync(ProjectDTO project)
        {
            Project newProject = _mapper.Map<Project>(project);
            _context.Update(newProject);
            _context.SaveChanges();

            return _mapper.Map<ProjectDTO>(newProject);
        }

        public async Task<ProjectDTO> SetIsActiveAsync(Int32 id, Boolean isActive)
        {
            Project proj = _context.Projects.Find(id);
            proj.IsDeleted = !isActive;
            _context.Entry(proj).Property(x => x.IsDeleted).IsModified = true;
            await _context.SaveChangesAsync();

            return _mapper.Map<ProjectDTO>(proj);
        }

        public async Task<ProjectDTO> ShareAsync(Int32 id, Boolean isShared)
        {
            Project proj = _context.Projects.Find(id);
            if (!proj.IsDeleted)
            {
                proj.IsShared = isShared;
                _context.Entry(proj).Property(x => x.IsShared).IsModified = true;
                await _context.SaveChangesAsync();
            }

            return _mapper.Map<ProjectDTO>(proj);
        }

        public async Task DeleteAsync(Int32 projectId)
        {
            Project proj = _context.Projects.Find(projectId);
            _context.Projects.Remove(proj);
            await _context.SaveChangesAsync();
        }
    }
}
