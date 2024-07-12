using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Create(T model)
        {
            await dbContext.Set<T>().AddAsync(model);
        }

        public void Delete(int id)
        {
            dbContext.Remove(id);
        }

        public async Task<List<T>> GetAll()
        {
            if (typeof(T) == typeof(Products))
            {
                var products = await dbContext.Products.Include(x => x.Category).ToListAsync();
                return products as List<T>;
            }
            if (typeof(T) == typeof(Orders))
            {
                var orders = await dbContext.Orders.Include(x => x.LocalUser).ToListAsync();
                return orders as List<T>;
            }
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T model)
        {
            dbContext.Set<T>().Update(model);
        }
    }
}
