﻿namespace QLBanHang_API.Dto
{
    public class ProductDetailOrder
    {
        public string? Name { get; set; }
        public decimal? PromotionPrice { get; set; }
        public string? ImageUrl { get; set; }
        public string? Warranty { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
