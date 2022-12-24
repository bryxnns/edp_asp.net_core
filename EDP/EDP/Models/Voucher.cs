using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class Voucher
	{
		[Required, Key]
		[Display(Name = "Voucher ID")]
		public string voucher_id { get; set; }

		[Required, MaxLength(30, ErrorMessage ="Max length of 30 characters.")]
		[Display(Name = "Voucher Name")]
		public string voucher_name { get; set; }

		[Required,Range(0,100,ErrorMessage ="Enter a number from 0 to 100.")]
		[Display(Name = "Percentage Off")]
		public string percentage_off { get; set; }

		[Required,Range(0,100000000,ErrorMessage ="Enter a number more than 0.")]
		[Display(Name = "Points Required")]
		public int points_required { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Expiry Date")]
		public DateTime expiry_date { get; set; }

		[Required, Range(0, 100000000, ErrorMessage = "Enter a number more than 0.")]
		[Display(Name = "Minimum Spend")]
		public double min_spend { get; set; }

	}
}
