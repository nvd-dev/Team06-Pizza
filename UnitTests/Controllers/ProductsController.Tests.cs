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
        // controller
        public static ProductsController controller;

        /// <summary>
        /// Setup test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            controller = new ProductsController(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        #region Get
        /// <summary>
        /// UnitTest for Get method
        /// </summary>
        [Test]
        public void Get_Valid_Should_Return_Products()
        {
            // Arrange. Get the first data
            var data = TestHelper.ProductService.GetAllData().First();

            // Act. Call Get method
            var result = controller.Get();

            // Assert. Judging whether the data is correct
            Assert.AreEqual(data.Id, result.First().Id);
        }
        #endregion Get

        #region Patch
        /// <summary>
        /// UnitTest for Patch method
        /// </summary>
        [Test]
        public void Patch_Valid_Should_Return_Ok()
        {
            // Arrange. Get the first data
            var data = TestHelper.ProductService.GetAllData().First();
            // Set rating
            var request = new ProductsController.RatingRequest()
            {
                ProductId = data.Id,
                Rating=3
            };

            // Act. Call Patch method
            var result = controller.Patch(request);

            // Get updated data
            var dataNew = TestHelper.ProductService.GetAllData().First();

            // Assert. Determine whether the update was successful
            Assert.AreEqual(3, dataNew.Ratings[^1]);
            Assert.IsInstanceOf<OkResult>(result);
        }
        #endregion Patch
    }

}