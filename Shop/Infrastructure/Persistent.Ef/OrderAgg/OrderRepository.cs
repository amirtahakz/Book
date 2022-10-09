using Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Domain.OrderAgg;
using Domain.OrderAgg.Enums;
using Domain.OrderAgg.Repository;
using Infrastructure._Utilities;

namespace Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {

        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Order?> GetCurrentUserOrder(Guid userId)
        {
            return await Context.Orders.AsTracking().FirstOrDefaultAsync(f => f.UserId == userId
            && f.Status == OrderStatus.Pending);
        }

       
    }
}