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

namespace UnitTests.Pages.Update
{

    /// <summary>
    /// UnitTests for Update
    /// </summary>
    public class UpdateTests
    {
        #region TestSetup

        public static UpdateModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<UpdateModel>>();

            pageModel = new UpdateModel(TestHelper.ProductService)
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

        #region OnPostAsync
        [Test]
        public void OnPostAsync_ModelStateIsInvalid_Should_Return_APageResult()
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

            var pageModel = new UpdateModel(TestHelper.ProductService)
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
        public void OnPostAsync_ModelStateIsValid_Should_Return_ARedirectToPageResult()
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

            var pageModel = new UpdateModel(TestHelper.ProductService)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            // Act
            pageModel.OnGet("jenlooper-cactus");
            var result = pageModel.OnPostAsync();

            // Assert
            Assert.IsInstanceOf<RedirectToPageResult>(result);
        }

        #endregion OnPostAsync
    }

}