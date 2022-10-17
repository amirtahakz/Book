using Application.Sellers.AddInventory;
using Application.Sellers.EditInventory;
using Common.Application;
using Query.Sellers.DTOs;

namespace Presentation.Facade.Sellers.Inventories;

public interface ISellerInventoryFacade
{
    Task<OperationResult> AddInventory(AddSellerInventoryCommand command);
    Task<OperationResult> EditInventory(EditSellerInventoryCommand command);

    Task<InventoryDto?> GetById(Guid inventoryId);
    Task<List<InventoryDto>> GetList(Guid sellerId);
    Task<List<InventoryDto>> GetByProductId(Guid productId);
}