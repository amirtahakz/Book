using Common.Application;
using Domain.CategoryAgg.Repository;
using Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Remove
{
    public class RemoveCategoryCommandHandler : IBaseCommandHandler<RemoveCategoryCommand>
    {
        private readonly ICategoryRepository _repository;

        public RemoveCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteCategory(request.CategoryId);
            if (result)
            {
                await _repository.Save();
                return OperationResult.Success();
            }

            return OperationResult.Error("امکان حذف این دسته بندی وجود ندارد");
        }
    }
}
