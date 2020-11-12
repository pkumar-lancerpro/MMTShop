using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProductApi.Data;
using ProductApiLibrary.Models;
using ProductApi.Controllers;
using System.Threading.Tasks;
using System.Linq;

namespace ProductApiTests
{
    public class ProductApiControllerTests : IntegrationTestBase
    {
        [Test]
        public async Task Can_get_featured_products()
        {
            var controller = new ProductController(null, dbContext);

            var resultFeaturedProducts = await controller.GetFeaturedProducts();

            Assert.AreEqual(2, resultFeaturedProducts.Count());
            var featuredProductsArray = resultFeaturedProducts.ToArray();
            Assert.AreEqual("ProdThree", featuredProductsArray[0].Name);
            Assert.AreEqual("ProdFour", featuredProductsArray[1].Name);
        }
    }
}