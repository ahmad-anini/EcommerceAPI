using Ecommerce.Core.Entities;

namespace Ecommerce.Core.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Orders>
    {
        public Task<List<Orders>> GetAllOrdersByUserId(int UserId);
    }
}
