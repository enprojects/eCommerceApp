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

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repos;
        private readonly IGenericRepository<Product> _genericRepo;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repos, IGenericRepository<Product> generic,IMapper mapper)
        {
            _repos = repos;
            _genericRepo = generic;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            // work also
           // _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductResponse>>(products)

            var products = await _genericRepo.ListAsync(new ProductWithTypeAndBrandSpec(productParams));
         
            var total = await _genericRepo.CountAsync(new ProductWithTypeAndBrandSpecCount(productParams));

            return Ok(new GenericResponse<ProductResponse> { 
            
                Data = _mapper.Map<IReadOnlyList<ProductResponse>>(products),
                Count = total,
                PageNumber = productParams.PageIndex,
                PageSize =productParams.PageSize
            });
        }


        [HttpGet("{id}")]   
        public async Task<IActionResult> GetProducts(int id)
        {
            //var query1 = new ProductWithTypeAndBrandSpec(9).AndAlso(new BrandWithTypeSpec(2));
            //var products = await _genericRepo.GetEntityExpression(query1);

            var query = new ProductWithTypeAndBrandSpec(id);
            var product = await _genericRepo.GetEntityWithSpec(query);
            var result = _mapper.Map<ProductResponse>(product);

            return Ok(result);

        }         
    }

}



