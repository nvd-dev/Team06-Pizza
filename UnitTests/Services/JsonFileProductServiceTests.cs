using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.AddRating
{

    /// <summary>
    /// UnitTests for JsonFileProductService
    /// </summary>
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region AddRating
        //[Test]
        //public void AddRating_InValid_....()
        //{
        //    // Arrange

        //    // Act
        //    //var result = TestHelper.ProductService.AddRating(null, 1);

        //    // Assert
        //    //Assert.AreEqual(false, result);
        //}

        // ....

        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_Empty_Should_Return_False()
        {

            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_NotExist_Should_Return_False()
        {

            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("testid", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_Rating_Below0_Should_Return_False()
        {

            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, -1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_Rating_Above5_Should_Return_False()
        {

            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_Rating_5_NoneRating_Should_Return_True()
        {

            // Arrange

            // Get the Last data item
            var data = TestHelper.ProductService.GetAllData().Last();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().Last();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        [Test]
        public void AddRating_Valid_Product_Rating_5_Should_Return_True()
        {

            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        #endregion AddRating

        #region UpdateData
        [Test]
        public void UpdateData_InValid_Product_Data_Null_Should_Return_null()
        {

            // Arrange

            // create a data that NotExist
            var data = new ProductModel()
            {
                Id = "Test",
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };

            // Act
            var result = TestHelper.ProductService.UpdateData(data);

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void UpdateData_Valid_Product_Data_Should_Return_NewProduct()
        {

            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            data.Price = 10;

            // Act
            var result = TestHelper.ProductService.UpdateData(data);
            var dataNew = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(dataNew.Price, result.Price);
        }

        #endregion UpdateData

        #region CreateData
        [Test]
        public void CreateData_Valid_Product_Data_Should_Return_NewProduct()
        {

            // Arrange

            // Act
            var result = TestHelper.ProductService.CreateData();
            var dataNew = TestHelper.ProductService.GetAllData().Last();

            // Assert
            Assert.AreEqual(dataNew.Id, result.Id);
        }

        #endregion CreateData

        #region CreateDataFromInput
        [Test]
        public void CreateDataFromInput_InValid_Product_Data_Should_Return_null()
        {

            // Arrange

            // Act
            var result = TestHelper.ProductService.CreateDataFromInput(null);

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void CreateDataFromInput_Valid_Product_Data_Should_Return_NewProduct()
        {

            // Arrange
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };

            // Act
            var result = TestHelper.ProductService.CreateDataFromInput(data);
            var dataNew = TestHelper.ProductService.GetAllData().Last();

            // Assert
            Assert.AreEqual(dataNew.Id, result.Id);
        }

        #endregion CreateDataFromInput

        #region DeleteData
        [Test]
        public void DeleteData_Valid_Product_ID_Should_Return_Product()
        {

            // Arrange

            // Get the Last data item
            var data = TestHelper.ProductService.GetAllData().Last();

            // Act
            var result = TestHelper.ProductService.DeleteData(data.Id);
            var productData = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(data.Id));

            // Assert
            Assert.AreEqual(data.Id, result.Id);
            Assert.AreEqual(null, productData);
        }

        #endregion DeleteData
    }

}