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
        // Page Model
        public static UpdateModel pageModel;

        /// <summary>
        /// Setup test
        /// </summary>
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

            var pageModel = new UpdateModel(TestHelper.ProductService)
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

            var pageModel = new UpdateModel(TestHelper.ProductService)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            // Act. Fill form data
            pageModel.OnGet("jenlooper-cactus");

            // Act. Call the OnPostAsync method. Submit Form
            var result = pageModel.OnPostAsync();

            // Assert. Judging whether the return is correct
            Assert.IsInstanceOf<RedirectToPageResult>(result);
        }

        #endregion OnPostAsync
    }

}