using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class Cart
	{
		[Required,Key]
		public string cart_id { get; set; }
		[Required]
		public string product_id { get; set; }
		[Required]
		public string user_id { get; set; }
		[Required]
		public int quantity { get; set; }
	}
}
