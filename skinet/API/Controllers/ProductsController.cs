using System.Threading.Tasks;
using API.Data;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repos;

        public ProductsController(IProductRepository repos)
        {
            _repos = repos;
        }

        [HttpGet("get-products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repos.GetProductsAsync();
            return Ok(products);
        }


        [HttpGet("get-product/{id}" )]   
        public async Task<IActionResult> GetProducts(int id)
        {
            var products = await _repos.GetProductsByIdAsync(id);
            return Ok(products);
        }

    }
}
