using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class Purchase_History
	{
		[Required, Key]
		public string purchase_history_id { get; set; }
		[Required]
		public decimal total_price { get; set; }
		[Required]
		public DateTime purchase_date { get; set; }
		[Required]
		public decimal discounted_price { get; set; }
		[Required]
		public string payment_reference_code { get; set; }

		[Required]
		[Display(Name = "Voucher Name")]
		public string voucher_name { get; set; }

		[Required]
		[Display(Name = "Percentage Off")]
		public string percentage_off { get; set; }


		[Required]
		public string user_id { get; set; }
	}
}
