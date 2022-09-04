using API.Dtos;
using AutoMapper;
using Core.DbModels;
using Core.Interfaces;
using Core.Spesifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            if (products != null)
            {
                return Ok(products);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var spec = new ProductWithProductTypeAndBrandSpecifition(id);
            var products = await _productRepository.GetEntityWithSpec(spec);
            return Ok(_mapper.Map<Product, ProductToReturnDto>(products));
        }
        [HttpGet("GetAllBrand")]
        public async Task<IActionResult> GetAllBrand()
        {
            var spec = new ProductWithProductTypeAndBrandSpecifition();
            var data = await _productRepository.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(data));
           
        }

    }
}
