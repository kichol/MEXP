﻿namespace MediaExpert.Application.Features.Products.Queries.GetProductDetail
{
    public class ProductDetailVm
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
