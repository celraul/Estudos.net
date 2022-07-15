using Cel.Estudos.Domain.Price.Entity;
using Cel.Estudos.Domain.Price.Repositories;
using Cel.Estudos.Infra.Data.Data;
using Cel.Estudos.Infra.Data.Repositories;

namespace Cel.Estudos.Infra.DataWrite.Price.Repositories
{
    public class PriceRepository : BaseRepository, IPriceRepository
    {
        public PriceRepository(DbSession session) : base(session)
        {
        }

        public async Task Save(Product product)
        {
            var command = @"INSERT INTO [Product] VALUES(@Price, @PriceCost  GETDATE(), GETDATE());";

            await ExecuteAsync(command, product, System.Data.CommandType.Text);
        }
    }
}
