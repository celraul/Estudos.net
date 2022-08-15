using Cel.Estudos.Kafka.Configs;
using Cel.Estudos.Kafka.Interfaces;
using Cel.Estudos.Kafka.Kafka;
using Cel.Estudos.Kafka.Producers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cel.Estudos.Kafka.Ioc
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependencyInjectionKafka(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<KafkaSettings>(options => configuration.GetSection("Kafka")
                                                                      .Bind(options));

            services.AddScoped<IKafkaProducerBuilder, KafkaProducerBuilder>();
            services.AddScoped<IPricingTopicProducer, PricingTopicProducer>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
