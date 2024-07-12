using AutoMapper;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Entities.DTO;
using Ecommerce.Core.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork<Products> unitOfWork;
        private readonly IMapper mapper;
        public ApiResponse response;

        public ProductController(IUnitOfWork<Products> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
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
                var mappedProduct = mapper.Map<List<Products>, List<ProductDTO>>(products);
                response.Result = mappedProduct;
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
        public async Task<ActionResult> CreateProduct(CreateProductDTO productDTO)
        {
            var product = mapper.Map<CreateProductDTO, Products>(productDTO);
            await unitOfWork.ProductRepository.Create(product);
            await unitOfWork.Save();
            return Ok(productDTO);
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

        [HttpGet("ProductsByCategory/{CategoryId}")]
        public async Task<ActionResult<ApiResponse>> GetAllByCategoryId(int CategoryId)
        {
            var products = await unitOfWork.ProductRepository.GetAllProductsByCategoryId(CategoryId);
            var mappedProducts = mapper.Map<List<Products>, List<ProductDTO>>(products);
            return Ok(mappedProducts);
        }
    }
}
