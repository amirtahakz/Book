using Common.Query;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.Categories.DTOs;

namespace Query.Categories.GetByParentId;

internal class GetCategoryByParentIdQueryHandler : IQueryHandler<GetCategoryByParentIdQuery, List<ChildCategoryDto>>
{
    private readonly ApplicationDbContext _context;

    public GetCategoryByParentIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ChildCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Categories
            .Include(c => c.Childs)
            .Where(r => r.ParentId == request.ParentId).ToListAsync(cancellationToken);

        return result.MapChildren();
    }
}