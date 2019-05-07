using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Waves.Domain;
using Waves.Domain.Models;

namespace Waves.Services.Builders.QueryBuilders
{
    public class ProjectSearchQueryBuilder : IProjectSearchQueryBuilder
    {
        private WavesDbContext _context;
        private IQueryable<Project> _query;

        public ProjectSearchQueryBuilder(WavesDbContext context)
        {
            _context = context;
        }

        public IQueryable<Project> Build()
        {
            IQueryable<Project> resultQuery = _query;
            _query = null;

            return resultQuery;
        }

        public IProjectSearchQueryBuilder SetBaseProjectsInfo()
        {
            _query = _context.Projects
                .Include(p => p.Options)
                .Include(p => p.User)
                .Include(p => p.Sea)
                .ThenInclude(s => s.Oscillators)
                .Include(s => s.Sea)
                .ThenInclude(s => s.Isles);

            return this;
        }

        public IProjectSearchQueryBuilder SetProjectId(Int32? projectId)
        {
            if (projectId.HasValue)
            {
                _query = _query.Where(c => c.Id == projectId);
            }

            return this;
        }

        public IProjectSearchQueryBuilder SetUserId(Int32? userId)
        {
            if (userId.HasValue)
            {
                _query = _query.Where(c => c.UserId == userId);
            }

            return this;
        }

        public IProjectSearchQueryBuilder SetSearchTerm(String searchTerm)
        {
            if (!String.IsNullOrEmpty(searchTerm))
            {
                _query = _query.Where(p => !String.IsNullOrEmpty(p.Name) && p.Name.Contains(searchTerm));
            }

            return this;
        }

        public IProjectSearchQueryBuilder SetIsActive(Boolean? isActive)
        {
            if (isActive.HasValue)
            {
                _query = _query.Where(c => c.IsDeleted == !isActive);
            }

            return this;
        }

        public IProjectSearchQueryBuilder SetIsShared(Boolean? isShared)
        {
            if (isShared.HasValue)
            {
                _query = _query.Where(c => c.IsShared == isShared);
            }

            return this;
        }

        public IProjectSearchQueryBuilder OrderByCreatedDesc()
        {
            _query = _query.OrderByDescending(c => c.CreatedOn);

            return this;
        }
    }
}
