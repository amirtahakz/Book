using Application.SiteEntities.ShippingMethod.Create;
using Application.SiteEntities.ShippingMethod.Edit;
using Common.Application;
using Query.SiteEntities.DTOs;

namespace Presentation.Facade.SiteEntities.ShippingMethods;

public interface IShippingMethodFacade
{
    Task<OperationResult> Create(CreateShippingMethodCommand command);
    Task<OperationResult> Edit(EditShippingMethodCommand command);
    Task<OperationResult> Delete(Guid id);


    Task<ShippingMethodDto?> GetShippingMethodById(Guid id);
    Task<List<ShippingMethodDto>> GetList();
}