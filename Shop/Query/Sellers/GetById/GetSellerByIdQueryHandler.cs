using Common.Query;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.Sellers.DTOs;

namespace Query.Sellers.GetById;

public class GetSellerByIdQueryHandler : IQueryHandler<GetSellerByIdQuery, SellerDto?>
{
    private ApplicationDbContext _shopContext;

    public GetSellerByIdQueryHandler(ApplicationDbContext shopContext)
    {
        _shopContext = shopContext;
    }

    public async Task<SellerDto?> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await _shopContext.Sellers.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken: cancellationToken);
        return seller.Map();
    }
}