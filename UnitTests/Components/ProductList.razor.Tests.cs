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

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region DefaultContent
        [Test]
        public void ProductList_Default_Should_Return_Content()
        {

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Hiring a Python Developer"));
        }
        #endregion DefaultContent

        #region SearchProducts
        [Test]
        public void Product_Search_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();
            page.Find(".form-control").NodeValue = "Python";
            page.Find(".search-action").Click();
            page.Find(".jenlooper-cactus").Click();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Hiring a Python Developer"));
        }

        [Test]
        public void Product_Search_Press_Enter_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();
            page.Find(".form-control").NodeValue = "Python";
            page.Find(".form-control").KeyPress(key: "", code: "Enter");

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Hiring a Python Developer"));
        }
        #endregion SearchProducts

        #region SelectProduct
        [Test]
        public void SelectProduct_Ratings_Null_Should_Return_Product()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();
            page.Find(".selinazawacki-shirt").Click();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Be the first to vote!"));
        }

        [Test]
        public void SelectProduct_Ratings_Valid_VoteCount_Larger_Than_1_Should_Return_Product()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();
            page.Find(".jenlooper-cactus").Click();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual("Hiring a Python Developer", page.Find("#productTitle").Text());
            Assert.AreEqual(true, result.Contains("Votes"));
        }
        #endregion SelectProduct

        #region SubmitRating
        [Test]
        public void SubmitRating_Ratings_Smaller_Than_CurrentRating_Should_Return_New_Rating()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();
            page.Find(".jenlooper-cactus").Click();
            page.Find(".modal-footer .fa-star").Click();
            var data = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(1, data.Ratings.Last());
        }

        [Test]
        public void SubmitRating_Ratings_Larger_Than_CurrentRating_Should_Return_New_Rating()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();
            page.Find(".selinazawacki-shirt").Click();
            page.Find(".modal-footer .fa-star:last-child").Click();
            var data = TestHelper.ProductService.GetAllData().Last();

            // Assert
            Assert.AreEqual(5, data.Ratings.Last());
        }
        #endregion SubmitRating
    }

}