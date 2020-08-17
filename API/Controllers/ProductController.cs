using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<Product> _productTypeRepo;
        private readonly IGenericRepository<Product> _productBrandRepo;
       private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<Product> productTypeRepo, IGenericRepository<Product> productBrandRepo,IMapper mapper) 
        {
            _productBrandRepo = productBrandRepo;
           _mapper = mapper;
            _productTypeRepo = productTypeRepo;
            _productRepo = productRepo;

        }

        [HttpGet]   
        public async Task<ActionResult<Pagniation<ProductToReturnDto>>> GetProducts( 
          [FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductWithFiltersForCountSpecification(productParams);
            var totalItems = await _productRepo.CountAsync(countSpec);
            var products = await _productRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            return Ok(new Pagniation<ProductToReturnDto>( productParams.PageIndex, productParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {

            var spec = new ProductWithTypesAndBrandsSpecification(id);

            var product = await _productRepo.GetEntityWithSpec(spec);

            if (product == null) return NotFound(new ApiResponse(404));
            return  _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}