using Application.Categories.AddChild;
using Application.Categories.Create;
using Application.Categories.Edit;
using Common.Application;
using Query.Categories.DTOs;

namespace Presentation.Facade.Categories;

public interface ICategoryFacade
{
    Task<OperationResult<Guid>> AddChild(AddChildCategoryCommand command);
    Task<OperationResult> Edit(EditCategoryCommand command);
    Task<OperationResult<Guid>> Create(CreateCategoryCommand command);
    Task<OperationResult> Remove(Guid categoryId);


    Task<CategoryDto> GetCategoryById(Guid id);
    Task<List<ChildCategoryDto>> GetCategoriesByParentId(Guid parentId);
    Task<List<CategoryDto>> GetCategories();

}