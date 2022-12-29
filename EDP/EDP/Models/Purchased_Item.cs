using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class Purchased_Item
	{
		[Required, Key]
		public string purchased_item_id { get; set; }
		[Required]
		public string product_name { get; set; }

		[Required]
		public decimal price { get; set; }

		[Required, Display(Name = "Expiry Date")]
		public string expiry_date { get; set; } = string.Empty;

		//didnt make image compulsory
		[Display(Name = "Product Image")]
		public string product_image { get; set; } = string.Empty;

		[Required]
		public int quantity { get; set; }

		[Required]
		public string purchase_history_id { get; set; }
	}
}
