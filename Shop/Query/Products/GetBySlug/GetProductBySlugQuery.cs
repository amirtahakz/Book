using Common.Query;
using Query.Products.DTOs;

namespace Query.Products.GetBySlug;

public record GetProductBySlugQuery(string Slug) : IQuery<ProductDto?>;