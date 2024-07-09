using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using Ecommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IGenericRepository<Categories> genericRepository;

        public CategoryController(AppDbContext dbContext, IGenericRepository<Categories> genericRepository)
        {
            this.dbContext = dbContext;
            this.genericRepository = genericRepository;
        }
    }
}
