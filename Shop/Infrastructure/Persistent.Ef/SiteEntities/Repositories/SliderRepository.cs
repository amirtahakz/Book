using Domain.SiteEntities;
using Domain.SiteEntities.Repositories;
using Infrastructure._Utilities;
using Infrastructure.Persistent.Ef;

namespace Infrastructure.Persistent.Ef.SiteEntities.Repositories;

internal class SliderRepository : BaseRepository<Slider>, ISliderRepository
{
    public SliderRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void Delete(Slider slider)
    {
        Context.Sliders.Remove(slider);
    }
}