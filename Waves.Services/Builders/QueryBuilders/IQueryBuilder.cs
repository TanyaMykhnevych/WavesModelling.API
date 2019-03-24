using System.Linq;

namespace Waves.Services.Builders.QueryBuilders
{
    public interface IQueryBuilder<TEnitity>
    {
        IQueryable<TEnitity> Build();
    }
}
