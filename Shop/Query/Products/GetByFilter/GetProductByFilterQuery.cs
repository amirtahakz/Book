using Common.Query;
using Query.Orders.DTOs;
using Query.Orders;
using Query.Products.DTOs;

namespace Query.Products.GetByFilter;

public class GetProductByFilterQuery : QueryFilter<ProductFilterResult , ProductFilterParams>
{
    public GetProductByFilterQuery(ProductFilterParams filterParams) : base(filterParams)
    {
        
    }
}