using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class Voucher
	{
		[Required, Key]
		public string voucher_id { get; set; }

		[Required, MaxLength(30)]
		[Display(Name = "Voucher Name")]
		public string voucher_name { get; set; }

		[Required]
		[Display(Name = "Percentage Off")]
		public string percentage_off { get; set; }

		[Required]
		[Display(Name = "Points Required")]
		public int points_required { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Expiry Date")]
		public DateTime expiry_date { get; set; }

	}
}
