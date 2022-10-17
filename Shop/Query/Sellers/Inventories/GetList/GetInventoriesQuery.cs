using Common.Query;
using Query.Sellers.DTOs;

namespace Query.Sellers.Inventories.GetList;

public record GetInventoriesQuery(Guid SellerId) : IQuery<List<InventoryDto>>;