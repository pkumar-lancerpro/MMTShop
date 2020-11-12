using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly MMTShopContext _context;

        public ProductController(ILogger<ProductController> logger, MMTShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("featured")]
        public async Task<IEnumerable<Product>> GetFeaturedProducts()
        {
            var products = await _context.Products.FromSqlRaw("sp_GetFeaturedProducts").ToListAsync(); // _context.Products.ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("bycategory/{categoryId}")]
        public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            var products = await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
            return products;
        }
    }
}
