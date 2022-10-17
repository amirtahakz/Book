using Common.Query;
using Query.Products.DTOs;

namespace Query.Products.GetForShop;

public class GetProductsForShopQuery : QueryFilter<ProductShopResult, ProductShopFilterParam>
{
    public GetProductsForShopQuery(ProductShopFilterParam filterParams) : base(filterParams)
    {
    }
}