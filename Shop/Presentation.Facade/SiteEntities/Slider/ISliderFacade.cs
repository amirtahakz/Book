using Application.SiteEntities.Sliders.Create;
using Application.SiteEntities.Sliders.Edit;
using Common.Application;
using Query.SiteEntities.DTOs;

namespace Presentation.Facade.SiteEntities.Slider;

public interface ISliderFacade
{
    Task<OperationResult> CreateSlider(CreateSliderCommand command);
    Task<OperationResult> EditSlider(EditSliderCommand command);
    Task<OperationResult> DeleteSlider(Guid sliderId);

    Task<SliderDto?> GetSliderById(Guid id);
    Task<List<SliderDto>> GetSliders();
}