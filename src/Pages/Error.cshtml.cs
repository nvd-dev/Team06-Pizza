using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    /// <summary>
    /// The Error page to show the error message
    /// </summary>
    public class ErrorModel : PageModel
    {

        // Getter and setter to the request ID from the query
        public string RequestId { get; set; }

        // Check if requestId is valid
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Creates a logger
        private readonly ILogger<ErrorModel> _logger;

        // The contructor takes a logger as a parameter, this allows for using injection testing
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// REST OnGet
        /// Return the error page if the ID is not valid
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }

    }

}