using Common.Query;
using Query.Sellers.DTOs;

namespace Query.Sellers.Inventories.GetById;

public record GetSellerInventoryByIdQuery(Guid InventoryId) : IQuery<InventoryDto>;