using Common.Query;
using Query.SiteEntities.DTOs;

namespace Query.SiteEntities.Sliders.GetById;

public record GetSliderByIdQuery(Guid SliderId) : IQuery<SliderDto>;
