using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{

    /// <summary>
    /// Class to contain all the services of products
    /// </summary>
    public class JsonFileProductService
    {

        /// <summary>
        /// Constructor of product service class that use WebHostEnvironment to retrieve path of files
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
  
        /// <summary>
        /// Keeping the IWebHostEnvironment after getting it passed in
        /// </summary>
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// Retrive the Product.json file and let the WebHostEnvirontment know the path of Product.json
        /// </summary>
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        /// </summary>
        /// Method to return all the products by retrieving data from the JSON file, then convert JSON text to product object
        /// </summary>
        public IEnumerable<ProductModel> GetAllData()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            }

        }

        /// <summary>
        /// Search data by key
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetFilterData(string key)
        {
            var products = GetAllData();

            if (key == null)
            {
                return products;
            }

            return products.Where(x => x.Title.ToLower().Contains(key.ToLower()));
        }

        /// <summary>
        /// Sort data by Price
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetSortedDataByPrice(int type)
        {
            var products = GetAllData();

            if (type > 0)
            {
                return products.OrderBy(p => p.Price);
            }
            else
            {
                return products.OrderByDescending(p => p.Price);
            }     
        }

        /// <summary>
        /// Sort data by Ratings
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetSortedDataByRatings(int type)
        {
            var products = GetAllData();

            if (type > 0)
            {
                return products.OrderBy(p =>
                {
                    if (p.Ratings == null)
                    {
                        return 0;
                    }
                    int[] ratings = p.Ratings;
                    return ratings.Sum() / ratings.Length;
                });
            }
            else
            {
                return products.OrderByDescending(p =>
                {
                    if (p.Ratings == null)
                    {
                        return 0;
                    }
                    int[] ratings = p.Ratings;
                    return ratings.Sum() / ratings.Length;
                });
            }               
        }

        /// <summary>
        /// Add Rating
        /// 
        /// Take in the product ID and the rating
        /// If the rating does not exist, add it
        /// Save the update
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="rating"></param>
        public bool AddRating(string productId, int rating)
        {

            // If the ProductID is invalid, return
            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }

            var products = GetAllData();

            // Look up the product, if it does not exist, return
            var data = products.FirstOrDefault(x => x.Id.Equals(productId));
            if (data == null)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings below 0
            if (rating < 0)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings above 5
            if (rating > 5)
            {
                return false;
            }

            // Check to see if the rating exist, if there are none, then create the array
            if (data.Ratings == null)
            {
                data.Ratings = new int[] { };
            }

            // Add the Rating to the Array
            var ratings = data.Ratings.ToList();
            ratings.Add(rating);
            data.Ratings = ratings.ToArray();

            // Save the data back to the data store
            SaveData(products);

            return true;
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public ProductModel UpdateData(ProductModel data)
        {
            var products = GetAllData();
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (productData == null)
            {
                return null;
            }

            // Update the data to the new passed in values
            productData.Maker = data.Maker;
            productData.Title = data.Title;
            productData.Description = data.Description.Trim();
            productData.Image = data.Image;
            productData.Price = data.Price;

            SaveData(products);

            return productData;
        }

        /// <summary>
        /// Save All products data to storage
        /// </summary>
        private void SaveData(IEnumerable<ProductModel> products)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }

        /// <summary>
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public ProductModel CreateData()
        {
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };

            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var dataSet = GetAllData();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Create a new product using Input values
        /// </summary>
        /// <returns></returns>
        public ProductModel CreateDataFromInput(ProductModel data)
        {
            if (data == null)
            {
                return null;
            }

            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var dataSet = GetAllData();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public ProductModel DeleteData(string id)
        {

            // Get the current set, and append the new record to it
            var dataSet = GetAllData();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }

    }

}