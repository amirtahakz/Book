using Common.Application;
using Domain.CommentAgg;
using Domain.CommentAgg.Repository;

namespace Application.Comments.Create
{
    public class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand, Guid>
    {
        private readonly ICommentRepository _repository;

        public CreateCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<Guid>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment(request.UserId , request.ProductId , request.Text);

            await _repository.AddAsync(comment);
            await _repository.Save();

            return OperationResult<Guid>.Success(comment.Id);
        }
    }
}
