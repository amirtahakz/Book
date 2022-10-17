using Application.Sellers.AddInventory;
using Application.Sellers.EditInventory;
using Common.Application;
using MediatR;
using Query.Sellers.DTOs;
using Query.Sellers.Inventories.GetById;
using Query.Sellers.Inventories.GetByProductId;
using Query.Sellers.Inventories.GetList;

namespace Presentation.Facade.Sellers.Inventories;

internal class SellerInventoryFacade : ISellerInventoryFacade
{
    private readonly IMediator _mediator;

    public SellerInventoryFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditInventory(EditSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<InventoryDto?> GetById(Guid inventoryId)
    {
        return await _mediator.Send(new GetSellerInventoryByIdQuery(inventoryId));
    }

    public async Task<List<InventoryDto>> GetList(Guid sellerId)
    {
        return await _mediator.Send(new GetInventoriesQuery(sellerId));
    }

    public async Task<List<InventoryDto>> GetByProductId(Guid productId)
    {
        return await _mediator.Send(new GetInventoriesByProductIdQuery(productId));
    }
}