using Application.Orders.AddItem;
using Application.Orders.Checkout;
using Application.Orders.DecreaseItemCount;
using Application.Orders.Finally;
using Application.Orders.IncreaseItemCount;
using Application.Orders.RemoveItem;
using Common.Application;
using Query.Orders.DTOs;


namespace Presentation.Facade.Orders;

public interface IOrderFacade
{
    Task<OperationResult> AddOrderItem(AddOrderItemCommand command);
    Task<OperationResult> OrderCheckOut(CheckoutOrderCommand command);
    Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command);
    Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command);
    Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command);
    Task<OperationResult> FinallyOrder(OrderFinallyCommand command);
    Task<OperationResult> SendOrder(Guid orderId);



    Task<OrderDto?> GetOrderById(Guid orderId);
    Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams filterParams);
    Task<OrderDto?> GetCurrentOrder(Guid userId);
}