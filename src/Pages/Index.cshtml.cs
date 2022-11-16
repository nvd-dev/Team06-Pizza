using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// The homepage of the website that lists all the products
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Default Constructor, it takes a logger as a parameter, this allows for using injection testing
        /// </summary>
        /// <param name="logger"></param>
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// REST OnGet
        /// </summary>
        public void OnGet()
        {           
        }

    }

}