﻿using Cel.Estudos.Application.Price.Commands;
using FluentValidation;

namespace Cel.Estudos.Application.Price.Validators
{
    public class CreatePriceCommandValidators : AbstractValidator<CreatePriceCommand>
    {
        public CreatePriceCommandValidators()
        {
            RuleFor(x => x.Price).NotEmpty()
                                 .GreaterThan(decimal.MinValue)
                                 .WithMessage("Error 01");
            RuleFor(x => x.IdProduct).GreaterThan(int.MinValue).WithMessage("Error 02");
        }
    }
}