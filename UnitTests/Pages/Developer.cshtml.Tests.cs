using System.Linq;

using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Developer
{

    /// <summary>
    /// UnitTests for Developer
    /// </summary>
    public class DeveloperTests
    {
        #region TestSetup
        // Page Model
        public static DeveloperModel pageModel;

        /// <summary>
        /// Setup test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<DeveloperModel>>();

            pageModel = new DeveloperModel(TestHelper.ProductService)
            {
            };

        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// test case for OnGet method
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Act. Call the OnGet method with valid id
            pageModel.OnGet();

            // Assert. Determine whether the page data is correct
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }

        #endregion OnGet
    }

}