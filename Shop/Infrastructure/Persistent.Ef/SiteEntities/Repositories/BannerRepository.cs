using Domain.SiteEntities;
using Domain.SiteEntities.Repositories;
using Infrastructure._Utilities;
using Infrastructure.Persistent.Ef;

namespace Infrastructure.Persistent.Ef.SiteEntities.Repositories
{
    internal class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        public BannerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Delete(Banner banner)
        {
            Context.Banners.Remove(banner);
        }
    }
}