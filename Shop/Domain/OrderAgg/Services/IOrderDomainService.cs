using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OrderAgg.Services
{
    public interface IOrderDomainService
    {
        bool IsProductExist(Guid productId);
    }
}
