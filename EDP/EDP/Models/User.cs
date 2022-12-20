using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class User
	{
		[Required, Key]
		public string User_ID { get; set; } = string.Empty;

		[DataType(DataType.EmailAddress)]
		[Required]
		public string Email { get; set; } = string.Empty;

		[DataType(DataType.Password)]
		[Required]
		public string Password { get; set; } = string.Empty;

		[Required]
		public string Name { get; set; } = string.Empty;

		public string Address { get; set; } = string.Empty;

		public string Unit_No { get; set; } = string.Empty;

		[DataType(DataType.PostalCode)]
		public string Postal_Code { get; set; } = string.Empty;

		[DataType(DataType.PhoneNumber)]
		public string Phone_No { get; set; } = string.Empty;

		public string Roles { get; set; } = string.Empty;

		public string Points { get; set; } = string.Empty;


	}
}
