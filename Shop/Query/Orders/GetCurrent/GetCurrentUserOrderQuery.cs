using Common.Query;
using Query.Orders.DTOs;

namespace Query.Orders.GetCurrent;

public record GetCurrentUserOrderQuery(Guid UserId) : IQuery<OrderDto?>;