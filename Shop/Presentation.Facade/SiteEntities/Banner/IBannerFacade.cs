using Application.SiteEntities.Banners.Create;
using Application.SiteEntities.Banners.Edit;
using Common.Application;
using Query.SiteEntities.DTOs;

namespace Presentation.Facade.SiteEntities.Banner;

public interface IBannerFacade
{
    Task<OperationResult> CreateBanner(CreateBannerCommand command);
    Task<OperationResult> EditBanner(EditBannerCommand command);
    Task<OperationResult> DeleteBanner(Guid bannerId);

    Task<BannerDto?> GetBannerById(Guid id);
    Task<List<BannerDto>> GetBanners();
}