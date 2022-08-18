using BenchmarkDotNet.Running;
using Cel.Estudos.Api.Price;
using Cel.Estudos.Benchmark.Application.Price.Handlers;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);
// Add services to the container.

var app = builder.Build();

startup.Configure(app, app.Environment);

//var summary = BenchmarkRunner.Run<CreateProductPriceCommandHandlerBenchmark>();

app.Run();