namespace Cel.Estudos.Domain.Price.Entity
{
    public class Product
    {
        public int IdProduct { get; set; }
        public decimal Price { get; set; }
        public decimal PriceCost { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}