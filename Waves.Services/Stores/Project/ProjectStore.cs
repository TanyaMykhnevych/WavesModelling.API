﻿using AutoMapper;
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

        public async Task<ProjectDTO> AddOrUpdateAsync(ProjectDTO project)
        {
            Project newProject = _mapper.Map<Project>(project);
            _context.Update(newProject);
            _context.SaveChanges();

            return _mapper.Map<ProjectDTO>(newProject);
        }

        public Task DeleteAsync(Int32 projectId)
        {
            throw new NotImplementedException();
        }
    }
}