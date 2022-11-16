using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{

    /// <summary>
    /// Controller class to handle incoming requests 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        /// <summary>
        /// Contructor for controller class to handle incoming requests
        /// </summary>
        /// <param name="productService"> Object contains webhost environment </param>
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // ProductService property getter
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Get method to return all the product services
        /// </summary>
        /// <returns> code 200 with JSON products </returns>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetAllData();
        }

        /// <summary>
        /// Patch method to add rating to a product service
        /// </summary>
        /// <param name="request"> Contain rating and productId of the service to update</param>
        /// <returns> Successful return 200 </returns>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);

            return Ok();
        }

        /// <summary>
        /// Model for rating a service
        /// </summary>
        public class RatingRequest
        {

            // Id of product service to update
            public string ProductId { get; set; }

            // Rating of product service to update
            public int Rating { get; set; }
        }

    }

}