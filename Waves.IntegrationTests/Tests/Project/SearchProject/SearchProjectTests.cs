using System;
using System.Threading.Tasks;
using Waves.Domain;
using Waves.Entities.Models;
using Waves.IntegrationTests.Base;
using Waves.IntegrationTests.Base.CollectionFixtures;
using Waves.IntegrationTests.Tests.Project.SearchProject;
using Waves.Services.Builders.QueryBuilders;
using Waves.Services.Models;
using Waves.Services.Models.Shared;
using Waves.Services.Services.TransactionService;
using Waves.Services.Stores;
using Xunit;

namespace Waves.IntegrationTests
{
    [Collection(nameof(CollectionDefinitions.Database))]
    public class SearchProjectTests : BaseIntegrationTest, IClassFixture<ProjectFixture>, IDisposable
    {
        private readonly ProjectFixture _fixture;

        public SearchProjectTests(ProjectFixture fixture) : base()
        {
            _fixture = fixture;
        }

        public void Dispose() { }

        [Theory, ClassData(typeof(ProjectSearchData))]
        public async Task Should_Return_Projects_Count_According_To_Filter_Parameters(
            ProjectSearchParametersModel parameters, Int32 expectedCount)
        {
            using (WavesDbContext context = new WavesDbContext(_fixture.DbOptions))
            {
                IProjectStore store = _GetProjectStore(context);
                ItemListModel<ProjectDTO> result = await store.GetAsync(parameters);

                Assert.Equal(expectedCount, result.TotalCount);
            }
        }

        private IProjectStore _GetProjectStore(WavesDbContext context)
        {
            IProjectSearchQueryBuilder builder = new ProjectSearchQueryBuilder(context);
            ITransactionService transactionService = new TransactionService(context);

            return new ProjectStore(iMapper, context, transactionService, builder);
        }
    }
}
