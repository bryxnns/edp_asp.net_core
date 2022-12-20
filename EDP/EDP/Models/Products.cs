using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class Products
	{
		[Required, Key, Display(Name = "Product ID")]
		public string product_id { get; set; } = string.Empty;

		[Required, Display(Name = "Product Name")]
		public string product_name { get; set; } = string.Empty;

        [Required, MaxLength(400, ErrorMessage = "Please input a maximum of 400 characters only"), Display(Name = "Product Description")]
        public string description { get; set; } = string.Empty;

        [Required, Display(Name = "Product Category")]
        public string category { get; set; } = string.Empty;

        [Required, Display(Name = "Product Price")]
        public decimal price { get; set; }

        [Required, Display(Name = "Product Stock")]
        public int stock { get; set; }

        [Required, Display(Name = "Expiry Date")]
        public string expiry_date { get; set; } = string.Empty;

        //didnt make image compulsory
        [Display(Name = "Product Image")]
        public string product_image { get; set; } = string.Empty;

        [Required]
        public string User_ID { get; set; } = string.Empty;
    }
}
