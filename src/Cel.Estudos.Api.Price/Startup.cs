using Cel.Estudos.Application.Ioc;
using Cel.Estudos.Application.Price.Handlers;
using Cel.Estudos.Infra.DataWrite.Ioc;
using Cel.Estudos.CoreDomain.IoC;
using Cel.Estudos.Infra.Data.Ioc;
using MediatR;
using Cel.Estudos.Api.Price.Middlewares;
using Cel.Estudos.Api.Price.Extensions;

namespace Cel.Estudos.Api.Price
{
    public class Startup
    {
        public IConfiguration _configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMediatR(typeof(CreateProductPriceCommandHandler).Assembly);

            services.ConfigureFilters();

            services.AddInfraDataDependencyInjection()
                    .AddInfraDataWriteDependencyInjection()
                    .AddApplicationDependencyInjection()
                    .AddDomainDependencyInjection();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
