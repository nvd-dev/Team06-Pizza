using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace UnitTests.Pages.Create
{

    /// <summary>
    /// UnitTests for Create
    /// </summary>
    public class CreateTests
    {
        #region TestSetup

        public static CreateModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<CreateModel>>();

            pageModel = new CreateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Create_Product()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreNotEqual(null, pageModel.Product.Id);
        }
        #endregion OnGet

        #region OnPostAsync
        [Test]
        public void OnPostAsync_ModelStateIsInvalid_Should_Return_PageResult()
        {
            // Arrange
            var modelState = new ModelStateDictionary();
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var pageModel = new CreateModel(TestHelper.ProductService)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };
            pageModel.ModelState.AddModelError("Product.Price", "Value for Price must be between -1 and 100.");

            // Act
            var result = pageModel.OnPostAsync();

            // Assert
            Assert.IsInstanceOf<PageResult>(result);
        }

        [Test]
        public void OnPostAsync_ModelStateIsValid_Should_Return_RedirectToPageResult()
        {
            // Arrange
            var modelState = new ModelStateDictionary();
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var pageModel = new CreateModel(TestHelper.ProductService)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            // Act
            pageModel.OnGet();
            var result = pageModel.OnPostAsync();

            // Assert
            Assert.IsInstanceOf<RedirectToPageResult>(result);
        }
        #endregion OnPostAsync
    }

}