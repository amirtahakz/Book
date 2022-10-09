using Common.Domain.Repository;
using Domain.CategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommentAgg.Repository
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task DeleteAndSave(Comment comment);
    }
}
