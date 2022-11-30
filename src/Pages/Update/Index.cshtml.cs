using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

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
        /// <param name="productService"></param>
        public UpdateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // Data Service
        public JsonFileProductService ProductService { get; }

        [BindProperty]
        // single Data
        public ProductModel Product { get; set; }

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

        /// <summary>
        /// REST OnPost
        /// Update target data and Redirect To Index page
        /// </summary>
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ProductService.UpdateData(Product);

            return RedirectToPage("/Developer");
        }
    }
}