using Common.Query;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.Categories.DTOs;

namespace Query.Categories.GetList;

internal class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
{
    private readonly ApplicationDbContext _context;

    public GetCategoryListQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Categories
            .Where(r => r.ParentId == null)
            .Include(c => c.Childs)
            .ThenInclude(c => c.Childs)
            .OrderByDescending(d => d.Id).ToListAsync(cancellationToken);
        return model.Map();
    }
}