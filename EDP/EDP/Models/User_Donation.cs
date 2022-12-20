using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
    public class User_Donation
	{
		[Required, Key]
		public string user_donation_id { get; set; } = string.Empty;

		[Required, Display(Name = "Address")]
		public string address { get; set; } = string.Empty;

		[Required, Display(Name = "Unit Number")]
		public string unit_no { get; set; } = string.Empty;

		[Required, DataType(DataType.PostalCode), Range(6, 6), Display(Name = "Postal Code")]
        public int postal_code { get; set; }
		
        [Required, Display(Name = "Collection Date")]
		public string collection_date { get; set; } = string.Empty;

        [Required, Display(Name = "Collection Time")]
		public string collection_time { get; set; } = string.Empty;

        [Required, Display(Name = "Type of Waste")]
        public string type_of_waste { get; set; } = string.Empty;

		[Required]
		public string User_ID { get; set; } = string.Empty;	


    }
}
