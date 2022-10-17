using Common.Query;
using Query.Users.DTOs;

namespace Query.Users.Addresses.GetList;

public record GetUserAddressesListQuery(Guid UserId) : IQuery<List<AddressDto>>;