using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class Reviews
	{
		[Required, Key]
		public string review_id { get; set; } = string.Empty;

		[Required]
		public string User_ID { get; set; } = string.Empty;

		[Required]
		public string product_id { get; set; } = string.Empty;

		[Required]
		public string review { get; set; } = string.Empty;
	}
}
