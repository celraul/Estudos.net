
using Cel.Estudos.CoreDomain.BehaviorMediatR;
using Cel.Estudos.CoreDomain.Notification;
using Cel.Estudos.CoreDomain.Specification;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Cel.Estudos.CoreDomain.IoC
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddDomainDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<INotificationContext, NotificationContext>();

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationRequestBehavior<,>));
            services.AddTransient(typeof(ISpecificator<>), typeof(Specificator<>));

            return services;
        }
    }
}