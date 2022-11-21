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
        /// <summary>
        /// Setup test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region ToString
        /// <summary>
        /// Unit test to validate get and set methods of Product ToString with valid input
        /// </summary>
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