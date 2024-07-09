namespace Ecommerce.Core.IRepositories
{
    public interface IUnitOfWork<T> where T : class
    {
        public IProductRepository ProductRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public Task<int> Save();
    }
}
