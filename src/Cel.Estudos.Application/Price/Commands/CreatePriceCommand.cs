using Cel.Estudos.CoreDomain.Command;

namespace Cel.Estudos.Application.Price.Commands
{
    public class CreatePriceCommand : Command<bool>
    {
        public int IdProduct { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceCost { get; set; }
    }
}
