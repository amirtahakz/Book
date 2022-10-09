using Common.Application;
using Common.Domain.ValueObjects;
using Domain.CategoryAgg;
using Domain.CategoryAgg.Repository;
using Domain.CategoryAgg.Services;
using Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Edit
{
    public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainService;

        public EditCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.Id);
            if (category == null)
                return OperationResult.NotFound();

            category.Edit(request.Title , request.Slug, request.SeoData , _domainService);

            await _repository.Save();

            return OperationResult.Success();
        }
    }
}
