using NUnit.Framework;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{
    /// <summary>
    /// UnitTests for ProductModel
    /// </summary>
    public class ProductModelTests
    {
        #region TestSetup
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region ToString
        [Test]
        public void ProductModel_Valid_ToString_Should_Return_String()
        {
            // Arrange
            var data = new ProductModel() { Title = "ExampleTitle" };

            // Act
            var result = data.ToString();

            // Assert
            Assert.AreEqual(true, result.Contains("ExampleTitle"));
        }
        #endregion ToString
    }
}