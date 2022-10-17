using Common.Query;

namespace Query.SiteEntities.DTOs;

public class SliderDto : BaseDto
{
    public string Title { get; set; }
    public string Link { get; set; }
    public string ImageName { get; set; }
}