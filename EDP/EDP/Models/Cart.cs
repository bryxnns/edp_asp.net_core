﻿using System.ComponentModel.DataAnnotations;

namespace EDP.Models
{
	public class Cart
	{
		[Required,Key]
		public string cart_id { get; set; }
		[Required]
		public string product_id { get; set; }
		[Required]
		public string user_id { get; set; }
		[Required, Range(1, 100000000, ErrorMessage = "Enter a number more than 1.")]
		public int quantity { get; set; }
	}
}
