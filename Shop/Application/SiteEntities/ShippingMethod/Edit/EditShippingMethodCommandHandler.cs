﻿using Common.Application;
using Domain.SiteEntities.Repositories;

namespace Application.SiteEntities.ShippingMethod.Edit
{
    public class EditShippingMethodCommandHandler : IBaseCommandHandler<EditShippingMethodCommand>
    {
        private readonly IShippingMethodRepository _repository;

        public EditShippingMethodCommandHandler(IShippingMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditShippingMethodCommand request, CancellationToken cancellationToken)
        {
            var shipping = await _repository.GetTracking(request.Id);

            if (shipping == null)
                return OperationResult.NotFound();


            shipping.Edit(request.Cost, request.Title);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
