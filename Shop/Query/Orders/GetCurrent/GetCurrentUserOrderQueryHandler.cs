using Common.Query;
using Infrastructure.Persistent.Dapper;
using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Query.Orders.DTOs;

namespace Query.Orders.GetCurrent;

public class GetCurrentUserOrderQueryHandler : IQueryHandler<GetCurrentUserOrderQuery, OrderDto?>
{
    private readonly ApplicationDbContext _context;
    private readonly DapperContext _dapperContext;

    public GetCurrentUserOrderQueryHandler(ApplicationDbContext context, DapperContext dapperContext)
    {
        _context = context;
        _dapperContext = dapperContext;
    }
    public async Task<OrderDto?> Handle(GetCurrentUserOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(f => f.UserId == request.UserId && f.Status == Domain.OrderAgg.Enums.OrderStatus.Pending, cancellationToken);
        if (order == null)
            return null;

        var orderDto = order.Map();
        orderDto.UserFullName = await _context.Users.Where(f => f.Id == orderDto.UserId)
            .Select(s => $"{s.Name} {s.Family}").FirstAsync(cancellationToken);

        orderDto.Items = await orderDto.GetOrderItems(_dapperContext);
        return orderDto;
    }
}