﻿using MediaExpert.Products.Application.Features.Products.Commands.UpdateProduct;
using MediatR;

namespace MediaExpert.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductCommandResponse>
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
