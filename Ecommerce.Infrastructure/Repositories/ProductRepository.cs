using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        private readonly AppDbContext dbContext;



        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Products>> GetAllProductsByCategoryId(int CategoryId)
        {
            var products = await dbContext.Products.Include(x => x.Category)
                .Where(c => c.CategoryId == CategoryId)
                .ToListAsync();
            return products;
        }
    }
}
