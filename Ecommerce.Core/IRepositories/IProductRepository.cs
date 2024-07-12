using Ecommerce.Core.Entities;

namespace Ecommerce.Core.IRepositories
{
    public interface IProductRepository : IGenericRepository<Products>
    {
        public Task<List<Products>> GetAllProductsByCategoryId(int CategoryId);

    }
}
