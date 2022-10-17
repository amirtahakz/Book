﻿using Api.Infrastructure.Security;
using Application.Orders.AddItem;
using Application.Orders.Checkout;
using Application.Orders.DecreaseItemCount;
using Application.Orders.IncreaseItemCount;
using Application.Orders.RemoveItem;
using Common.AspNetCore;
using Domain.OrderAgg.Enums;
using Domain.RoleAgg.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.Orders;
using Query.Orders.DTOs;

namespace Api.Controllers;

[Authorize]
public class OrderController : ApiController
{
    private readonly IOrderFacade _orderFacade;

    public OrderController(IOrderFacade orderFacade)
    {
        _orderFacade = orderFacade;
    }

    [PermissionChecker(Permission.Order_Management)]
    [HttpGet]
    public async Task<ApiResult<OrderFilterResult>> GetOrderByFilter([FromQuery] OrderFilterParams filterParams)
    {
        var result = await _orderFacade.GetOrdersByFilter(filterParams);
        return QueryResult(result);
    }

    [HttpGet("current/filter")]
    public async Task<ApiResult<OrderFilterResult>> GetUserOrdersByFilter(int pageId = 1, int take = 10, OrderStatus status = OrderStatus.Finally)
    {
        var result = await _orderFacade.GetOrdersByFilter(new OrderFilterParams()
        {
            PageId = pageId,
            Take = take,
            Status = status,
            EndDate = null,
            StartDate = null,
            UserId = User.GetUserId()
        });
        return QueryResult(result);
    }

    [HttpGet("current")]
    public async Task<ApiResult<OrderDto?>> GetCurrentOrder()
    {
        var result = await _orderFacade.GetCurrentOrder(User.GetUserId());
        return QueryResult(result);
    }

    [HttpGet("{orderId}")]
    public async Task<ApiResult<OrderDto?>> GetOrderById(Guid orderId)
    {
        var result = await _orderFacade.GetOrderById(orderId);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> AddOrderItem(AddOrderItemCommand command)
    {
        var result = await _orderFacade.AddOrderItem(command);
        return CommandResult(result);
    }

    [HttpPost("Checkout")]
    public async Task<ApiResult> CheckoutOrder(CheckoutOrderCommand command)
    {
        var result = await _orderFacade.OrderCheckOut(command);
        return CommandResult(result);
    }

    [HttpPut("SendOrder/{orderId}")]
    public async Task<ApiResult> SendOrder(Guid orderId)
    {
        var result = await _orderFacade.SendOrder(orderId);
        return CommandResult(result);
    }

    [HttpPut("orderItem/IncreaseCount")]
    public async Task<ApiResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command)
    {
        var result = await _orderFacade.IncreaseItemCount(command);
        return CommandResult(result);
    }
    [HttpPut("orderItem/DecreaseCount")]
    public async Task<ApiResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand command)
    {
        var result = await _orderFacade.DecreaseItemCount(command);
        return CommandResult(result);
    }

    [HttpDelete("orderItem/{itemId}")]
    public async Task<ApiResult> RemoveOrderItem(Guid itemId)
    {
        var result = await _orderFacade.RemoveOrderItem(new RemoveOrderItemCommand(User.GetUserId(), itemId));
        return CommandResult(result);
    }
}