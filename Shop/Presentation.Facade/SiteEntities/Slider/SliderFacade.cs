using Application.SiteEntities.Sliders.Create;
using Application.SiteEntities.Sliders.Delete;
using Application.SiteEntities.Sliders.Edit;
using Common.Application;
using MediatR;
using Presentation.Facade.SiteEntities.Slider;
using Query.SiteEntities.DTOs;
using Query.SiteEntities.Sliders.GetById;
using Query.SiteEntities.Sliders.GetList;

namespace Presentation.Facade.SiteEntities.Slider;

internal class SliderFacade : ISliderFacade
{
    private readonly IMediator _mediator;

    public SliderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> CreateSlider(CreateSliderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditSlider(EditSliderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DeleteSlider(Guid sliderId)
    {
        return await _mediator.Send(new DeleteSliderCommand(sliderId));
    }

    public async Task<SliderDto?> GetSliderById(Guid id)
    {
        return await _mediator.Send(new GetSliderByIdQuery(id));

    }
    public async Task<List<SliderDto>> GetSliders()
    {
        return await _mediator.Send(new GetSliderListQuery());
    }
}