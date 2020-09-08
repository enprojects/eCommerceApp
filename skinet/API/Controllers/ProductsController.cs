using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.Specification;
using Core.Specification.SpecificationOperators;
using AutoMapper;
using API.Response;
using Core.Specification.Request;
using Infrastructure.Redis;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
       // private readonly IProductRepository _repos;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandReposRepo;
        private readonly IGenericRepository<ProductType> _productTypeReposRepo;
        private readonly IMapper _mapper;
        private readonly IRedisService _redis;

        public ProductsController(/*IProductRepository repos, */
                                  IGenericRepository<Product> productRepo,
                                  IGenericRepository<ProductBrand> productBrandReposRepo,
                                  IGenericRepository<ProductType> productTypeReposRepo,
                                  IMapper mapper,
                                  IRedisService redis)
        {
          //  _repos = repos;
            _productRepo = productRepo;
            _productBrandReposRepo = productBrandReposRepo;
            _productTypeReposRepo = productTypeReposRepo;
            _mapper = mapper;
            _redis = redis;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductSpecParams productParams)
        {

            // work also
            // _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductResponse>>(products)


            var products = await _productRepo.ListAsync(new ProductWithTypeAndBrandSpec(productParams));
            var total = await _productRepo.CountAsync(new ProductWithTypeAndBrandSpecCount(productParams));

            return Ok(new GenericResponse<ProductResponse> { 
            
                Data = _mapper.Map<IReadOnlyList<ProductResponse>>(products),
                Count = total,
                PageIndex = productParams.PageIndex,
                PageSize =productParams.PageSize
            });
        }


        [HttpGet("{id}")]   
        public async Task<IActionResult> GetProducts(int id)
        {
            //var query1 = new ProductWithTypeAndBrandSpec(9).AndAlso(new BrandWithTypeSpec(2));
            //var products = await _genericRepo.GetEntityExpression(query1);

            var query = new ProductWithTypeAndBrandSpec(id);
            var product = await _productRepo.GetEntityWithSpec(query);
            var result = _mapper.Map<ProductResponse>(product);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandReposRepo.ListAllAsync());
        }


         [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            return Ok(await _productTypeReposRepo.ListAllAsync());
        }

    }

}



