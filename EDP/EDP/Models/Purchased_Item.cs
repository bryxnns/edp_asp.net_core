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

		[Required]
		public int quantity { get; set; }

		[Required]
		public string purchase_history_id { get; set; }
	}
}
