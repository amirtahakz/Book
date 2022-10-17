using Common.Query;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.SiteEntities.DTOs;

namespace Query.SiteEntities.ShippingMethods.GetById;

public class GetShippingMethodByIdQueryHandler : IQueryHandler<GetShippingMethodByIdQuery, ShippingMethodDto?>
{
    private readonly ApplicationDbContext _context;

    public GetShippingMethodByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ShippingMethodDto?> Handle(GetShippingMethodByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.ShippingMethods.Select(s => new ShippingMethodDto
        {
            Id = s.Id,
            CreationDate = s.CreationDate,
            Title = s.Title,
            Cost = s.Cost
        }).FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken: cancellationToken);
    }
}