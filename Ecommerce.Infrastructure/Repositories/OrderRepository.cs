using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Orders>, IOrderRepository
    {
        private readonly AppDbContext dbContext;

        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Orders>> GetAllOrdersByUserId(int UserId)
        {
            var orders = await dbContext.Orders.Include(x => x.LocalUser)
                .Where(u => u.LocalUserId == UserId)
                .ToListAsync();
            return orders;
        }
    }
}
