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
        /// <summary>
        /// Setup test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region AddRating
        /// <summary>
        /// test case for AddRating method with null product
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Act. Call AddRating method
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert. Judging whether the return is correct
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// test case for AddRating method with invalid product
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Empty_Should_Return_False()
        {
            // Act. Call AddRating method
            var result = TestHelper.ProductService.AddRating("", 1);

            // Assert. Judging whether the return is correct
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// test case for AddRating method with not exist product
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_NotExist_Should_Return_False()
        {
            // Act. Call AddRating method
            var result = TestHelper.ProductService.AddRating("testid", 1);

            // Assert. Judging whether the return is correct
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// test case for AddRating method with valid product and rating below 0
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Rating_Below0_Should_Return_False()
        {
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act. Call AddRating method
            var result = TestHelper.ProductService.AddRating(data.Id, -1);

            // Assert. Judging whether the return is correct
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// test case for AddRating method with valid product and rating above 5
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Rating_Above5_Should_Return_False()
        {
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act. Call AddRating method
            var result = TestHelper.ProductService.AddRating(data.Id, 6);

            // Assert. Judging whether the return is correct
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// test case for AddRating method with valid product and first rating
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Rating_5_NoneRating_Should_Return_True()
        {
            // Get the Last data item
            var data = TestHelper.ProductService.GetAllData().Last();

            // Act. Call AddRating method
            var result = TestHelper.ProductService.AddRating(data.Id, 5);

            // Get updated data
            var dataNewList = TestHelper.ProductService.GetAllData().Last();

            // Assert. Judging whether the return is correct
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        /// <summary>
        /// test case for AddRating method with valid product and valid rating
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Rating_5_Should_Return_True()
        {
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            var countOriginal = data.Ratings.Length;

            // Act. Call AddRating method
            var result = TestHelper.ProductService.AddRating(data.Id, 5);

            // Get updated data
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert. Judging whether the return is correct
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        #endregion AddRating

        #region UpdateData
        /// <summary>
        /// test case for UpdateData method with null product
        /// </summary>
        [Test]
        public void UpdateData_InValid_Product_Data_Null_Should_Return_null()
        {
            // create a data that NotExist
            var data = new ProductModel()
            {
                Id = "Test",
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };

            // Act. Call UpdateData method
            var result = TestHelper.ProductService.UpdateData(data);

            // Assert. Judging whether the return is correct
            Assert.AreEqual(null, result);
        }

        /// <summary>
        /// test case for UpdateData method with valid product
        /// </summary>
        [Test]
        public void UpdateData_Valid_Product_Data_Should_Return_NewProduct()
        {
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            data.Price = 10;

            // Act. Call UpdateData method
            var result = TestHelper.ProductService.UpdateData(data);

            // Get updated data
            var dataNew = TestHelper.ProductService.GetAllData().First();

            // Assert. Judging whether the return is correct
            Assert.AreEqual(dataNew.Price, result.Price);
        }

        #endregion UpdateData

        #region CreateData
        /// <summary>
        /// test case for CreateData method with valid product
        /// </summary>
        [Test]
        public void CreateData_Valid_Product_Data_Should_Return_NewProduct()
        {
            // Act. Call CreateData method
            var result = TestHelper.ProductService.CreateData();

            // Get created data
            var dataNew = TestHelper.ProductService.GetAllData().Last();

            // Assert. Judging whether the return is correct
            Assert.AreEqual(dataNew.Id, result.Id);
        }

        #endregion CreateData

        #region CreateDataFromInput
        /// <summary>
        /// test case for CreateDataFromInput method with invalid product
        /// </summary>
        [Test]
        public void CreateDataFromInput_InValid_Product_Data_Should_Return_null()
        {
            // Act. Call CreateDataFromInput method
            var result = TestHelper.ProductService.CreateDataFromInput(null);

            // Assert. Judging whether the return is correct
            Assert.AreEqual(null, result);
        }

        /// <summary>
        /// test case for CreateDataFromInput method with valid product
        /// </summary>
        [Test]
        public void CreateDataFromInput_Valid_Product_Data_Should_Return_NewProduct()
        {

            // Arrange. Create new product
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };

            // Act. Call CreateDataFromInput method
            var result = TestHelper.ProductService.CreateDataFromInput(data);
            // Get created data
            var dataNew = TestHelper.ProductService.GetAllData().Last();

            // Assert. Judging whether the return is correct
            Assert.AreEqual(dataNew.Id, result.Id);
        }

        #endregion CreateDataFromInput

        #region DeleteData
        /// <summary>
        /// test case for DeleteData method with valid product id
        /// </summary>
        [Test]
        public void DeleteData_Valid_Product_ID_Should_Return_Product()
        {
            // Get the Last data item
            var data = TestHelper.ProductService.GetAllData().Last();

            // Act. Call DeleteData method
            var result = TestHelper.ProductService.DeleteData(data.Id);
            var productData = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(data.Id));

            // Assert. Judging whether the return is correct
            Assert.AreEqual(data.Id, result.Id);
            Assert.AreEqual(null, productData);
        }

        #endregion DeleteData

        #region SearchData
        /// <summary>
        /// test case for SearchData method with invalid key
        /// </summary>
        [Test]
        public void GetFilterData_InValid_Key_Should_Return_AllProducts()
        {
            // Act. Call GetFilterData method
            var result = TestHelper.ProductService.GetFilterData(null);
            var allDatas = TestHelper.ProductService.GetAllData();

            // Assert. Judging whether the return is correct
            Assert.AreEqual(allDatas.Count(), result.Count());
        }

        /// <summary>
        /// test case for SearchData method with valid key
        /// </summary>
        [Test]
        public void GetFilterData_Valid_Key_Should_Return_Products()
        {
            // Act. Call GetFilterData method
            var result = TestHelper.ProductService.GetFilterData("Python");

            // Assert. Judging whether the return is correct
            Assert.AreEqual(1, result.Count());
        }
        #endregion SearchData

        #region Sort Data By Price
        /// <summary>
        /// test case for GetSortedDataByPrice method with Ascending order
        /// </summary>
        [Test]
        public void GetSortedDataByPrice_asc_Order_Should_Return_AllProducts_With_Ascending()
        {
            // Act. Call GetSortedDataByPrice method
            var sortedDatas = TestHelper.ProductService.GetSortedDataByPrice(1);

            // Assert. Judging whether the return is correct
            Assert.AreEqual(true, sortedDatas.First().Price <= sortedDatas.Last().Price);
        }

        /// <summary>
        /// test case for GetSortedDataByPrice method with Descending order
        /// </summary>
        [Test]
        public void GetSortedDataByPrice_desc_Order_Should_Return_AllProducts_With_Descending()
        {
            // Act. Call GetSortedDataByPrice method
            var sortedDatas = TestHelper.ProductService.GetSortedDataByPrice(-1);

            // Assert. Judging whether the return is correct
            Assert.AreEqual(true, sortedDatas.First().Price >= sortedDatas.Last().Price);
        }
        #endregion Sort Data By Price

        #region Sort Data By Ratings
        /// <summary>
        /// test case for GetSortedDataByRatings method with Ascending order
        /// </summary>
        [Test]
        public void GetSortedDataByRatings_asc_Order_Should_Return_AllProducts_With_Ascending()
        {
            // Act. Call GetSortedDataByRatings method
            var sortedDatas = TestHelper.ProductService.GetSortedDataByRatings(2);

            // Get the rating of the first data
            var firstRating = 0;
            // Get the rating of the last data
            var lastRating = 0;
            if (sortedDatas.Last().Ratings != null)
            {
                int[] ratings = sortedDatas.Last().Ratings;
                lastRating = ratings.Sum() / ratings.Length;
            }

            // Assert. Judging whether the return is correct
            Assert.AreEqual(true, firstRating <= lastRating);
        }

        /// <summary>
        /// test case for GetSortedDataByRatings method with Dscending order
        /// </summary>
        [Test]
        public void GetSortedDataByRatings_desc_Order_Should_Return_AllProducts_With_Descending()
        {
            // Act. Call GetSortedDataByRatings method
            var sortedDatas = TestHelper.ProductService.GetSortedDataByRatings(-2);

            // Get the rating of the first data
            var firstRating = 0;
            if (sortedDatas.First().Ratings != null)
            {
                int[] ratings = sortedDatas.First().Ratings;
                firstRating = ratings.Sum() / ratings.Length;
            }
            // Get the rating of the last data
            var lastRating = 0;

            // Assert. Judging whether the return is correct
            Assert.AreEqual(true, firstRating >= lastRating);
        }
        #endregion Sort Data By Ratings
    }

}