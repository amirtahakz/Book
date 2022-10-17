using Common.Query;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.SiteEntities.DTOs;
namespace Query.SiteEntities.Sliders.GetList;

public class GetSliderListQueryHandler : IQueryHandler<GetSliderListQuery, List<SliderDto>>
{
    private readonly ApplicationDbContext _context;

    public GetSliderListQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SliderDto>> Handle(GetSliderListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Sliders.OrderByDescending(d => d.Id)
            .Select(slider => new SliderDto()
            {
                Id = slider.Id,
                CreationDate = slider.CreationDate,
                ImageName = slider.ImageName,
                Link = slider.Link,
                Title = slider.Title
            }).ToListAsync(cancellationToken);
    }
}