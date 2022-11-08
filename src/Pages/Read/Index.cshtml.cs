using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Pages.Read
{
    /// <summary>
    /// return all the data to show the developer
    /// </summary>
    public class ReadModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // Data Service
        public JsonFileProductService ProductService { get; }

        // single Data
        public ProductModel Product { get; private set; }

        /// <summary>
        /// REST OnGet
        /// Return all the data and find the target data, also redirect to Homepage if the URL is not valid
        /// </summary>
        public IActionResult OnGet(string id)
        {
            var products = ProductService.GetAllData();
            Product = products.FirstOrDefault(x => x.Id.Equals(id));


            if (Product == null)
            {
                return RedirectToPage("../Index");
            }

            return Page();

        }

    }

}