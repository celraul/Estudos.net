
using Cel.Estudos.CoreDomain.BehaviorMediatR;
using Cel.Estudos.CoreDomain.Notification;
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

            return services;
        }
    }
}