using Cel.Estudos.Api.Price.ActionFilters;

namespace Cel.Estudos.Api.Price.Extensions
{
    public static class IServiceCollectionFiltersExtensions
    {
        public static IServiceCollection ConfigureFilters(this IServiceCollection services)
        {

            services.AddScoped<CorrelationIdActionFilter>();

            return services;
        }
    }
}
