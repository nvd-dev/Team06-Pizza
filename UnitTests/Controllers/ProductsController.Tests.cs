using NUnit.Framework;
using ContosoCrafts.WebSite.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Controllers
{

    /// <summary>
    /// UnitTests for ProductsController
    /// </summary>
    public class ProductsControllerTests
    {
        #region TestSetup

        public static ProductsController controller;

        [SetUp]
        public void TestInitialize()
        {
            controller = new ProductsController(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        #region Get
        [Test]
        public void Get_Valid_Should_Return_Products()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            var result = controller.Get();

            // Assert
            Assert.AreEqual(data.Id, result.First().Id);
        }
        #endregion Get

        #region Patch
        [Test]
        public void Patch_Valid_Should_Return_Ok()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData().First();
            var request = new ProductsController.RatingRequest()
            {
                ProductId = data.Id,
                Rating=3
            };

            // Act
            var result = controller.Patch(request);
            var dataNew = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(3, dataNew.Ratings[^1]);
            Assert.IsInstanceOf<OkResult>(result);
        }
        #endregion Patch
    }

}