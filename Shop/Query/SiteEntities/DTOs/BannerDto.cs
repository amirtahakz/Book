using Common.Query;
using Domain.SiteEntities.Enums;

namespace Query.SiteEntities.DTOs;

public class BannerDto : BaseDto
{
    public string Link { get; set; }
    public string ImageName { get; set; }
    public BannerPosition Position { get; set; }
}
