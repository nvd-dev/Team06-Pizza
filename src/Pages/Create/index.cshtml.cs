using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// return all the data to show the developer
    /// </summary>
    public class CreateModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CreateModel(JsonFileProductService productService)
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
        public void OnGet()
        {
            Product = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Maker = "Enter Maker",
                Title = "Enter Title",
                Description = "Enter Description",
                Price = 0,
                Url = "Enter URL",
                Image = ""
            };
        }

        /// <summary>
        /// REST OnPost
        /// Create A a new product and Update and Redirect To Index page
        /// </summary>
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ProductService.CreateDataFromInput(Product);

            return RedirectToPage("/Index");
        }
    }
}