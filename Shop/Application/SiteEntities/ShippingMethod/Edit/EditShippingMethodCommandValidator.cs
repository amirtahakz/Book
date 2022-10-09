﻿using FluentValidation;

namespace Application.SiteEntities.ShippingMethod.Edit
{
    public class EditShippingMethodCommandValidator : AbstractValidator<EditShippingMethodCommand>
    {
        public EditShippingMethodCommandValidator()
        {
            RuleFor(f => f.Title)
                .NotNull().NotEmpty();
        }
    }
}
