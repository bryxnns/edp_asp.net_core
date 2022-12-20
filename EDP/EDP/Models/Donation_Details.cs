using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
    [Keyless]
    public class Donation_Details
	{
        [Required, Display(Name = "Waste Weight")]
        public string waste_weight { get; set; } = string.Empty;

        [Required, Display(Name = "Waste Image")]
        public string waste_image { get; set; } = string.Empty;

        [Required]
        public bool collection_done { get; set; }

        [Required]
        public bool drop_off_done { get; set; }

        [Required]
        public string drop_off_point { get; set; } = string.Empty;

        [Required]
        public string user_donation_id { get; set; } = string.Empty;
    }
}
