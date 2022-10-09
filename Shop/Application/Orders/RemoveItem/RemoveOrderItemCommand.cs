using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.RemoveItem
{
    public record RemoveOrderItemCommand(Guid UserId, Guid ItemId) : IBaseCommand;
}
