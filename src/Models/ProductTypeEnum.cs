namespace ContosoCrafts.WebSite.Models
{

    /// <summary>
    /// Product Types
    /// </summary>
    public enum ProductTypeEnum
    {
        Undefined = 0,

        Amature = 1,

        Antique = 5,

        Collectable = 130,

        Commercial = 55,
    }

    /// <summary>
    /// Class contain Product Type method(s)
    /// </summary>
    public static class ProductTypeEnumExtensions
    {

        /// <summary>
        /// Get Product Type titles from Product Type enum
        /// </summary>
        public static string DisplayName(this ProductTypeEnum data)
        {
            return data switch
            {
                ProductTypeEnum.Amature => "Hand Made Items",

                ProductTypeEnum.Antique => "Antiques",

                ProductTypeEnum.Collectable => "Collectables",

                ProductTypeEnum.Commercial => "Commercial goods",
 
                // Default, Unknown
                _ => "",
            };

        }

    }

}