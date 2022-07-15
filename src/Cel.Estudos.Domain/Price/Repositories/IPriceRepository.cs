using Cel.Estudos.Domain.Price.Entity;

namespace Cel.Estudos.Domain.Price.Repositories
{
    public interface IPriceRepository
    {
        Task Save(Product product);
    }
}
