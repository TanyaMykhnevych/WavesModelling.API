using System;
using Waves.Domain.Models;

namespace Waves.Services.Builders.QueryBuilders
{
    public interface IProjectSearchQueryBuilder : IQueryBuilder<Project>
    {
        IProjectSearchQueryBuilder SetBaseProjectsInfo();
        IProjectSearchQueryBuilder SetProjectId(Int32? projectId);
        IProjectSearchQueryBuilder SetUserId(Int32? userId);
        IProjectSearchQueryBuilder SetSearchTerm(String searchTerm);
        IProjectSearchQueryBuilder OrderByCreatedDesc();
    }
}
