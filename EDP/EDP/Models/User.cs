 using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class User
	{
        // ========== Registration ==========
        [Key]
        [Display(Name = "UUID")]
        public string user_id { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required, RegularExpression(@"[a-z0-9]+@[a-z]+\.[a-z]{2,3}")]
        public string email { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Required, MinLength(8)]
        public string password { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Username")]
        public string name { get; set; } = string.Empty;
        // ========== End of Registration ==========


        [Display(Name = "Address")]
        public string address { get; set; } = string.Empty;

        [Display(Name = "Unit No.")]
        public string unit_No { get; set; } = string.Empty;

        [DataType(DataType.PostalCode)]
        [Display(Name = "Postal Code")]
        public string postal_Code { get; set; } = string.Empty;

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone No.")]
        public string phone_No { get; set; } = string.Empty;

        [Display(Name = "Roles")]
        public string roles { get; set; } = string.Empty;

        [Display(Name = "Points")]
        public int points { get; set; }
    }
}
