using Common.Query;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.Sellers.DTOs;

namespace Query.Sellers.GetByUserId;

public class GetSellerByUserIdQueryHandler : IQueryHandler<GetSellerByUserIdQuery, SellerDto?>
{
    private readonly ApplicationDbContext _context;

    public GetSellerByUserIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SellerDto?> Handle(GetSellerByUserIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await _context.Sellers.FirstOrDefaultAsync(f => f.UserId == request.UserId,
            cancellationToken: cancellationToken);
        return seller.Map();
    }
}