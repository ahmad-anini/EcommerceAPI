using Ecommerce.Core.IRepositories;
using Ecommerce.Infrastructure.Data;

namespace Ecommerce.Infrastructure.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            ProductRepository = new ProductRepository(dbContext);
            CategoryRepository = new CategoryRepository(dbContext);
            OrderRepository = new OrderRepository(dbContext);
        }
        public IProductRepository ProductRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public async Task<int> Save() => await dbContext.SaveChangesAsync();
    }


}
