using Application.Sellers.Create;
using Application.Sellers.Edit;
using Common.Application;
using MediatR;
using Query.Sellers.DTOs;
using Query.Sellers.GetByFilter;
using Query.Sellers.GetById;
using Query.Sellers.GetByUserId;
namespace Presentation.Facade.Sellers;

internal class SellerFacade : ISellerFacade
{
    private readonly IMediator _mediator;

    public SellerFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> CreateSeller(CreateSellerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditSeller(EditSellerCommand command)
    {
        return await _mediator.Send(command);

    }
    public async Task<SellerDto?> GetSellerById(Guid sellerId)
    {
        return await _mediator.Send(new GetSellerByIdQuery(sellerId));

    }

    public async Task<SellerDto?> GetSellerByUserId(Guid userId)
    {
        return await _mediator.Send(new GetSellerByUserIdQuery(userId));
    }

    public async Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams)
    {
        return await _mediator.Send(new GetSellerByFilterQuery(filterParams));
    }
}