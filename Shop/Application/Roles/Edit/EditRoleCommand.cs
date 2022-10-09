using Common.Application;
using Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Roles.Edit
{
    public record EditRoleCommand(Guid Id, string Title, List<Permission> Permissions) : IBaseCommand;
}
