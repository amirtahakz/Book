using Common.Query;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.SiteEntities.DTOs;

namespace Query.SiteEntities.ShippingMethods.GetList;

internal class GetShippingMethodsByListQueryHandler : IQueryHandler<GetShippingMethodsByListQuery, List<ShippingMethodDto>>
{
    private readonly ApplicationDbContext _context;

    public GetShippingMethodsByListQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ShippingMethodDto>> Handle(GetShippingMethodsByListQuery request, CancellationToken cancellationToken)
    {
        return await _context.ShippingMethods.Select(s => new ShippingMethodDto
        {
            Id = s.Id,
            CreationDate = s.CreationDate,
            Title = s.Title,
            Cost = s.Cost
        }).ToListAsync(cancellationToken);
    }
}