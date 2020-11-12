using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductApi.Data;
using ProductApiLibrary.Models;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly MMTShopContext _context;

        public CategoryController(ILogger<ProductController> logger, MMTShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }
    }
}
