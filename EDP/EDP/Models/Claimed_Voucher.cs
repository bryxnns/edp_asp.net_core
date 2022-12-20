using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class Claimed_Voucher
	{
		[Required, Key]
		public string claimed_voucher_id { get; set; }
		[Required]
		public string User_ID { get; set; }

		[Required]
		public string voucher_id { get; set; }

		public string voucher_code { get; set; }
	}
}
