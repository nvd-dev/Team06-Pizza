using NUnit.Framework;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{
    /// <summary>
    /// UnitTests for ProductTypeEnumModel
    /// </summary>
    public class ProductTypeEnumModelTests
    {
        #region TestSetup
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region Amature
        [Test]
        public void ProductTypeEnumModel_Valid_Amature_Should_Return_Amature()
        {
            // Arrange
            ProductTypeEnum type = ProductTypeEnum.Amature;

            // Act
            var result = type.DisplayName();

            // Assert
            Assert.AreEqual("Hand Made Items", result);
        }
        #endregion Amature

        #region Antique
        [Test]
        public void ProductTypeEnumModel_Valid_Antique_Should_Return_Antique()
        {
            // Arrange
            ProductTypeEnum type = ProductTypeEnum.Antique;

            // Act
            var result = type.DisplayName();

            // Assert
            Assert.AreEqual("Antiques", result);
        }
        #endregion Antique

        #region Collectable
        [Test]
        public void ProductTypeEnumModel_Valid_Collectable_Should_Return_Collectable()
        {
            // Arrange
            ProductTypeEnum type = ProductTypeEnum.Collectable;

            // Act
            var result = type.DisplayName();

            // Assert
            Assert.AreEqual("Collectables", result);
        }
        #endregion Collectable

        #region Commercial
        [Test]
        public void ProductTypeEnumModel_Valid_Commercial_Should_Return_Commercial()
        {
            // Arrange
            ProductTypeEnum type = ProductTypeEnum.Commercial;

            // Act
            var result = type.DisplayName();

            // Assert
            Assert.AreEqual("Commercial goods", result);
        }
        #endregion Commercial

        #region Null
        [Test]
        public void ProductTypeEnumModel_Null_Should_Return_Null()
        {
            // Arrange
            var data = new ProductTypeEnum();

            // Act
            var result = data.DisplayName();

            // Assert
            Assert.AreEqual("", result);
        }
        #endregion Null
    }
}