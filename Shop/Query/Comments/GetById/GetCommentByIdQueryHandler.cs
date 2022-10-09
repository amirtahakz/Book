using Common.Query;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.Comments.DTOs;

namespace Query.Comments.GetById;

public class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery, CommentDto?>
{
    private readonly ApplicationDbContext _context;

    public GetCommentByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var res = await _context.Comments.FirstOrDefaultAsync(f => f.Id == request.CommentId);
        return res.Map();
    }
}