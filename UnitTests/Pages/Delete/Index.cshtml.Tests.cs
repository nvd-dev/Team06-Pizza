using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitTests.Pages.Create
{

    /// <summary>
    /// UnitTests for Create
    /// </summary>
    public class DeleteTests
    {
        #region TestSetup
        // Page Model
        public static DeleteModel pageModel;

        /// <summary>
        /// Setup test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<DeleteModel>>();

            pageModel = new DeleteModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// test case for OnGet method with Null Id
        /// </summary>
        [Test]
        public void OnGet_InValid_Id_Null_Should_Return_ARedirectToPageResult()
        {
            // Act. Call the OnGet method
            var result = pageModel.OnGet(null);

            // Assert. Judging whether the return is correct
            Assert.IsInstanceOf<RedirectToPageResult>(result);
        }

        /// <summary>
        /// test case for OnGet method with invalid Id
        /// </summary>
        [Test]
        public void OnGet_InValid_Id_Should_Return_ARedirectToPageResult()
        {
            // Act. Call the OnGet method
            var result = pageModel.OnGet("test");

            // Assert. Judging whether the return is correct
            Assert.IsInstanceOf<RedirectToPageResult>(result);
        }

        /// <summary>
        /// test case for OnGet method with valid Id
        /// </summary>
        [Test]
        public void OnGet_Valid_Id_Should_Return_APageResult()
        {
            // Act. Call the OnGet method
            var result = pageModel.OnGet("jenlooper-light");

            // Assert. Judging whether the return is correct
            Assert.IsInstanceOf<PageResult>(result);
        }
        #endregion OnGet

        #region OnPostAsync
        /// <summary>
        /// test case for OnPostAsync method
        /// </summary>
        [Test]
        public void OnPostAsync_Should_Return_RedirectToPageResult()
        {
            // Act. Get the data to delete
            pageModel.OnGet("jenlooper-light");

            // Call the OnPostAsync method, delete data
            var result = pageModel.OnPostAsync();

            // Assert. Judging whether the return is correct
            Assert.IsInstanceOf<RedirectToPageResult>(result);
        }
        #endregion OnPostAsync
    }

}