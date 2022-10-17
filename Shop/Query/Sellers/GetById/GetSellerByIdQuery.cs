using Common.Query;
using Query.Sellers.DTOs;

namespace Query.Sellers.GetById;

public class GetSellerByIdQuery : IQuery<SellerDto>
{
    public GetSellerByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}