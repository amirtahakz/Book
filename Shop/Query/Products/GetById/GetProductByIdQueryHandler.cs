using Common.Query;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.Products.DTOs;

namespace Query.Products.GetById;

public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly ApplicationDbContext _context;

    public GetProductByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var res = await _context.Products.FirstOrDefaultAsync(p=>p.Id == request.Id ,cancellationToken);

        var model = res.Map();


        if (model == null)
            return null;

        await model.SetCategories(_context);
        return model;
    }
}