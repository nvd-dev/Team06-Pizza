using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// return all the data to show the developer
    /// </summary>
    public class UpdateModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public UpdateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // Data Service
        public JsonFileProductService ProductService { get; }

        // single Data
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST OnGet
        /// Return all the data and find the target data
        /// </summary>
        public void OnGet()
        {
            var products = ProductService.GetAllData();
            Product = products.FirstOrDefault(x => x.Id.Equals("jenlooper-cactus"));
        }
    }
}