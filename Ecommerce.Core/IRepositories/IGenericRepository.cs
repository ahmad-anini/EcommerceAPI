﻿namespace Ecommerce.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);
        public Task Create(T model);
        public void Update(T model);
        public void Delete(int id);
    }
}
