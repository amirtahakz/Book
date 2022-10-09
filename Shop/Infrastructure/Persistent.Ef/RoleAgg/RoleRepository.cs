using Common.Application.Validation;
using Domain.RoleAgg;
using Domain.RoleAgg.Repository;
using Infrastructure._Utilities;
using Infrastructure.Persistent.Ef;

namespace Infrastructure.Persistent.Ef.RoleAgg;

internal class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}