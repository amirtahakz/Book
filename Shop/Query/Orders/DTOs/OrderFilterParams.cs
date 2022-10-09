using Common.Query.Filter;
using Domain.OrderAgg.Enums;

namespace Query.Orders.DTOs;

public class OrderFilterParams : BaseFilterParam
{
    public Guid? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public OrderStatus? Status { get; set; }

}