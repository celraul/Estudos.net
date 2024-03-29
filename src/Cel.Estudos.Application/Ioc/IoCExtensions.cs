﻿using Cel.Estudos.Application.Core.Services;
using Cel.Estudos.Application.Price.Commands;
using Cel.Estudos.Application.Price.Validators;
using Cel.Estudos.CoreDomain.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cel.Estudos.Application.Ioc
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICorrelationIdService, CorrelationIdService>();

            services.AddPriceDependencyInjection();
            services.AddDiscountDependencyInjection();

            return services;
        }

        public static IServiceCollection AddPriceDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateProductPriceCommand>, CreateProductPriceCommandValidators>();

            return services;
        }

        public static IServiceCollection AddDiscountDependencyInjection(this IServiceCollection services)
        {
            return services;
        }
    }
}
