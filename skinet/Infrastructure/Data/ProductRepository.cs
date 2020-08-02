using API.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Infrastructure.Data
{
    //Not in use
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context )
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
           return await   _context.Products
                .Include(x => x.ProductBrand)
                .Include(x => x.ProductBrand)
                .ToListAsync();
        }

         
        public async Task<Product> GetProductsByIdAsync(int id)
        {
            var query = await _context.Products.Include(x => x.ProductType)
                                .FirstOrDefaultAsync(x => x.Id == id);
            return query;
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandsAsync()
        {
            var query = _context.ProductBrands; 
            return await query.ToListAsync();
        }
        public async Task<IReadOnlyList<ProductType>> GetProductsTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

    }
}

