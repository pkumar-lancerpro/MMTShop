using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NUnit.Framework;
using ProductApi.Data;
using ProductApiLibrary.Models;
using System.Threading.Tasks;

namespace ProductApiTests
{
    [SetUpFixture]
    public class IntegrationSetUp
    {
        [OneTimeSetUp]
        public async Task SetUp()
        {
            var dbContextFactory = new MMTDbContextFactory();
            using (var dbContext = dbContextFactory.CreateDbContext(new string[] { }))
            {
                await dbContext.Database.EnsureDeletedAsync();
                await dbContext.Database.EnsureCreatedAsync();
            }
        }

        [SetUp]
        void RunBeforeAnyTests()
        { }

        [TearDown]
        void RunAfterAnyTests()
        { }
    }

    public abstract class IntegrationTestBase
    {
        protected MMTShopContext dbContext = null!;

        [SetUp]
        public void SetUp()
        {
            var dbContextFactory = new MMTDbContextFactory();
            dbContext = dbContextFactory.CreateDbContext(new string[] { });
        }

        [TearDown]
        public void TearDown()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }

    public class MMTDbContextFactory : IDesignTimeDbContextFactory<MMTShopContext>
    {
        public MMTShopContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MMTShopContext>();
            optionsBuilder.UseSqlServer(
              "Server=localhost\\SQLExpress;Database=MMTShop_TestDB;Trusted_Connection=True;");

            // TODO - This is failing for now.. Unable to do Integration testing..
            return new MMTShopContext(optionsBuilder.Options);
        }
    }
}