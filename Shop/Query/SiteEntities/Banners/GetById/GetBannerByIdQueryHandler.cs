using Common.Query;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.SiteEntities.DTOs;

namespace Query.SiteEntities.Banners.GetById;

public class GetBannerByIdQueryHandler : IQueryHandler<GetBannerByIdQuery, BannerDto>
{
    private readonly ApplicationDbContext _context;

    public GetBannerByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BannerDto> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
    {
        var banner = await _context.Banners.FirstOrDefaultAsync(f => f.Id == request.BannerId, cancellationToken);
        if (banner == null)
            return null;

        return new BannerDto()
        {
            Id = banner.Id,
            CreationDate = banner.CreationDate,
            ImageName = banner.ImageName,
            Link = banner.Link,
            Position = banner.Position
        };
    }
}