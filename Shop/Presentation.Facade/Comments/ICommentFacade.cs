using Application.Comments.ChangeStatus;
using Application.Comments.Create;
using Application.Comments.Delete;
using Application.Comments.Edit;
using Common.Application;
using Query.Comments.DTOs;

namespace Presentation.Facade.Comments;

public interface ICommentFacade
{
    Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command);
    Task<OperationResult<Guid>> CreateComment(CreateCommentCommand command);
    Task<OperationResult> EditComment(EditCommentCommand command);
    Task<OperationResult> DeleteComment(DeleteCommentCommand command);


    Task<CommentDto?> GetCommentById(Guid id);
    Task<CommentFilterResult> GetCommentsByFilter(CommentFilterParams filterParams);
}