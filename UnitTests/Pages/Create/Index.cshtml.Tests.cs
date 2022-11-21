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
        // Page Model
        public static CreateModel pageModel;

        /// <summary>
        /// Setup test
        /// </summary>
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
        /// <summary>
        /// test case for OnGet methon in Create Page
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Create_Product()
        {
            // Act. Call the OnGet method
            pageModel.OnGet();

            // Assert
            Assert.AreNotEqual(null, pageModel.Product.Id);
        }
        #endregion OnGet

        #region OnPostAsync
        /// <summary>
        /// test case for OnPostAsync method with invalid input
        /// </summary>
        [Test]
        public void OnPostAsync_ModelStateIsInvalid_Should_Return_PageResult()
        {
            // Arrange. Create submitted form
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

            // Set invalid input
            pageModel.ModelState.AddModelError("Product.Price", "Value for Price must be between -1 and 100.");

            // Act. Call the OnPostAsync method. Submit Form
            var result = pageModel.OnPostAsync();

            // Assert. Judging whether the return is correct
            Assert.IsInstanceOf<PageResult>(result);
        }

        /// <summary>
        /// test case for OnPostAsync method with valid input
        /// </summary>
        [Test]
        public void OnPostAsync_ModelStateIsValid_Should_Return_RedirectToPageResult()
        {
            // Arrange. Create submitted form
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

            // Act. Fill form data
            pageModel.OnGet();

            // Act. Call the OnPostAsync method. Submit Form
            var result = pageModel.OnPostAsync();

            // Assert. Judging whether the return is correct
            Assert.IsInstanceOf<RedirectToPageResult>(result);
        }
        #endregion OnPostAsync
    }

}