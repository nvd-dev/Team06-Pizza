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

        public static DeleteModel pageModel;

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
        [Test]
        public void OnGet_InValid_Id_Null_Should_Return_ARedirectToPageResult()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet(null);

            // Assert
            Assert.IsInstanceOf<RedirectToPageResult>(result);
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

        [Test]
        public void OnGet_Valid_Id_Should_Return_APageResult()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("jenlooper-light");

            // Assert
            Assert.IsInstanceOf<PageResult>(result);
        }
        #endregion OnGet

        #region OnPostAsync
        [Test]
        public void OnPostAsync_Should_Return_RedirectToPageResult()
        {
            // Arrange

            // Act
            pageModel.OnGet("jenlooper-light");
            var result = pageModel.OnPostAsync();

            // Assert
            Assert.IsInstanceOf<RedirectToPageResult>(result);
        }
        #endregion OnPostAsync
    }

}