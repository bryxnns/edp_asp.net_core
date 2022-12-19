using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class Products
	{
		[Required, Key]
		public string product_id { get; set; } = string.Empty;

		[Required, Display(Name = "Product Name")]
		public string product_name { get; set; } = string.Empty;

        [Required, Display(Name = "Product Description")]
        public string description { get; set; } = string.Empty;

        [Required, Display(Name = "Product Category")]
        public string category { get; set; } = string.Empty;

        [Required, Display(Name = "Product_Price")]
        public int price { get; set; }

        [Required, Display(Name = "Product_Stock")]
        public int stock { get; set; }

        [Required, Display(Name = "Expiry Date")]
        public DateOnly expiry_date { get; set; } 

		

    }
}
