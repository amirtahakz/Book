using Common.Query;
using Query.Products.DTOs;

namespace Query.Products.GetById;

public record GetProductByIdQuery(Guid Id) : IQuery<ProductDto?>;