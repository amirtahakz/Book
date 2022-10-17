using Application.SiteEntities.ShippingMethod.Create;
using Application.SiteEntities.ShippingMethod.Delete;
using Application.SiteEntities.ShippingMethod.Edit;
using Common.Application;
using MediatR;
using Query.SiteEntities.DTOs;
using Query.SiteEntities.ShippingMethods.GetById;
using Query.SiteEntities.ShippingMethods.GetList;

namespace Presentation.Facade.SiteEntities.ShippingMethods;

internal class ShippingMethodFacade : IShippingMethodFacade
{
    private readonly IMediator _mediator;

    public ShippingMethodFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateShippingMethodCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditShippingMethodCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> Delete(Guid id)
    {
        return await _mediator.Send(new DeleteShippingMethodCommand(id));

    }

    public async Task<ShippingMethodDto?> GetShippingMethodById(Guid id)
    {
        return await _mediator.Send(new GetShippingMethodByIdQuery(id));

    }

    public async Task<List<ShippingMethodDto>> GetList()
    {
        return await _mediator.Send(new GetShippingMethodsByListQuery());

    }
}