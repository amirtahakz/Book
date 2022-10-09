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

namespace Application.Categories.Create
{
    public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainService;

        public EditCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult<Guid>> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Slug , request.Title , request.SeoData , _domainService);

            await _repository.AddAsync(category);
            await _repository.Save();

            return OperationResult<Guid>.Success(category.Id);
        }
    }
}
