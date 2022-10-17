using Common.Query;
using Query.Roles.DTOs;

namespace Query.Roles.GetList;

public record GetRoleListQuery : IQuery<List<RoleDto>>;