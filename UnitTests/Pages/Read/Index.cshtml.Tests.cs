using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Read;

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
        #endregion OnGet
    }
}