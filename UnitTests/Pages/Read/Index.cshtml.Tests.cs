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
        // Page Model
        public static ReadModel pageModel;

        /// <summary>
        /// Setup test
        /// </summary>
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
        /// <summary>
        /// test case for OnGet method with valid Id
        /// </summary>
        [Test]
        public void OnGet_Valid_Id_Should_Return_Products()
        {
            // Act. Call the OnGet method with valid id
            pageModel.OnGet("jenlooper-cactus");

            // Assert. Determine whether the page data is correct
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("jenlooper-cactus", pageModel.Product.Id);
        }

        /// <summary>
        /// test case for OnGet method with invalid Id
        /// </summary>
        [Test]
        public void OnGet_InValid_Id_Should_Return_ARedirectToPageResult()
        {
            // Act. Call the OnGet method with invalid id
            var result = pageModel.OnGet("test");

            // Assert. Judging whether the return is correct
            Assert.IsInstanceOf<RedirectToPageResult>(result);
        }
        #endregion OnGet

    }

}