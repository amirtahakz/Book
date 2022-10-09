using Common.Query;
using Query.Categories.DTOs;

namespace Query.Categories.GetById;

public record GetCategoryByIdQuery(Guid CategoryId) : IQuery<CategoryDto>;