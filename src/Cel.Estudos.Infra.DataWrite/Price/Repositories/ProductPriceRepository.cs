using Cel.Estudos.Domain.Price.Entity;
using Cel.Estudos.Domain.Price.Repositories;
using Cel.Estudos.Infra.Data.Data;
using Cel.Estudos.Infra.Data.Repositories;

namespace Cel.Estudos.Infra.DataWrite.Price.Repositories
{
    public class ProductPriceRepository : BaseRepository, IProductPriceRepository
    {
        public ProductPriceRepository(DbSession session) : base(session)
        {
        }

        public async Task Save(ProductPrice product)
        {
            var command = @"INSERT INTO Estudos.dbo.ProductPrice
                            (IdProduct, Price, PriceCost, CreateDate, UpdateDate)
                            VALUES(@IdProduct, @Price, @PriceCost, SYSDATETIME() , SYSDATETIME() );";

            await ExecuteAsync(command, product, System.Data.CommandType.Text);
        }
    }
}
