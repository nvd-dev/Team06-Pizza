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

        /// <summary>
        /// Check if requestId is valid
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Creates a logger for ErrorModel
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// The contructor takes a logger as a parameter, this allows for using injection testing
        /// </summary>
        /// <param name="logger">logger dependecy for ErrorModel</param>
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