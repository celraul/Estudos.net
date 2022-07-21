using Cel.Estudos.CoreDomain.Command;
using System.Diagnostics.CodeAnalysis;

namespace Cel.Estudos.Application.Price.Commands
{
    public class CreateProductPriceCommand : Command<bool>
    {
        public int IdProduct { get; set; }
        [NotNull] public decimal? Price { get; set; }
        [NotNull] public decimal? PriceCost { get; set; }
    }
}
