using AutoMapper;
using Waves.Services.MapProfile;

namespace Waves.IntegrationTests.Base
{
    public class BaseIntegrationTest
    {
        public IMapper iMapper;
        public BaseIntegrationTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            iMapper = config.CreateMapper();
        }
    }
}
