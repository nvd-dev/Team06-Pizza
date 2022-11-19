using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Models
{

    /// <summary>
    /// Product class that contain all the properties of a product object
    /// </summary>
    public class ProductModel
    {

        // A property contain the ID of the product
        public string Id { get; set; }

        // A property contain the name of the author of the product
        public string Maker { get; set; }

        // A property contain the image of the product
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // A property contain the link to the product's website
        public string Url { get; set; }

        // A property contain the title or the name of the product
        [StringLength(maximumLength: 70, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        public string Title { get; set; }

        // A property contain the description of the product
        public string Description { get; set; }

        // A property contain the average rating of the product
        public int[] Ratings { get; set; }

        // A property contain the type of the product
        public ProductTypeEnum ProductType { get; set; } = ProductTypeEnum.Undefined;

        // A property contain the quantity of the product, N/A
        //public string Quantity { get; set; }

        // A property contain the product's price
        [Range(0, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}."), RegularExpression("^[0-9]+(.[0-9]{0,2})?$", ErrorMessage = "Value for {0} must have up to two decimal places")]
        public double Price { get; set; }

        /// <summary>
        /// Convert ProductModel to Json String and store the Comments entered by the users on this product
        /// </summary>
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();

        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

    }

}