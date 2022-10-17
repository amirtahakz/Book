using Common.Query;
using Query.Sellers.DTOs;

namespace Query.Sellers.Inventories.GetByProductId;

public record GetInventoriesByProductIdQuery(Guid ProductId) : IQuery<List<InventoryDto>>;