using Cel.Estudos.Domain.Price.Entity;

namespace Cel.Estudos.Domain.Price.Repositories
{
    public interface IProductPriceRepository
    {
        Task Save(ProductPrice product);
    }
}
