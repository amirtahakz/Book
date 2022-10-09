using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SellerAgg.Services
{
    public interface ISellerDomainService
    {
        bool NationalCodeExistInDataBase(string nationalCode);
        bool IsValidSellerInformation(Seller seller);
    }
}
