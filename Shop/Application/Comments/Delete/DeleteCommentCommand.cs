using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Delete
{
    public record DeleteCommentCommand(Guid CommentId, Guid UserId) : IBaseCommand;
}
