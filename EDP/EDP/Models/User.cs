 using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class User
	{
		[Required, Key]
		public string user_id { get; set; } = string.Empty;

		[DataType(DataType.EmailAddress)]
		[Required]
		public string email { get; set; } = string.Empty;

		[DataType(DataType.Password)]
		[Required]
		public string password { get; set; } = string.Empty;

		[Required]
		public string name { get; set; } = string.Empty;

		public string address { get; set; } = string.Empty;

		public string unit_No { get; set; } = string.Empty;

		[DataType(DataType.PostalCode)]
		public string postal_Code { get; set; } = string.Empty;

		[DataType(DataType.PhoneNumber)]
		public string phone_No { get; set; } = string.Empty;

		public string roles { get; set; } = string.Empty;

		public int points { get; set; }


	}
}
