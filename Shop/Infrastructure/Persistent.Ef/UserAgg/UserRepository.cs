using Infrastructure.Persistent.Ef;
using Domain.UserAgg;
using Domain.UserAgg.Repository;
using Infrastructure._Utilities;

namespace Infrastructure.Persistent.Ef.UserAgg
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}