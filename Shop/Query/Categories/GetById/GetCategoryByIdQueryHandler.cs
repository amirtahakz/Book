using Common.Query;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.Categories.DTOs;

namespace Query.Categories.GetById;

internal class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ApplicationDbContext _context;

    public GetCategoryByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Categories
            .FirstOrDefaultAsync(f => f.Id == request.CategoryId, cancellationToken);
        return model.Map();
    }
}