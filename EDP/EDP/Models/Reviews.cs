using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class Reviews
	{
		[Required, Key, Display(Name = "Review ID")]
		public string review_id { get; set; } = string.Empty;

		[Required]
		public string user_id { get; set; } = string.Empty;

		[Required]
		public string product_id { get; set; } = string.Empty;

		[Required, Display(Name = "Reviews")]
		public string review { get; set; } = string.Empty;

        [Display(Name = "Reviews Image")]
        public string review_image { get; set; } = string.Empty;
    }
}
