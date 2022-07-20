using Cel.Estudos.Domain.Price.Repositories;
using Cel.Estudos.Infra.DataWrite.Price.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cel.Estudos.Infra.DataWrite.Ioc
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddInfraDataWriteDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IProductPriceRepository, ProductPriceRepository>();

            return services;
        }
    }
}
