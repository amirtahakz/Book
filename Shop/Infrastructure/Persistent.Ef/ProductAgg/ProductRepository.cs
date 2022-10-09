using Domain.ProductAgg;
using Domain.ProductAgg.Repository;
using Infrastructure.Persistent.Ef;
using Infrastructure._Utilities;

namespace Infrastructure.Persistent.Ef.ProductAgg;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}