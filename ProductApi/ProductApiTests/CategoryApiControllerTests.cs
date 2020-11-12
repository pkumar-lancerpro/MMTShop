using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProductApi.Data;
using ProductApiLibrary.Models;
using ProductApi.Controllers;
using System.Threading.Tasks;
using System.Linq;

namespace ProductApiTests
{
    public class CategoryApiControllerTests : IntegrationTestBase
    {
        [Test]
        public async Task Can_get_categories()
        {
            var controller = new CategoryController(null, dbContext);

            var resultCategories = await controller.Get();

            Assert.AreEqual(2, resultCategories.Count());
            var categoriesArray = resultCategories.ToArray();
            Assert.AreEqual("Cat1", categoriesArray[0].Name);
            Assert.AreEqual("Cat2", categoriesArray[1].Name);
        }
    }

}