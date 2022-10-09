using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Finally
{
    public record OrderFinallyCommand(Guid OrderId) : IBaseCommand;
}
