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
    public class DeleteModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DeleteModel(JsonFileProductService productService)
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
        /// Return all the data and find the target data
        /// </summary>
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return RedirectToPage("/Index");
            }

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
        /// Create A a new product and Update and Redirect To Index page
        /// </summary>
        public IActionResult OnPostAsync()
        {

            ProductService.DeleteData(Product.Id);

            return RedirectToPage("/Developer");
        }
    }
}