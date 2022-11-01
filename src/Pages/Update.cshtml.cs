using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [BindProperty]
        // single Data
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST OnGet
        /// Return all the data and find the target data
        /// </summary>
        public void OnGet(string id)
        {
            if (id != null)
            {
                var products = ProductService.GetAllData();
                Product = products.FirstOrDefault(x => x.Id.Equals(id));
            }     
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

            return RedirectToPage("/Index");
        }
    }
}