using Common.Query;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.SiteEntities.DTOs;

namespace Query.SiteEntities.Sliders.GetById;

public class GetSliderByIdQueryHandler : IQueryHandler<GetSliderByIdQuery, SliderDto>
{
    private readonly ApplicationDbContext _context;

    public GetSliderByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
    {
        var slider = await _context.Sliders
            .FirstOrDefaultAsync(f => f.Id == request.SliderId, cancellationToken);
        if (slider == null)
            return null;

        return new SliderDto()
        {
            Id = slider.Id,
            CreationDate = slider.CreationDate,
            ImageName = slider.ImageName,
            Link = slider.Link,
            Title = slider.Title
        };
    }
}