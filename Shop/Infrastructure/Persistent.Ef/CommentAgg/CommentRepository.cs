using Domain.CommentAgg;
using Domain.CommentAgg.Repository;
using Infrastructure._Utilities;
using Infrastructure.Persistent.Ef;

namespace Infrastructure.Persistent.Ef.CommentAgg;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task DeleteAndSave(Comment comment)
    {
        Context.Remove(comment);
        await Context.SaveChangesAsync();
    }
}