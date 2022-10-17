using Common.Application;
using Common.Query;
using Query.SiteEntities.DTOs;

namespace Query.SiteEntities.ShippingMethods.GetById;

public record GetShippingMethodByIdQuery(Guid Id) : IQuery<ShippingMethodDto?>;