﻿using System.ComponentModel.DataAnnotations;

namespace QLBanHang_UI.Models
{
	public class ProductCategoryDto
	{
		// [Required]
		[Key]
		public Guid ProductCategoryId { get; set; } // Thêm khóa chính
		public Guid ProductId { get; set; }    // Foreign Key
		public Guid CategoryId { get; set; }   // Foreign Key
	}
}