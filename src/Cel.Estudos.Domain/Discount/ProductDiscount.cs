namespace Cel.Estudos.Domain.Desconto
{
    public class ProductDiscount
    {
        public int ProductDiscountId { get; set; }
        public int ProductId { get; set; }
        public int Percent { get; set; }
    }
}