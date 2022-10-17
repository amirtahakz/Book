using Application.Sellers.Create;
using Application.Sellers.Edit;
using Common.Application;
using Query.Sellers.DTOs;

namespace Presentation.Facade.Sellers;

public interface ISellerFacade
{
    Task<OperationResult> CreateSeller(CreateSellerCommand command);
    Task<OperationResult> EditSeller(EditSellerCommand command);

    Task<SellerDto?> GetSellerById(Guid sellerId);
    Task<SellerDto?> GetSellerByUserId(Guid userId);
    Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams);
}