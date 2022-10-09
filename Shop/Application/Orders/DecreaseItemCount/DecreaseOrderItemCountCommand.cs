using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.DecreaseItemCount
{
    public record DecreaseOrderItemCountCommand(Guid UserId, Guid ItemId, int Count) : IBaseCommand;
}
