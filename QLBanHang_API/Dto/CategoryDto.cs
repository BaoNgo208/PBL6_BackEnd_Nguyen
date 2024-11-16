﻿using System.ComponentModel.DataAnnotations;

namespace QLBanHang_API.Request
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }  // Primary Key
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }
}