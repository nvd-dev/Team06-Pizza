using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// The homepage of the website that lists all the products
    /// </summary>
    public class HomeModel : PageModel
    {
        private readonly ILogger<HomeModel> _logger;

        /// <summary>
        /// Default Constructor, it takes a logger as a parameter, this allows for using injection testing
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public HomeModel(ILogger<HomeModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        /// <summary>
        /// ProductService property getter
        /// </summary> 
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Get method to return all the product services and set it to private
        /// </summary>
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// REST OnGet
        /// Return the list of all products
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }

    }

}