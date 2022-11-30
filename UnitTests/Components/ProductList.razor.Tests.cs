using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;
using Bunit;
using AngleSharp.Dom;
using System.Linq;

namespace UnitTests.Components
{
    /// <summary>
    /// UnitTests for ProductList Component
    /// </summary>
    public class ProductListTests : BunitTestContext
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
        /// test case for Rendering Home page
        /// </summary>
        [Test]
        public void ProductList_Default_Should_Return_Content()
        {

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act, Rendering Component
            var page = RenderComponent<ProductList>();

            // Get the Page Content
            var result = page.Markup;

            // Assert, Determine whether the content of the page is correct
            Assert.AreEqual(true, result.Contains("Hiring a Python Developer"));
        }
        #endregion DefaultContent

        #region SearchProducts
        /// <summary>
        /// test case for Search function, Click the button
        /// </summary>
        [Test]
        public void Product_Search_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act. Rendering Component
            var page = RenderComponent<ProductList>();

            // Set search keywords
            page.Find(".form-control").NodeValue = "Python";

            // Click the search button
            page.Find(".search-action").Click();
            page.Find(".jenlooper-cactus").Click();

            // Get the Search results
            var result = page.Markup;

            // Assert. Determine whether the search result is correct
            Assert.AreEqual(true, result.Contains("Hiring a Python Developer"));
        }

        /// <summary>
        /// test case for Search function, hit enter
        /// </summary>
        [Test]
        public void Product_Search_Press_Enter_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act. Rendering Component
            var page = RenderComponent<ProductList>();

            // Set search keywords
            page.Find(".form-control").NodeValue = "Python";

            // Hit enter on the keyboard
            page.Find(".form-control").KeyPress(key: "", code: "Enter");

            // Get the Search results
            var result = page.Markup;

            // Assert. Determine whether the search result is correct
            Assert.AreEqual(true, result.Contains("Hiring a Python Developer"));
        }
        #endregion SearchProducts

        #region ResetSearchProducts
        /// <summary>
        /// test case for ResetSearchProducts function, Click the button
        /// </summary>
        [Test]
        public void Product_Search_Reset_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act. Rendering Component
            var page = RenderComponent<ProductList>();

            // Click the search button
            page.Find(".seach-clear").Click();

            // Get the Search results
            var result = page.Markup;

            // Assert. Determine whether the search result is correct
            Assert.AreEqual(true, result.Contains("Hiring a Python Developer"));
        }
        #endregion ResetSearchProducts

        #region SelectProduct
        /// <summary>
        /// Test case for popup rendering. Products with Null ratings
        /// </summary>
        [Test]
        public void SelectProduct_Ratings_Null_Should_Return_Product()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act. Rendering Component
            var page = RenderComponent<ProductList>();

            // Click the 'More Info' button
            page.Find(".selinazawacki-shirt").Click();

            // Get popup content
            var result = page.Markup;

            // Assert. Determine whether the content of the pop-up window is correct
            Assert.AreEqual(true, result.Contains("Be the first to vote!"));
        }

        /// <summary>
        /// Test case for popup rendering. Products with ratings Larger Than 1
        /// </summary>
        [Test]
        public void SelectProduct_Ratings_Valid_VoteCount_Larger_Than_1_Should_Return_Product()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act. Rendering Component
            var page = RenderComponent<ProductList>();

            // Click the 'More Info' button
            page.Find(".jenlooper-cactus").Click();

            // Get popup content
            var result = page.Markup;

            // Assert. Determine whether the content of the pop-up window is correct
            Assert.AreEqual("Hiring a Python Developer", page.Find("#productTitle").Text());
            // Assert. Determine whether the label of the rating is correct
            Assert.AreEqual(true, result.Contains("Votes"));
        }
        #endregion SelectProduct

        #region SubmitRating
        /// <summary>
        /// Test case for Submit Rating. The selected rating is smaller than the current rating
        /// </summary>
        [Test]
        public void SubmitRating_Ratings_Smaller_Than_CurrentRating_Should_Return_New_Rating()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act. Rendering Component
            var page = RenderComponent<ProductList>();

            // Click the 'More Info' button
            page.Find(".jenlooper-cactus").Click();

            // Click to rate
            page.Find(".modal-footer .fa-star").Click();

            // Get rated data
            var data = TestHelper.ProductService.GetAllData().First();

            // Assert. Judging whether the rating is correct
            Assert.AreEqual(1, data.Ratings.Last());
        }

        /// <summary>
        /// Test case for Submit Rating. The selected rating is larger than the current rating
        /// </summary>
        [Test]
        public void SubmitRating_Ratings_Larger_Than_CurrentRating_Should_Return_New_Rating()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act. Rendering Component
            var page = RenderComponent<ProductList>();

            // Click the 'More Info' button
            page.Find(".selinazawacki-shirt").Click();

            // Click to rate
            page.Find(".modal-footer .fa-star:last-child").Click();

            // Get rated data
            var data = TestHelper.ProductService.GetAllData().Last();

            // Assert. Judging whether the rating is correct
            Assert.AreEqual(5, data.Ratings.Last());
        }
        #endregion SubmitRating
    }

}