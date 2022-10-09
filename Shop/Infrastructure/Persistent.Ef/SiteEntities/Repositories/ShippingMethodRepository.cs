using Domain.SiteEntities;
using Domain.SiteEntities.Repositories;
using Infrastructure._Utilities;
using Infrastructure.Persistent.Ef;

namespace Infrastructure.Persistent.Ef.SiteEntities.Repositories;

internal class ShippingMethodRepository : BaseRepository<ShippingMethod>, IShippingMethodRepository
{
    public ShippingMethodRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void Delete(ShippingMethod slider)
    {
        Context.ShippingMethods.Remove(slider);
    }
}