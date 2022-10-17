using Common.Query;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.Sellers.DTOs;

namespace Query.Sellers.GetByFilter;

public class GetSellerByFilterQuery : QueryFilter<SellerFilterResult, SellerFilterParams>
{
    public GetSellerByFilterQuery(SellerFilterParams filterParams) : base(filterParams)
    {
    }
}

public class SellerByFilterQueryHandler : IQueryHandler<GetSellerByFilterQuery, SellerFilterResult>
{
    private ApplicationDbContext _context;

    public SellerByFilterQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SellerFilterResult> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result = _context.Sellers.OrderByDescending(d => d.Id).AsQueryable();

        if (!string.IsNullOrWhiteSpace(@params.NationalCode))
            result = result.Where(r => r.NationalCode.Contains(@params.NationalCode));

        if (!string.IsNullOrWhiteSpace(@params.ShopName))
            result = result.Where(r => r.ShopName.Contains(@params.ShopName));


        var skip = (@params.PageId - 1) * @params.Take;

        var sellerResult = new SellerFilterResult()
        {
            FilterParams = @params,
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(seller => seller.Map())
                .ToListAsync(cancellationToken)
        };

        sellerResult.GeneratePaging(result, @params.Take, @params.PageId);
        return sellerResult;
    }
}