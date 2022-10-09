using Common.Query;
using Query.Categories.DTOs;

namespace Query.Categories.GetByParentId;

public record GetCategoryByParentIdQuery(Guid ParentId) : IQuery<List<ChildCategoryDto>>;