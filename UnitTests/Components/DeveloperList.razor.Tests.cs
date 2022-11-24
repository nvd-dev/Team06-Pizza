using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;
using Bunit;

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

        #region Sort Developers By Price
        /// <summary>
        /// test case for SortDevelopersByPrice function with Aescending order
        /// </summary>
        [Test]
        public void SortDevelopersByPrice_With_Aescending_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act, Rendering Component
            var page = RenderComponent<DeveloperList>();

            // Click the sorting button
            page.Find(".sort-by-price").Click();

            // Get price
            var firstPrice = page.Find(".price").TextContent;

            // Assert, Determine whether the content of the page is correct
            Assert.AreEqual("0", firstPrice);
        }
        /// <summary>
        /// test case for SortDevelopersByPrice function with Descending order
        /// </summary>
        [Test]
        public void SortDevelopersByPrice_With_Descending_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act, Rendering Component
            var page = RenderComponent<DeveloperList>();

            // Click the sorting button
            page.Find(".sort-by-price").Click();
            page.Find(".sort-by-price").Click();

            // Get price
            var firstPrice = page.Find(".price").TextContent;

            // Assert, Determine whether the content of the page is correct
            Assert.AreEqual("30", firstPrice);
        }
        #endregion Sort Developers By Price

        #region Sort Developers By Ratings
        /// <summary>
        /// test case for SortDevelopersByRatings function with Aescending order
        /// </summary>
        [Test]
        public void SortDevelopersByRatings_With_Aescending_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act, Rendering Component
            var page = RenderComponent<DeveloperList>();

            // Click the rating button
            page.Find(".sort-by-ratings").Click();

            // Get ratings
            var firstRating = page.Find(".ratings-count").TextContent;

            // Assert, Determine whether the content of the page is correct
            Assert.AreEqual("0", firstRating);
        }

        /// <summary>
        /// test case for SortDevelopersByRatings function with Descending order
        /// </summary>
        [Test]
        public void SortDevelopersByRatings_With_Descending_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act, Rendering Component
            var page = RenderComponent<DeveloperList>();

            // Click the rating button
            page.Find(".sort-by-ratings").Click();
            page.Find(".sort-by-ratings").Click();

            // Get ratings
            var firstRating = page.Find(".ratings-count").TextContent;

            // Assert, Determine whether the content of the page is correct
            Assert.AreEqual("4", firstRating);
        }
        #endregion Sort Developers By Ratings

        #region Reset Sort
        /// <summary>
        /// test case for SortDevelopersReset function
        /// </summary>
        [Test]
        public void SortDevelopersReset_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act, Rendering Component
            var page = RenderComponent<DeveloperList>();

            // Click the reset sorting button
            page.Find(".sort-reset").Click();

            // Get price
            var firstPrice = page.Find(".price").TextContent;

            // Assert, Determine whether the content of the page is correct
            Assert.AreEqual("0", firstPrice);
        }
        #endregion Reset Sort
    }

}