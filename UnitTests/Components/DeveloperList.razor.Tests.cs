using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Components
{
    /// <summary>
    /// UnitTests for DeveloperList Component
    /// </summary>
    public class DeveloperListTests : BunitTestContext
    {
        #region TestSetup
        /// <summary>
        /// Setup test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region DefaultContent
        /// <summary>
        /// test case for Rendering DeveloperList page
        /// </summary>
        [Test]
        public void DeveloperList_Default_Should_Return_Content()
        {

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act, Rendering Component
            var page = RenderComponent<DeveloperList>();

            // Get the Page Content
            var result = page.Markup;

            // Assert, Determine whether the content of the page is correct
            Assert.AreEqual(true, result.Contains("Hiring a Python Developer"));
        }
        #endregion DefaultContent
    }

}