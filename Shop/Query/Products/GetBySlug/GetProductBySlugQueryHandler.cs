using Common.Query;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.Products.DTOs;

namespace Query.Products.GetBySlug;

public class GetProductBySlugQueryHandler : IQueryHandler<GetProductBySlugQuery, ProductDto?>
{
    private readonly  ApplicationDbContext _context;

    public GetProductBySlugQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<ProductDto?> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
    {
        var res = await _context.Products.FirstOrDefaultAsync(p => p.Slug == request.Slug, cancellationToken);

        var model = res.Map();
        if (res == null)
            return null;
        await model.SetCategories(_context);
        return model;
    }
}