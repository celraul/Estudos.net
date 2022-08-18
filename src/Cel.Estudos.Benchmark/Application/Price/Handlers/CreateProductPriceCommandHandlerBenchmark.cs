using BenchmarkDotNet.Attributes;
using Cel.Estudos.Application.Price.Commands;
using Cel.Estudos.Application.Price.Handlers;
using Cel.Estudos.Domain.Price.Specifications.CreateProductPrice;

namespace Cel.Estudos.Benchmark.Application.Price.Handlers
{
    [MemoryDiagnoser]
    [RankColumn]
    public class CreateProductPriceCommandHandlerBenchmark
    {
        public CreateProductPriceCommandHandlerBenchmark()
        {

        }

        [Benchmark]
        public async Task Handle()
        {
            //var x = await new CreateProductPriceCommandHandler(null, null, null, null, null, null)
            //    .Handle(new CreateProductPriceCommand(), CancellationToken.None);
            var q = new CreateProductPriceSpecification();
        }
    }
}