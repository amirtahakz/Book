using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.DeleteAddress
{
    public record DeleteUserAddressCommand(Guid UserId, Guid AddressId) : IBaseCommand;
}
