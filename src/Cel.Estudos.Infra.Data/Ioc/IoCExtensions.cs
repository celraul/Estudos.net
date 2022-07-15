using Cel.Estudos.Infra.Data.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Cel.Estudos.Infra.Data.Ioc
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddInfraDataDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<DbSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}