using Common.Query;
using Query.Orders.DTOs;

namespace Query.Orders.GetByFilter;

public class GetOrderByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
{
    public GetOrderByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
    {
    }
}