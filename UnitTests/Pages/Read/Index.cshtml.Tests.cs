using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Read;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Read
{

    /// <summary>
    /// UnitTests for Read
    /// </summary>
    public class ReadTests
    {
        #region TestSetup

        public static ReadModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<ReadModel>>();

            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };

        }

        #endregion TestSetup

        #region OnGet


        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {

            // Arrange

            // Act
            pageModel.OnGet("jenlooper-cactus");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("jenlooper-cactus", pageModel.Product.Id);
        }

        [Test]
        public void OnGet_InValid_Id_Should_Return_ARedirectToPageResult()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("test");

            // Assert
            Assert.IsInstanceOf<RedirectToPageResult>(result);
        }
        #endregion OnGet

    }

}