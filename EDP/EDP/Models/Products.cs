using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class Products
	{
		[Required, Key]
		public string product_id { get; set; } = string.Empty;

		[Required, Display(Name = "Product Name")]
		public string product_name { get; set; } = string.Empty;

        [Required, MaxLength(400), Display(Name = "Product Description")]
        public string description { get; set; } = string.Empty;

        [Required, Display(Name = "Product Category")]
        public string category { get; set; } = string.Empty;

        [Required, RegularExpression(@"^.\.(\d{1, 2})$"), Display(Name = "Product_Price")]
        public decimal price { get; set; }

        [Required, Display(Name = "Product_Stock")]
        public int stock { get; set; }

        [Required, Display(Name = "Expiry Date")]
        public string expiry_date { get; set; } = string.Empty;



    }
}
