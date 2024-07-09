using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork<Products> unitOfWork;
        public ApiResponse response;

        public ProductController(IUnitOfWork<Products> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            response = new ApiResponse();
        }


        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            var products = await unitOfWork.ProductRepository.GetAll();
            var check = products.Any();
            if (check)
            {
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.IsSuccess = check;
                response.Result = products;
            }
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.IsSuccess = check;
                response.ErrorMessage = "no product found";

            }
            return response;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetById(int id)
        {
            var product = await unitOfWork.ProductRepository.GetById(id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> CreateProduct(Products model)
        {
            unitOfWork.ProductRepository.Create(model);
            await unitOfWork.Save();
            return Ok(model);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateProduct(Products model)
        {
            unitOfWork.ProductRepository.Update(model);
            await unitOfWork.Save();
            return Ok(model);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            unitOfWork.ProductRepository.Delete(id);
            await unitOfWork.Save();
            return Ok();
        }
    }
}
