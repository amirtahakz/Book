using Common.Query;
using Query.Comments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Comments.GetById
{
    public record GetCommentByIdQuery(Guid CommentId) : IQuery<CommentDto?>;
}
