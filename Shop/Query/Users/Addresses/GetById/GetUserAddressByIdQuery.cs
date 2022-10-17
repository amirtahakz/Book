using Common.Query;
using Dapper;
using Infrastructure.Persistent.Dapper;
using Query.Users.DTOs;

namespace Query.Users.Addresses.GetById;

public record GetUserAddressByIdQuery(Guid AddressId) : IQuery<AddressDto?>;


public class GetUserAddressByIdQueryHandler : IQueryHandler<GetUserAddressByIdQuery, AddressDto?>
{
    private readonly DapperContext _dapperContext;

    public GetUserAddressByIdQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<AddressDto?> Handle(GetUserAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var sql = $"Select top 1 * from {_dapperContext.UserAddresses} where id=@id";
        using var context = _dapperContext.CreateConnection();
        return await context.QueryFirstOrDefaultAsync<AddressDto>(sql, new { id = request.AddressId });
    }
}
