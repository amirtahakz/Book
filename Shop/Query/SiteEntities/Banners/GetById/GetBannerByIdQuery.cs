using Common.Query;
using Query.SiteEntities.DTOs;

namespace Query.SiteEntities.Banners.GetById;

public record GetBannerByIdQuery(Guid BannerId) : IQuery<BannerDto>;