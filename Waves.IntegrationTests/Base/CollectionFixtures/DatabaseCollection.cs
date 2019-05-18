using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Waves.IntegrationTests.Base.CollectionFixtures
{
    [CollectionDefinition(nameof(CollectionDefinitions.Database))]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        public DatabaseCollection()
        {

        }
    }
}
